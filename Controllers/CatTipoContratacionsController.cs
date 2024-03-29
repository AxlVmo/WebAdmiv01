﻿using AspNetCoreHero.ToastNotification.Abstractions;
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
    public class CatTipoContratacionsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoContratacionsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoContratacions
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
            return View(await _context.CatTipoContrataciones.ToListAsync());
        }

        // GET: CatTipoContratacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoContratacion = await _context.CatTipoContrataciones
                .FirstOrDefaultAsync(m => m.IdTipoContratacion == id);
            if (catTipoContratacion == null)
            {
                return NotFound();
            }

            return View(catTipoContratacion);
        }

        // GET: CatTipoContratacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoContratacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoContratacion,TipoContratacionDesc")] CatTipoContratacion catTipoContratacion)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoContrataciones
                       .Where(s => s.TipoContratacionDesc == catTipoContratacion.TipoContratacionDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoContratacion.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoContratacion.FechaRegistro = DateTime.Now;
                    catTipoContratacion.TipoContratacionDesc = catTipoContratacion.TipoContratacionDesc.ToString().ToUpper();
                    catTipoContratacion.IdEstatusRegistro = 1;
                    _context.Add(catTipoContratacion);
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
            return View(catTipoContratacion);
        }

        // GET: CatTipoContratacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoContratacion = await _context.CatTipoContrataciones.FindAsync(id);
            if (catTipoContratacion == null)
            {
                return NotFound();
            }
            return View(catTipoContratacion);
        }

        // POST: CatTipoContratacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoContratacion,TipoContratacionDesc,FechaRegistro,IdEstatusRegistro")] CatTipoContratacion catTipoContratacion)
        {
            if (id != catTipoContratacion.IdTipoContratacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoContratacion.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoContratacion.FechaRegistro = DateTime.Now;
                    catTipoContratacion.TipoContratacionDesc = catTipoContratacion.TipoContratacionDesc.ToString().ToUpper();
                    catTipoContratacion.IdEstatusRegistro = catTipoContratacion.IdEstatusRegistro;
                    _context.Update(catTipoContratacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoContratacionExists(catTipoContratacion.IdTipoContratacion))
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
            return View(catTipoContratacion);
        }

        // GET: CatTipoContratacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoContratacion = await _context.CatTipoContrataciones
                .FirstOrDefaultAsync(m => m.IdTipoContratacion == id);
            if (catTipoContratacion == null)
            {
                return NotFound();
            }

            return View(catTipoContratacion);
        }

        // POST: CatTipoContratacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoContratacion = await _context.CatTipoContrataciones.FindAsync(id);
            catTipoContratacion.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoContratacionExists(int id)
        {
            return _context.CatTipoContrataciones.Any(e => e.IdTipoContratacion == id);
        }
    }
}