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
    public class CatTipoDireccionsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoDireccionsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoDireccions
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
            return View(await _context.CatTipoDirecciones.ToListAsync());
        }

        // GET: CatTipoDireccions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDireccion = await _context.CatTipoDirecciones
                .FirstOrDefaultAsync(m => m.IdTipoDireccion == id);
            if (catTipoDireccion == null)
            {
                return NotFound();
            }

            return View(catTipoDireccion);
        }

        // GET: CatTipoDireccions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoDireccions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoDireccion,TipoDireccionDesc")] CatTipoDireccion catTipoDireccion)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.CatTipoDirecciones
                         .Where(s => s.TipoDireccionDesc == catTipoDireccion.TipoDireccionDesc)
                         .ToList();

                if (vDuplicados.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoDireccion.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoDireccion.FechaRegistro = DateTime.Now;
                    catTipoDireccion.TipoDireccionDesc = catTipoDireccion.TipoDireccionDesc.ToString().ToUpper().Trim();
                    catTipoDireccion.IdEstatusRegistro = 1;
                    _context.Add(catTipoDireccion);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoDireccion);
        }

        // GET: CatTipoDireccions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDireccion = await _context.CatTipoDirecciones.FindAsync(id);
            if (catTipoDireccion == null)
            {
                return NotFound();
            }
            return View(catTipoDireccion);
        }

        // POST: CatTipoDireccions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoDireccion,TipoDireccionDesc,IdEstatusRegistro")] CatTipoDireccion catTipoDireccion)
        {
            if (id != catTipoDireccion.IdTipoDireccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoDireccion.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoDireccion.FechaRegistro = DateTime.Now;
                    catTipoDireccion.TipoDireccionDesc = catTipoDireccion.TipoDireccionDesc.ToString().ToUpper().Trim();
                    catTipoDireccion.IdEstatusRegistro = catTipoDireccion.IdEstatusRegistro;
                    _context.Update(catTipoDireccion);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoDireccionExists(catTipoDireccion.IdTipoDireccion))
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
            return View(catTipoDireccion);
        }

        // GET: CatTipoDireccions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoDireccion = await _context.CatTipoDirecciones
                .FirstOrDefaultAsync(m => m.IdTipoDireccion == id);
            if (catTipoDireccion == null)
            {
                return NotFound();
            }

            return View(catTipoDireccion);
        }

        // POST: CatTipoDireccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoDireccion = await _context.CatTipoDirecciones.FindAsync(id);
            catTipoDireccion.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoDireccionExists(int id)
        {
            return _context.CatTipoDirecciones.Any(e => e.IdTipoDireccion == id);
        }
    }
}