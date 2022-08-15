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
    public class CatTipoAlumnosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoAlumnosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoAlumnoses
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

        // GET: CatTipoAlumnoses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoAlumnos = await _context.CatTipoAlumnos
                .FirstOrDefaultAsync(m => m.IdTipoAlumno == id);
            if (CatTipoAlumnos == null)
            {
                return NotFound();
            }

            return View(CatTipoAlumnos);
        }

        // GET: CatTipoAlumnoses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoAlumnoses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoAlumno,TipoAlumnoDesc")] CatTipoAlumno CatTipoAlumnos)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoAlumnos
                       .Where(s => s.TipoAlumnoDesc == CatTipoAlumnos.TipoAlumnoDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CatTipoAlumnos.IdUsuarioModifico = Guid.Parse(fuser);
                    CatTipoAlumnos.FechaRegistro = DateTime.Now;
                    CatTipoAlumnos.TipoAlumnoDesc = CatTipoAlumnos.TipoAlumnoDesc.ToString().ToUpper();
                    CatTipoAlumnos.IdEstatusRegistro = 1;
                    _context.Add(CatTipoAlumnos);
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
            return View(CatTipoAlumnos);
        }

        // GET: CatTipoAlumnoses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoAlumnos = await _context.CatTipoAlumnos.FindAsync(id);
            if (CatTipoAlumnos == null)
            {
                return NotFound();
            }
            return View(CatTipoAlumnos);
        }

        // POST: CatTipoAlumnoses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoAlumno,TipoAlumnoDesc,IdEstatusRegistro")] CatTipoAlumno CatTipoAlumnos)
        {
            if (id != CatTipoAlumnos.IdTipoAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CatTipoAlumnos.IdUsuarioModifico = Guid.Parse(fuser);
                    CatTipoAlumnos.FechaRegistro = DateTime.Now;
                    CatTipoAlumnos.TipoAlumnoDesc = CatTipoAlumnos.TipoAlumnoDesc.ToString().ToUpper();
                    CatTipoAlumnos.IdEstatusRegistro = CatTipoAlumnos.IdEstatusRegistro;
                    _context.Update(CatTipoAlumnos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoAlumnosExists(CatTipoAlumnos.IdTipoAlumno))
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
            return View(CatTipoAlumnos);
        }

        // GET: CatTipoAlumnoses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatTipoAlumnos = await _context.CatTipoAlumnos
                .FirstOrDefaultAsync(m => m.IdTipoAlumno == id);
            if (CatTipoAlumnos == null)
            {
                return NotFound();
            }

            return View(CatTipoAlumnos);
        }

        // POST: CatTipoAlumnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CatTipoAlumnos = await _context.TblCentros.FindAsync(id);
            CatTipoAlumnos.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoAlumnosExists(int id)
        {
            return _context.CatTipoAlumnos.Any(e => e.IdTipoAlumno == id);
        }
    }
}