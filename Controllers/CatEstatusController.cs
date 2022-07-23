using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class CatEstatusController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatEstatusController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }
        // GET: CatEstatus
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
            return View(await _context.CatEstatus.ToListAsync());
        }

        // GET: CatEstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatEstatus = await _context.CatEstatus
                .FirstOrDefaultAsync(m => m.IdEstatusRegistro == id);
            if (CatEstatus == null)
            {
                return NotFound();
            }

            return View(CatEstatus);
        }

        // GET: CatEstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatEstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstatus,EstatusDesc")] CatEstatus CatEstatus)
        {
            if (ModelState.IsValid)
            {
                var vEstatus = _context.CatEstatus.ToList();
                if (vEstatus.Count == 2)
                {
                    _notyf.Error("Solo se permite crear 2 Estatus", 5);
                }
                else
                {
                    var vDuplicados = _context.CatEstatus
                        .Where(s => s.EstatusDesc == CatEstatus.EstatusDesc)
                        .ToList();

                    if (vDuplicados.Count == 0)
                    {
                        var fuser = _userService.GetUserId();
                        var isLoggedIn = _userService.IsAuthenticated();
                        CatEstatus.IdUsuarioModifico = Guid.Parse(fuser);
                        CatEstatus.FechaRegistro = DateTime.Now;
                        CatEstatus.EstatusDesc = CatEstatus.EstatusDesc.ToString().ToUpper();
                        _context.Add(CatEstatus);
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
            }

            return View(CatEstatus);
        }

        // GET: CatEstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var CatEstatus = await _context.CatEstatus.FindAsync(id);
            if (CatEstatus == null)
            {
                return NotFound();
            }
            return View(CatEstatus);
        }

        // POST: CatEstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstatus,EstatusDesc,FechaRegistro,IdEstatusRegistro")] CatEstatus CatEstatus)
        {
            if (id != CatEstatus.IdEstatusRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CatEstatus.IdUsuarioModifico = Guid.Parse(fuser);
                    CatEstatus.FechaRegistro = DateTime.Now;
                    CatEstatus.EstatusDesc = CatEstatus.EstatusDesc.ToString().ToUpper();
                    CatEstatus.IdEstatusRegistro = CatEstatus.IdEstatusRegistro;
                    _context.SaveChanges();
                    _context.Update(CatEstatus);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatEstatusExists(CatEstatus.IdEstatusRegistro))
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
            return View(CatEstatus);
        }

        // GET: CatEstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CatEstatus = await _context.CatEstatus
                .FirstOrDefaultAsync(m => m.IdEstatusRegistro == id);
            if (CatEstatus == null)
            {
                return NotFound();
            }

            return View(CatEstatus);
        }

        // POST: CatEstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CatEstatus = await _context.CatEstatus.FindAsync(id);
            CatEstatus.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatEstatusExists(int id)
        {
            return _context.CatEstatus.Any(e => e.IdEstatusRegistro == id);
        }
    }
}