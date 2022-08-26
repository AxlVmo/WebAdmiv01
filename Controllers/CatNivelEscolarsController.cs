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
    public class CatNivelEscolarsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatNivelEscolarsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatNivelEscolars
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
            return View(await _context.CatNivelEscolares.ToListAsync());
        }

        // GET: CatNivelEscolars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catNivelEscolar = await _context.CatNivelEscolares
                .FirstOrDefaultAsync(m => m.IdNivelEscolar == id);
            if (catNivelEscolar == null)
            {
                return NotFound();
            }

            return View(catNivelEscolar);
        }

        // GET: CatNivelEscolars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatNivelEscolars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNivelEscolar,NivelEscolarDesc")] CatNivelEscolar catNivelEscolar)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatNivelEscolares
                       .Where(s => s.NivelEscolarDesc == catNivelEscolar.NivelEscolarDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catNivelEscolar.IdUsuarioModifico = Guid.Parse(fuser);
                    catNivelEscolar.FechaRegistro = DateTime.Now;
                    catNivelEscolar.NivelEscolarDesc = catNivelEscolar.NivelEscolarDesc.ToString().ToUpper().Trim();
                    catNivelEscolar.IdEstatusRegistro = 1;
                    _context.Add(catNivelEscolar);
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
            return View(catNivelEscolar);
        }

        // GET: CatNivelEscolars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catNivelEscolar = await _context.CatNivelEscolares.FindAsync(id);
            if (catNivelEscolar == null)
            {
                return NotFound();
            }
            return View(catNivelEscolar);
        }

        // POST: CatNivelEscolars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNivelEscolar,NivelEscolarDesc,IdEstatusRegistro")] CatNivelEscolar catNivelEscolar)
        {
            if (id != catNivelEscolar.IdNivelEscolar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catNivelEscolar.IdUsuarioModifico = Guid.Parse(fuser);
                    catNivelEscolar.FechaRegistro = DateTime.Now;
                    catNivelEscolar.NivelEscolarDesc = catNivelEscolar.NivelEscolarDesc.ToString().ToUpper().Trim();
                    catNivelEscolar.IdEstatusRegistro = catNivelEscolar.IdEstatusRegistro;
                    _context.Update(catNivelEscolar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatNivelEscolarExists(catNivelEscolar.IdNivelEscolar))
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
            return View(catNivelEscolar);
        }

        // GET: CatNivelEscolars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catNivelEscolar = await _context.CatNivelEscolares
                .FirstOrDefaultAsync(m => m.IdNivelEscolar == id);
            if (catNivelEscolar == null)
            {
                return NotFound();
            }

            return View(catNivelEscolar);
        }

        // POST: CatNivelEscolars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catNivelEscolar = await _context.CatNivelEscolares.FindAsync(id);
            catNivelEscolar.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatNivelEscolarExists(int id)
        {
            return _context.CatNivelEscolares.Any(e => e.IdNivelEscolar == id);
        }
    }
}