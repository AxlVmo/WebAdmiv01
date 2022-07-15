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
    public class CatTipoAlumnoesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoAlumnoesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoAlumnoes
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
            return View(await _context.CatTipoAlumnos.ToListAsync());
        }

        // GET: CatTipoAlumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAlumno = await _context.CatTipoAlumnos
                .FirstOrDefaultAsync(m => m.IdTipoAlumno == id);
            if (catTipoAlumno == null)
            {
                return NotFound();
            }

            return View(catTipoAlumno);
        }

        // GET: CatTipoAlumnoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoAlumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoAlumno,TipoAlumnoDesc")] CatTipoAlumno catTipoAlumno)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoAlumnos
                       .Where(s => s.TipoAlumnoDesc == catTipoAlumno.TipoAlumnoDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoAlumno.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoAlumno.TipoAlumnoDesc = catTipoAlumno.TipoAlumnoDesc.ToString().ToUpper();
                    catTipoAlumno.FechaRegistro = DateTime.Now;
                    catTipoAlumno.IdEstatusRegistro = 1;
                    _context.Add(catTipoAlumno);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoAlumno);
        }

        // GET: CatTipoAlumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAlumno = await _context.CatTipoAlumnos.FindAsync(id);
            if (catTipoAlumno == null)
            {
                return NotFound();
            }
            return View(catTipoAlumno);
        }

        // POST: CatTipoAlumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoAlumno,TipoAlumnoDesc,IdEstatusRegistro")] CatTipoAlumno catTipoAlumno)
        {
            if (id != catTipoAlumno.IdTipoAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoAlumno.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoAlumno.TipoAlumnoDesc = catTipoAlumno.TipoAlumnoDesc.ToString().ToUpper();
                    catTipoAlumno.FechaRegistro = DateTime.Now;
                    catTipoAlumno.IdEstatusRegistro = catTipoAlumno.IdEstatusRegistro;
                    _context.Update(catTipoAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoAlumnoExists(catTipoAlumno.IdTipoAlumno))
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
            return View(catTipoAlumno);
        }

        // GET: CatTipoAlumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoAlumno = await _context.CatTipoAlumnos
                .FirstOrDefaultAsync(m => m.IdTipoAlumno == id);
            if (catTipoAlumno == null)
            {
                return NotFound();
            }

            return View(catTipoAlumno);
        }

        // POST: CatTipoAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoAlumno = await _context.CatTipoAlumnos.FindAsync(id);
            catTipoAlumno.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoAlumnoExists(int id)
        {
            return _context.CatTipoAlumnos.Any(e => e.IdTipoAlumno == id);
        }
    }
}