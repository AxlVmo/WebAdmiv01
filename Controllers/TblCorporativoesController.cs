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
    public class TblCorporativoesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblCorporativoesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblCorporativoes
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresas.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.TblCorporativos.ToListAsync());
        }

        // GET: TblCorporativoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCorporativo = await _context.TblCorporativos
                .FirstOrDefaultAsync(m => m.IdCorporativo == id);
            if (tblCorporativo == null)
            {
                return NotFound();
            }

            return View(tblCorporativo);
        }

        // GET: TblCorporativoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblCorporativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorporativo,IdTipoLicencia,IdTipoCorporativo,NombreCorporativo,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEmpresa,FechaRegistro,IdEstatusRegistro")] TblCorporativo tblCorporativo)
        {
            if (ModelState.IsValid)
            {
                var vCorporativo = _context.TblCorporativos.ToList();
                if (vCorporativo.Count == 0)
                {
                    var vDuplicado = _context.TblCorporativos
                                         .Where(s => s.NombreCorporativo == tblCorporativo.NombreCorporativo)
                                         .ToList();

                    if (vDuplicado.Count == 0)
                    {
                        var fuser = _userService.GetUserId();
                        var isLoggedIn = _userService.IsAuthenticated();
                        tblCorporativo.IdUsuarioModifico = Guid.Parse(fuser);
                        tblCorporativo.FechaRegistro = DateTime.Now;
                        tblCorporativo.NombreCorporativo = tblCorporativo.NombreCorporativo.ToString().ToUpper();
                        tblCorporativo.IdEstatusRegistro = 1;
                        var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCorporativo.Colonia).FirstOrDefault();
                        tblCorporativo.IdColonia = !string.IsNullOrEmpty(tblCorporativo.Colonia) ? tblCorporativo.Colonia : tblCorporativo.Colonia;
                        tblCorporativo.Colonia = !string.IsNullOrEmpty(tblCorporativo.Colonia) ? strColonia.Dasenta.ToUpper() : tblCorporativo.Colonia;
                        tblCorporativo.Calle = !string.IsNullOrEmpty(tblCorporativo.Calle) ? tblCorporativo.Calle.ToUpper() : tblCorporativo.Calle;
                        tblCorporativo.LocalidadMunicipio = !string.IsNullOrEmpty(tblCorporativo.LocalidadMunicipio) ? tblCorporativo.LocalidadMunicipio.ToUpper() : tblCorporativo.LocalidadMunicipio;
                        tblCorporativo.Ciudad = !string.IsNullOrEmpty(tblCorporativo.Ciudad) ? tblCorporativo.Ciudad.ToUpper() : tblCorporativo.Ciudad;
                        tblCorporativo.Estado = !string.IsNullOrEmpty(tblCorporativo.Estado) ? tblCorporativo.Estado.ToUpper() : tblCorporativo.Estado;
                        _context.SaveChanges();
                        _context.Add(tblCorporativo);
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
            return View(tblCorporativo);
        }

        // GET: TblCorporativoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var tblCorporativo = await _context.TblCorporativos.FindAsync(id);
            if (tblCorporativo == null)
            {
                return NotFound();
            }
            return View(tblCorporativo);
        }

        // POST: TblCorporativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCorporativo,IdTipoLicencia,IdTipoCorporativo,NombreCorporativo,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEmpresa,FechaRegistro,IdEstatusRegistro")] TblCorporativo tblCorporativo)
        {
            if (id != tblCorporativo.IdCorporativo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblCorporativo.IdUsuarioModifico = Guid.Parse(fuser);
                    tblCorporativo.FechaRegistro = DateTime.Now;
                    tblCorporativo.NombreCorporativo = tblCorporativo.NombreCorporativo.ToString().ToUpper();
                    tblCorporativo.IdEstatusRegistro = tblCorporativo.IdEstatusRegistro;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCorporativo.Colonia).FirstOrDefault();
                    tblCorporativo.IdColonia = !string.IsNullOrEmpty(tblCorporativo.Colonia) ? tblCorporativo.Colonia : tblCorporativo.Colonia;
                    tblCorporativo.Colonia = !string.IsNullOrEmpty(tblCorporativo.Colonia) ? strColonia.Dasenta.ToUpper() : tblCorporativo.Colonia;
                    tblCorporativo.Calle = !string.IsNullOrEmpty(tblCorporativo.Calle) ? tblCorporativo.Calle.ToUpper() : tblCorporativo.Calle;
                    tblCorporativo.LocalidadMunicipio = !string.IsNullOrEmpty(tblCorporativo.LocalidadMunicipio) ? tblCorporativo.LocalidadMunicipio.ToUpper() : tblCorporativo.LocalidadMunicipio;
                    tblCorporativo.Ciudad = !string.IsNullOrEmpty(tblCorporativo.Ciudad) ? tblCorporativo.Ciudad.ToUpper() : tblCorporativo.Ciudad;
                    tblCorporativo.Estado = !string.IsNullOrEmpty(tblCorporativo.Estado) ? tblCorporativo.Estado.ToUpper() : tblCorporativo.Estado;
                    _context.SaveChanges();
                    _context.Update(tblCorporativo);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCorporativoExists(tblCorporativo.IdCorporativo))
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
            return View(tblCorporativo);
        }

        // GET: TblCorporativoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var tblCorporativo = await _context.TblCorporativos
                .FirstOrDefaultAsync(m => m.IdCorporativo == id);
            if (tblCorporativo == null)
            {
                return NotFound();
            }

            return View(tblCorporativo);
        }

        // POST: TblCorporativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblCorporativo = await _context.TblCorporativos.FindAsync(id);
            tblCorporativo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblCorporativoExists(Guid id)
        {
            return _context.TblCorporativos.Any(e => e.IdCorporativo == id);
        }
    }
}