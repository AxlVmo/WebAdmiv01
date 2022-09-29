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
    public class CatTipoFlujosCajaController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoFlujosCajaController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoFlujosCaja
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresas.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
                    var ValidaCorporativo = _context.TblCorporativos.ToList();

                    if (ValidaCorporativo.Count >= 1)
                    {
                        ViewBag.CorporativoFlag = 1;
                    }
                    else
                    {
                        ViewBag.CorporativoFlag = 0;
                        _notyf.Information("Favor de registrar los datos de Corporativo para la Aplicación", 5);
                    }
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatTipoFlujosCaja.ToListAsync());
        }

        // GET: CatTipoFlujosCaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoFlujoCaja = await _context.CatTipoFlujosCaja
                .FirstOrDefaultAsync(m => m.IdTipoFlujoCaja == id);
            if (catTipoFlujoCaja == null)
            {
                return NotFound();
            }

            return View(catTipoFlujoCaja);
        }

        // GET: CatTipoFlujosCaja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoFlujosCaja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoFlujoCaja,TipoFlujoCajaDesc")] CatTipoFlujoCaja catTipoFlujoCaja)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoFlujosCaja
                       .Where(s => s.TipoFlujoCajaDesc == catTipoFlujoCaja.TipoFlujoCajaDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoFlujoCaja.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoFlujoCaja.FechaRegistro = DateTime.Now;
                    catTipoFlujoCaja.TipoFlujoCajaDesc = catTipoFlujoCaja.TipoFlujoCajaDesc.ToString().ToUpper().Trim();
                    catTipoFlujoCaja.IdEstatusRegistro = 1;
                    _context.Add(catTipoFlujoCaja);
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
            return View(catTipoFlujoCaja);
        }

        // GET: CatTipoFlujosCaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoFlujoCaja = await _context.CatTipoFlujosCaja.FindAsync(id);
            if (catTipoFlujoCaja == null)
            {
                return NotFound();
            }
            return View(catTipoFlujoCaja);
        }

        // POST: CatTipoFlujosCaja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoFlujoCaja,TipoFlujoCajaDesc,FechaRegistro,IdEstatusRegistro")] CatTipoFlujoCaja catTipoFlujoCaja)
        {
            if (id != catTipoFlujoCaja.IdTipoFlujoCaja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoFlujoCaja.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoFlujoCaja.FechaRegistro = DateTime.Now;
                    catTipoFlujoCaja.TipoFlujoCajaDesc = catTipoFlujoCaja.TipoFlujoCajaDesc.ToString().ToUpper().Trim();
                    catTipoFlujoCaja.IdEstatusRegistro = catTipoFlujoCaja.IdEstatusRegistro;
                    _context.Update(catTipoFlujoCaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoFlujoCajaExists(catTipoFlujoCaja.IdTipoFlujoCaja))
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
            return View(catTipoFlujoCaja);
        }

        // GET: CatTipoFlujosCaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoFlujoCaja = await _context.CatTipoFlujosCaja
                .FirstOrDefaultAsync(m => m.IdTipoFlujoCaja == id);
            if (catTipoFlujoCaja == null)
            {
                return NotFound();
            }

            return View(catTipoFlujoCaja);
        }

        // POST: CatTipoFlujosCaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoFlujoCaja = await _context.CatTipoFlujosCaja.FindAsync(id);
            catTipoFlujoCaja.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoFlujoCajaExists(int id)
        {
            return _context.CatTipoFlujosCaja.Any(e => e.IdTipoFlujoCaja == id);
        }
    }
}