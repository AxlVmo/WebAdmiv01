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
    public class CatTipoDevolucionesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoDevolucionesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoDevoluciones
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
            return View(await _context.CatTipoDevoluciones.ToListAsync());
        }

        // GET: CatTipoDevoluciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoDevoluciones = await _context.CatTipoDevoluciones
                .FirstOrDefaultAsync(m => m.IdTipoDevolucion == id);
            if (CatTipoDevoluciones == null)
            {
                return NotFound();
            }

            return View(CatTipoDevoluciones);
        }

        // GET: CatTipoDevoluciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoDevoluciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDevolucion,TipoDevolucionDesc")] CatTipoDevolucion CatTipoDevoluciones)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoDevoluciones
                       .Where(s => s.TipoDevolucionDesc == CatTipoDevoluciones.TipoDevolucionDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CatTipoDevoluciones.IdUsuarioModifico = Guid.Parse(fuser);
                    CatTipoDevoluciones.FechaRegistro = DateTime.Now;
                    CatTipoDevoluciones.TipoDevolucionDesc = CatTipoDevoluciones.TipoDevolucionDesc.ToString().ToUpper();
                    CatTipoDevoluciones.IdEstatusRegistro = 1;
                    _context.Add(CatTipoDevoluciones);
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
            return View(CatTipoDevoluciones);
        }

        // GET: CatTipoDevoluciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoDevoluciones = await _context.CatTipoDevoluciones.FindAsync(id);
            if (CatTipoDevoluciones == null)
            {
                return NotFound();
            }
            return View(CatTipoDevoluciones);
        }

        // POST: CatTipoDevoluciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDevolucion,TipoDevolucionDesc,FechaRegistro,IdEstatusRegistro")] CatTipoDevolucion CatTipoDevoluciones)
        {
            if (id != CatTipoDevoluciones.IdTipoDevolucion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CatTipoDevoluciones.IdUsuarioModifico = Guid.Parse(fuser);
                    CatTipoDevoluciones.FechaRegistro = DateTime.Now;
                    CatTipoDevoluciones.TipoDevolucionDesc = CatTipoDevoluciones.TipoDevolucionDesc.ToString().ToUpper();
                    CatTipoDevoluciones.IdEstatusRegistro = CatTipoDevoluciones.IdEstatusRegistro;
                    _context.Update(CatTipoDevoluciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoDevolucionesExists(CatTipoDevoluciones.IdTipoDevolucion))
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
            return View(CatTipoDevoluciones);
        }

        // GET: CatTipoDevolucioness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoDevoluciones = await _context.CatTipoDevoluciones
                .FirstOrDefaultAsync(m => m.IdTipoDevolucion == id);
            if (CatTipoDevoluciones == null)
            {
                return NotFound();
            }

            return View(CatTipoDevoluciones);
        }

        // POST: CatTipoDevoluciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CatTipoDevoluciones = await _context.CatTipoDevoluciones.FindAsync(id);
            CatTipoDevoluciones.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoDevolucionesExists(int id)
        {
            return _context.CatTipoDevoluciones.Any(e => e.IdTipoDevolucion == id);
        }
    }
}