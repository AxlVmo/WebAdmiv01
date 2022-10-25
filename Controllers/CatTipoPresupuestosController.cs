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
    public class CatTipoPresupuestosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoPresupuestosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }


        // GET: CatTipoPresupuestos
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
            return View(await _context.CatTipoPresupuestos.ToListAsync());
        }
  
        // GET: CatTipoPresupuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdTipoPresupuesto == id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoPresupuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPresupuesto,TipoPresupuestoDesc")] CatTipoPresupuesto catTipoPresupuesto)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoPresupuestos
                       .Where(s => s.TipoPresupuestoDesc == catTipoPresupuesto.TipoPresupuestoDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoPresupuesto.FechaRegistro = DateTime.Now;
                    catTipoPresupuesto.TipoPresupuestoDesc = catTipoPresupuesto.TipoPresupuestoDesc.ToString().ToUpper().Trim();
                    catTipoPresupuesto.IdEstatusRegistro = 1;
                    _context.Add(catTipoPresupuesto);
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
            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos.FindAsync(id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }
            return View(catTipoPresupuesto);
        }

        // POST: CatTipoPresupuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPresupuesto,TipoPresupuestoDesc,IdEstatusRegistro")] CatTipoPresupuesto catTipoPresupuesto)
        {
            if (id != catTipoPresupuesto.IdTipoPresupuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoPresupuesto.FechaRegistro = DateTime.Now;
                    catTipoPresupuesto.TipoPresupuestoDesc = catTipoPresupuesto.TipoPresupuestoDesc.ToString().ToUpper().Trim();
                    catTipoPresupuesto.IdEstatusRegistro = catTipoPresupuesto.IdEstatusRegistro;
                    _context.Update(catTipoPresupuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoPresupuestoExists(catTipoPresupuesto.IdTipoPresupuesto))
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
            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdTipoPresupuesto == id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catTipoPresupuesto);
        }

        // POST: CatTipoPresupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoPresupuesto = await _context.CatTipoPresupuestos.FindAsync(id);
            catTipoPresupuesto.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoPresupuestoExists(int id)
        {
            return _context.CatTipoPresupuestos.Any(e => e.IdTipoPresupuesto == id);
        }
    }
}