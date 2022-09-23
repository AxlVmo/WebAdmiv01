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
    public class TblProveedoresController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblProveedoresController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblProveedors
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
                    var ValidaCorporativo = _context.TblCorporativos.ToList();

                    if (ValidaCorporativo.Count >= 1)
                    {
                        ViewBag.CorporativoFlag = 1;
                    }
                    else
                    {
                        ViewBag.CorporativoFlag = 0;
                        _notyf.Information("Favor de registrar los datos de Corporativo para la Aplicación", 5);
                    }
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
            return View(await _context.TblProveedores.ToListAsync());
        }

        // GET: TblProveedors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedores
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // GET: TblProveedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedor,NombreProveedor,Rfc,GiroComercial,CorreoElectronico,Telefono")] TblProveedor tblProveedor)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblProveedores
                                .Where(s => s.NombreProveedor == tblProveedor.NombreProveedor)
                                .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblProveedor.IdUsuarioModifico = Guid.Parse(f_user);
                    var idCorporativos = _context.TblCorporativos.FirstOrDefault();
                    tblProveedor.FechaRegistro = DateTime.Now;
                    tblProveedor.NombreProveedor = tblProveedor.NombreProveedor.ToString().ToUpper().Trim();
                    tblProveedor.GiroComercial = !string.IsNullOrEmpty(tblProveedor.GiroComercial) ? tblProveedor.GiroComercial.ToUpper().Trim() : tblProveedor.GiroComercial;
                    tblProveedor.Rfc = !string.IsNullOrEmpty(tblProveedor.Rfc) ? tblProveedor.Rfc.ToUpper().Trim() : tblProveedor.Rfc;
                    tblProveedor.IdEstatusRegistro = 1;
                    tblProveedor.IdCorporativo = idCorporativos.IdCorporativo;

                    _context.SaveChanges();
                    _context.Add(tblProveedor);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe Proveedor con el mismo nombre y el mismo Rfc", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedor);
        }

        // GET: TblProveedors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedores.FindAsync(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }
            return View(tblProveedor);
        }

        // POST: TblProveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdProveedor,NombreProveedor,Rfc,GiroComercial,CorreoElectronico,Telefono,IdEstatusRegistro")] TblProveedor tblProveedor)
        {
            if (id != tblProveedor.IdProveedor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblProveedor.IdUsuarioModifico = Guid.Parse(f_user);
                    var idCorporativos = _context.TblCorporativos.FirstOrDefault();
                    tblProveedor.FechaRegistro = DateTime.Now;
                    tblProveedor.NombreProveedor = tblProveedor.NombreProveedor.ToString().ToUpper().Trim();
                    tblProveedor.GiroComercial = !string.IsNullOrEmpty(tblProveedor.GiroComercial) ? tblProveedor.GiroComercial.ToUpper().Trim() : tblProveedor.GiroComercial;
                    tblProveedor.Rfc = !string.IsNullOrEmpty(tblProveedor.Rfc) ? tblProveedor.Rfc.ToUpper().Trim() : tblProveedor.Rfc;
                    tblProveedor.IdEstatusRegistro = 1;
                    tblProveedor.IdCorporativo = idCorporativos.IdCorporativo;

                    _context.Update(tblProveedor);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorExists(tblProveedor.IdProveedor))
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
            return View(tblProveedor);
        }

        // GET: TblProveedors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedor = await _context.TblProveedores
                .FirstOrDefaultAsync(m => m.IdProveedor == id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            return View(tblProveedor);
        }

        // POST: TblProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblProveedor = await _context.TblProveedores.FindAsync(id);
            tblProveedor.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorExists(Guid id)
        {
            return _context.TblProveedores.Any(e => e.IdProveedor == id);
        }
    }
}