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
    public class CatPerfilesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatPerfilesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatPerfils
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
            return View(await _context.CatPerfiles.ToListAsync());
        }

        // GET: CatPerfils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfiles
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (catPerfil == null)
            {
                return NotFound();
            }

            return View(catPerfil);
        }

        // GET: CatPerfils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPerfils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPerfil,PerfilDesc")] CatPerfil catPerfil)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.CatPerfiles
                        .Where(s => s.PerfilDesc == catPerfil.PerfilDesc)
                        .ToList();

                if (vDuplicados.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPerfil.IdUsuarioModifico = Guid.Parse(fuser);
                    catPerfil.FechaRegistro = DateTime.Now;
                    catPerfil.PerfilDesc = catPerfil.PerfilDesc.ToString().ToUpper().Trim();
                    catPerfil.IdEstatusRegistro = 1;
                    _context.Add(catPerfil);
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
            return View(catPerfil);
        }

        // GET: CatPerfils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfiles.FindAsync(id);
            if (catPerfil == null)
            {
                return NotFound();
            }
            return View(catPerfil);
        }

        // POST: CatPerfils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPerfil,PerfilDesc,IdEstatusRegistro")] CatPerfil catPerfil)
        {
            if (id != catPerfil.IdPerfil)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPerfil.IdUsuarioModifico = Guid.Parse(fuser);
                    catPerfil.FechaRegistro = DateTime.Now;
                    catPerfil.PerfilDesc = catPerfil.PerfilDesc.ToString().ToUpper().Trim();
                    catPerfil.IdEstatusRegistro = catPerfil.IdEstatusRegistro;
                    _context.Update(catPerfil);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPerfilExists(catPerfil.IdPerfil))
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
            return View(catPerfil);
        }

        // GET: CatPerfils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPerfil = await _context.CatPerfiles
                .FirstOrDefaultAsync(m => m.IdPerfil == id);
            if (catPerfil == null)
            {
                return NotFound();
            }

            return View(catPerfil);
        }

        // POST: CatPerfils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catPerfil = await _context.CatPerfiles.FindAsync(id);
            catPerfil.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatPerfilExists(int id)
        {
            return _context.CatPerfiles.Any(e => e.IdPerfil == id);
        }
    }
}