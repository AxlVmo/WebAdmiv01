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
    public class CatSubTipoMovimientosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatSubTipoMovimientosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatSubTipoMovimientos
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
            return View(await _context.CatSubTipoMovimientos.ToListAsync());
        }

        // GET: CatSubTipoMovimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoMovimientoo = await _context.CatSubTipoMovimientos
                .FirstOrDefaultAsync(m => m.IdSubTipoMovimiento == id);
            if (catSubTipoMovimientoo == null)
            {
                return NotFound();
            }

            return View(catSubTipoMovimientoo);
        }

        // GET: CatSubTipoMovimientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatSubTipoMovimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubSubTipoMovimientoo,SubTipoMovimientooDesc")] CatSubTipoMovimiento catSubTipoMovimientoo)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatSubTipoMovimientos
                       .Where(s => s.SubTipoMovimientoDesc == catSubTipoMovimientoo.SubTipoMovimientoDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catSubTipoMovimientoo.IdUsuarioModifico = Guid.Parse(f_user);
                    catSubTipoMovimientoo.FechaRegistro = DateTime.Now;
                    catSubTipoMovimientoo.SubTipoMovimientoDesc = catSubTipoMovimientoo.SubTipoMovimientoDesc.ToString().ToUpper().Trim();
                    catSubTipoMovimientoo.IdEstatusRegistro = 1;
                    _context.Add(catSubTipoMovimientoo);
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
            return View(catSubTipoMovimientoo);
        }

        // GET: CatSubTipoMovimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoMovimientoo = await _context.CatSubTipoMovimientos.FindAsync(id);
            if (catSubTipoMovimientoo == null)
            {
                return NotFound();
            }
            return View(catSubTipoMovimientoo);
        }

        // POST: CatSubTipoMovimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubSubTipoMovimientoo,SubTipoMovimientooDesc,FechaRegistro,IdEstatusRegistro")] CatSubTipoMovimiento catSubTipoMovimientoo)
        {
            if (id != catSubTipoMovimientoo.IdSubTipoMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catSubTipoMovimientoo.IdUsuarioModifico = Guid.Parse(f_user);
                    catSubTipoMovimientoo.FechaRegistro = DateTime.Now;
                    catSubTipoMovimientoo.SubTipoMovimientoDesc = catSubTipoMovimientoo.SubTipoMovimientoDesc.ToString().ToUpper().Trim();
                    catSubTipoMovimientoo.IdEstatusRegistro = catSubTipoMovimientoo.IdEstatusRegistro;
                    _context.Update(catSubTipoMovimientoo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatSubTipoMovimientooExists(catSubTipoMovimientoo.IdSubTipoMovimiento))
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
            return View(catSubTipoMovimientoo);
        }

        // GET: CatSubTipoMovimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoMovimientoo = await _context.CatSubTipoMovimientos
                .FirstOrDefaultAsync(m => m.IdSubTipoMovimiento == id);
            if (catSubTipoMovimientoo == null)
            {
                return NotFound();
            }

            return View(catSubTipoMovimientoo);
        }

        // POST: CatSubTipoMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catSubTipoMovimientoo = await _context.CatSubTipoMovimientos.FindAsync(id);
            catSubTipoMovimientoo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatSubTipoMovimientooExists(int id)
        {
            return _context.CatSubTipoMovimientos.Any(e => e.IdSubTipoMovimiento == id);
        }
    }
}