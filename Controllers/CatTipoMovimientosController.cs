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
    public class CatTipoMovimientosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoMovimientosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoMovimientos
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
            return View(await _context.CatTipoMovimientos.ToListAsync());
        }

        // GET: CatTipoMovimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoMovimiento = await _context.CatTipoMovimientos
                .FirstOrDefaultAsync(m => m.IdTipoMovimiento == id);
            if (catTipoMovimiento == null)
            {
                return NotFound();
            }

            return View(catTipoMovimiento);
        }

        // GET: CatTipoMovimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoMovimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMovimiento,TipoMovimientoDesc")] CatTipoMovimiento catTipoMovimiento)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoMovimientos
                       .Where(s => s.TipoMovimientoDesc == catTipoMovimiento.TipoMovimientoDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoMovimiento.FechaRegistro = DateTime.Now;
                    catTipoMovimiento.TipoMovimientoDesc = catTipoMovimiento.TipoMovimientoDesc.ToString().ToUpper().Trim();
                    catTipoMovimiento.IdEstatusRegistro = 1;
                    _context.Add(catTipoMovimiento);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoMovimiento);
        }

        // GET: CatTipoMovimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoMovimiento = await _context.CatTipoMovimientos.FindAsync(id);
            if (catTipoMovimiento == null)
            {
                return NotFound();
            }
            return View(catTipoMovimiento);
        }

        // POST: CatTipoMovimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMovimiento,TipoMovimientoDesc,FechaRegistro,IdEstatusRegistro")] CatTipoMovimiento catTipoMovimiento)
        {
            if (id != catTipoMovimiento.IdTipoMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoMovimiento.FechaRegistro = DateTime.Now;
                    catTipoMovimiento.TipoMovimientoDesc = catTipoMovimiento.TipoMovimientoDesc.ToString().ToUpper().Trim();
                    catTipoMovimiento.IdEstatusRegistro = catTipoMovimiento.IdEstatusRegistro;
                    _context.Update(catTipoMovimiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoMovimientoExists(catTipoMovimiento.IdTipoMovimiento))
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
            return View(catTipoMovimiento);
        }

        // GET: CatTipoMovimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoMovimiento = await _context.CatTipoMovimientos
                .FirstOrDefaultAsync(m => m.IdTipoMovimiento == id);
            if (catTipoMovimiento == null)
            {
                return NotFound();
            }

            return View(catTipoMovimiento);
        }

        // POST: CatTipoMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoMovimiento = await _context.CatTipoMovimientos.FindAsync(id);
            catTipoMovimiento.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoMovimientoExists(int id)
        {
            return _context.CatTipoMovimientos.Any(e => e.IdTipoMovimiento == id);
        }
    }
}