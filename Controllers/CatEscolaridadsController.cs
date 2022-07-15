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
    public class CatEscolaridadsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatEscolaridadsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatEscolaridads
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
            return View(await _context.CatEscolaridades.ToListAsync());
        }

        // GET: CatEscolaridads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEscolaridad = await _context.CatEscolaridades
                .FirstOrDefaultAsync(m => m.IdEscolaridad == id);
            if (catEscolaridad == null)
            {
                return NotFound();
            }

            return View(catEscolaridad);
        }

        // GET: CatEscolaridads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEscolaridads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEscolaridad,EscolaridadDesc")] CatEscolaridad catEscolaridad)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatAreas
                       .Where(s => s.AreaDesc == catEscolaridad.EscolaridadDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catEscolaridad.IdUsuarioModifico = Guid.Parse(fuser);
                    catEscolaridad.FechaRegistro = DateTime.Now;
                    catEscolaridad.EscolaridadDesc = catEscolaridad.EscolaridadDesc.ToString().ToUpper();
                    catEscolaridad.IdEstatusRegistro = 1;
                    _context.Add(catEscolaridad);
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
            return View(catEscolaridad);
        }

        // GET: CatEscolaridads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catEscolaridad = await _context.CatEscolaridades.FindAsync(id);
            if (catEscolaridad == null)
            {
                return NotFound();
            }
            return View(catEscolaridad);
        }

        // POST: CatEscolaridads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEscolaridad,EscolaridadDesc,IdEstatusRegistro")] CatEscolaridad catEscolaridad)
        {
            if (id != catEscolaridad.IdEscolaridad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catEscolaridad.IdUsuarioModifico = Guid.Parse(fuser);
                    catEscolaridad.FechaRegistro = DateTime.Now;
                    catEscolaridad.EscolaridadDesc = catEscolaridad.EscolaridadDesc.ToString().ToUpper();
                    catEscolaridad.IdEstatusRegistro = catEscolaridad.IdEstatusRegistro;
                    _context.Update(catEscolaridad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEscolaridadExists(catEscolaridad.IdEscolaridad))
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
            return View(catEscolaridad);
        }

        // GET: CatEscolaridads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catEscolaridad = await _context.CatEscolaridades
                .FirstOrDefaultAsync(m => m.IdEscolaridad == id);
            if (catEscolaridad == null)
            {
                return NotFound();
            }

            return View(catEscolaridad);
        }

        // POST: CatEscolaridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catEscolaridad = await _context.CatEscolaridades.FindAsync(id);
            catEscolaridad.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatEscolaridadExists(int id)
        {
            return _context.CatEscolaridades.Any(e => e.IdEscolaridad == id);
        }
    }
}