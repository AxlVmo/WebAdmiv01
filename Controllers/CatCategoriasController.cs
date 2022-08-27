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
    public class CatCategoriasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatCategoriasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatCategorias
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
            var fnCatCategoria = from a in _context.CatCategorias

                                 select new CatCategoria
                                 {
                                     IdCategoria = a.IdCategoria,
                                     CategoriaDesc = a.CategoriaDesc,
                                     FechaRegistro = a.FechaRegistro,
                                     IdEstatusRegistro = a.IdEstatusRegistro
                                 };

            return View(await fnCatCategoria.ToListAsync());
        }

        // GET: CatCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // GET: CatCategorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoria,CategoriaDesc")] CatCategoria nCatCategoria)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatCategorias
               .Where(s => s.CategoriaDesc == nCatCategoria.CategoriaDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    nCatCategoria.IdUsuarioModifico = Guid.Parse(fuser);
                    nCatCategoria.CategoriaDesc = nCatCategoria.CategoriaDesc.ToString().ToUpper().Trim();
                    nCatCategoria.FechaRegistro = DateTime.Now;
                    nCatCategoria.IdEstatusRegistro = 1;
                    _context.Add(nCatCategoria);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Categoria con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdCategoria"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", nCatCategoria.IdCategoria);
            return View(nCatCategoria);
        }

        // GET: CatCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias.FindAsync(id);
            if (catCategoria == null)
            {
                return NotFound();
            }
            return View(catCategoria);
        }

        // POST: CatCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,CategoriaDesc,IdEstatusRegistro")] CatCategoria nCatCategoria)
        {
            if (id != nCatCategoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    nCatCategoria.IdUsuarioModifico = Guid.Parse(fuser);
                    nCatCategoria.CategoriaDesc = nCatCategoria.CategoriaDesc.ToString().ToUpper().Trim();
                    nCatCategoria.FechaRegistro = DateTime.Now;
                    nCatCategoria.IdEstatusRegistro = nCatCategoria.IdEstatusRegistro;
                    _context.Update(nCatCategoria);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatCategoriaExists(nCatCategoria.IdCategoria))
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
            return View(nCatCategoria);
        }

        // GET: CatCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCategoria = await _context.CatCategorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (catCategoria == null)
            {
                return NotFound();
            }

            return View(catCategoria);
        }

        // POST: CatCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nCatCategoria = await _context.CatCategorias.FindAsync(id);
            nCatCategoria.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatCategoriaExists(int id)
        {
            return _context.CatCategorias.Any(e => e.IdCategoria == id);
        }
    }
}