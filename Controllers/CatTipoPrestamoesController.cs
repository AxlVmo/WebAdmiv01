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
    public class CatTipoPrestamoesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoPrestamoesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoPrestamoes
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
            return View(await _context.CatTipoPrestamos.ToListAsync());
        }

        // GET: CatTipoPrestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPrestamo = await _context.CatTipoPrestamos
                .FirstOrDefaultAsync(m => m.IdTipoPrestamo == id);
            if (catTipoPrestamo == null)
            {
                return NotFound();
            }

            return View(catTipoPrestamo);
        }

        // GET: CatTipoPrestamoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoPrestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPrestamo,TipoPrestamoDesc")] CatTipoPrestamo catTipoPrestamo)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoPrestamos
                       .Where(s => s.TipoPrestamoDesc == catTipoPrestamo.TipoPrestamoDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPrestamo.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoPrestamo.FechaRegistro = DateTime.Now;
                    catTipoPrestamo.TipoPrestamoDesc = catTipoPrestamo.TipoPrestamoDesc.ToString().ToUpper();
                    catTipoPrestamo.IdEstatusRegistro = 1;
                    _context.Add(catTipoPrestamo);
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
            return View(catTipoPrestamo);
        }

        // GET: CatTipoPrestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPrestamo = await _context.CatTipoPrestamos.FindAsync(id);
            if (catTipoPrestamo == null)
            {
                return NotFound();
            }
            return View(catTipoPrestamo);
        }

        // POST: CatTipoPrestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPrestamo,TipoPrestamoDesc,FechaRegistro,IdEstatusRegistro")] CatTipoPrestamo catTipoPrestamo)
        {
            if (id != catTipoPrestamo.IdTipoPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPrestamo.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoPrestamo.FechaRegistro = DateTime.Now;
                    catTipoPrestamo.TipoPrestamoDesc = catTipoPrestamo.TipoPrestamoDesc.ToString().ToUpper();
                    catTipoPrestamo.IdEstatusRegistro = catTipoPrestamo.IdEstatusRegistro;
                    _context.Update(catTipoPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoPrestamoExists(catTipoPrestamo.IdTipoPrestamo))
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
            return View(catTipoPrestamo);
        }

        // GET: CatTipoPrestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPrestamo = await _context.CatTipoPrestamos
                .FirstOrDefaultAsync(m => m.IdTipoPrestamo == id);
            if (catTipoPrestamo == null)
            {
                return NotFound();
            }

            return View(catTipoPrestamo);
        }

        // POST: CatTipoPrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoPrestamo = await _context.CatTipoPrestamos.FindAsync(id);
            catTipoPrestamo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoPrestamoExists(int id)
        {
            return _context.CatTipoPrestamos.Any(e => e.IdTipoPrestamo == id);
        }
    }
}