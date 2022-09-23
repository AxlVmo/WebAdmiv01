using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class TblEmpresasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblEmpresasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblEmpresas
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.TblEmpresas.ToListAsync());
        }

        // GET: TblEmpresas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresas
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }

            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEmpresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresa,NombreEmpresa,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,FiltroUserName")] TblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                var vEmpresa = _context.TblEmpresas.ToList();
                if (vEmpresa.Count == 0)
                {
                    var vDuplicado = _context.TblEmpresas
                                         .Where(s => s.NombreEmpresa == tblEmpresa.NombreEmpresa)
                                         .ToList();

                    if (vDuplicado.Count == 0)
                    {
                        var f_user = _userService.GetUserId();
                        var isLoggedIn = _userService.IsAuthenticated();

                        tblEmpresa.FechaRegistro = DateTime.Now;
                        tblEmpresa.NombreEmpresa = tblEmpresa.NombreEmpresa.ToString().ToUpper().Trim();
                        tblEmpresa.GiroComercial = !string.IsNullOrEmpty(tblEmpresa.GiroComercial) ? tblEmpresa.GiroComercial.ToUpper().Trim() : tblEmpresa.GiroComercial;
                        tblEmpresa.IdEstatusRegistro = 1;
                        var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblEmpresa.Colonia).FirstOrDefault();
                        tblEmpresa.IdColonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? tblEmpresa.Colonia : tblEmpresa.Colonia;
                        tblEmpresa.Colonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblEmpresa.Colonia;
                        tblEmpresa.Calle = !string.IsNullOrEmpty(tblEmpresa.Calle) ? tblEmpresa.Calle.ToUpper().Trim() : tblEmpresa.Calle;
                        tblEmpresa.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresa.LocalidadMunicipio) ? tblEmpresa.LocalidadMunicipio.ToUpper().Trim() : tblEmpresa.LocalidadMunicipio;
                        tblEmpresa.Ciudad = !string.IsNullOrEmpty(tblEmpresa.Ciudad) ? tblEmpresa.Ciudad.ToUpper().Trim() : tblEmpresa.Ciudad;
                        tblEmpresa.Estado = !string.IsNullOrEmpty(tblEmpresa.Estado) ? tblEmpresa.Estado.ToUpper().Trim() : tblEmpresa.Estado;
                        tblEmpresa.IdUsuarioModifico = Guid.Parse(f_user);
                        _context.SaveChanges();
                        _context.Add(tblEmpresa);
                        await _context.SaveChangesAsync();
                        _notyf.Success("Registro creado con éxito", 5);
                    }
                    else
                    {
                        _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                    }
                }
                else
                {
                    _notyf.Error("Solo se permite crear 1 Empresa", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            TempData["lCE"] = _context.CatEstatus.ToList();
            ViewBag.ListaCatEstatus = TempData["lCE"];

            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresas.FindAsync(id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }
            return View(tblEmpresa);
        }

        // POST: TblEmpresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresa,NombreEmpresa,RFC,GiroComercial,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEstatusRegistro")] TblEmpresa tblEmpresa)
        {
            if (id != tblEmpresa.IdEmpresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblEmpresa.IdUsuarioModifico = Guid.Parse(f_user);
                    tblEmpresa.FechaRegistro = DateTime.Now;
                    tblEmpresa.NombreEmpresa = tblEmpresa.NombreEmpresa.ToString().ToUpper().Trim();
                    tblEmpresa.GiroComercial = !string.IsNullOrEmpty(tblEmpresa.GiroComercial) ? tblEmpresa.GiroComercial.ToUpper().Trim() : tblEmpresa.GiroComercial;
                    tblEmpresa.IdEstatusRegistro = tblEmpresa.IdEstatusRegistro;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblEmpresa.Colonia).FirstOrDefault();
                    tblEmpresa.IdColonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? tblEmpresa.Colonia : tblEmpresa.Colonia;
                    tblEmpresa.Colonia = !string.IsNullOrEmpty(tblEmpresa.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblEmpresa.Colonia;
                    tblEmpresa.Calle = !string.IsNullOrEmpty(tblEmpresa.Calle) ? tblEmpresa.Calle.ToUpper().Trim() : tblEmpresa.Calle;
                    tblEmpresa.LocalidadMunicipio = !string.IsNullOrEmpty(tblEmpresa.LocalidadMunicipio) ? tblEmpresa.LocalidadMunicipio.ToUpper().Trim() : tblEmpresa.LocalidadMunicipio;
                    tblEmpresa.Ciudad = !string.IsNullOrEmpty(tblEmpresa.Ciudad) ? tblEmpresa.Ciudad.ToUpper().Trim() : tblEmpresa.Ciudad;
                    tblEmpresa.Estado = !string.IsNullOrEmpty(tblEmpresa.Estado) ? tblEmpresa.Estado.ToUpper().Trim() : tblEmpresa.Estado;
                    _context.SaveChanges();
                    _context.Update(tblEmpresa);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpresaExists(tblEmpresa.IdEmpresa))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmpresa);
        }

        // GET: TblEmpresas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpresa = await _context.TblEmpresas
                .FirstOrDefaultAsync(m => m.IdEmpresa == id);
            if (tblEmpresa == null)
            {
                return NotFound();
            }

            return View(tblEmpresa);
        }

        // POST: TblEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblEmpresa = await _context.TblEmpresas.FindAsync(id);
            tblEmpresa.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpresaExists(Guid id)
        {
            return _context.TblEmpresas.Any(e => e.IdEmpresa == id);
        }
    }
}