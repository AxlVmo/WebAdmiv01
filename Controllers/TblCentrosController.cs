﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class TblCentrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotyfService _notyf;

        public TblCentrosController(ApplicationDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        // GET: tblCentros
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresa.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
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
            return View(await _context.TblCentros.ToListAsync());
        }

        [HttpGet]
        public ActionResult FiltroEmpresaFiscales(Guid id)
        {
            var fEmpresaFiscales = (from ta in _context.TblCentros
                                    where ta.IdCentro == id
                                    select ta).Distinct().ToList();

            return Json(fEmpresaFiscales);
        }

        // GET: tblCentros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCentros = await _context.TblCentros
                .FirstOrDefaultAsync(m => m.IdCentro == id);
            if (tblCentros == null)
            {
                return NotFound();
            }

            return View(tblCentros);
        }

        // GET: tblCentros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblCentros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpresaFiscales,NombreCentro,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono")] TblCentros tblCentros)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblCentros
                       .Where(s => s.NombreCentro == tblCentros.NombreCentro)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var idEmpresa = _context.TblEmpresa.FirstOrDefault();
                    tblCentros.FechaRegistro = DateTime.Now;
                    tblCentros.NombreCentro = tblCentros.NombreCentro.ToString().ToUpper();
                    tblCentros.IdEstatusRegistro = 1;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCentros.Colonia).FirstOrDefault();
                    tblCentros.IdColonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? tblCentros.Colonia : tblCentros.Colonia;
                    tblCentros.Colonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? strColonia.Dasenta.ToUpper() : tblCentros.Colonia;
                    tblCentros.Calle = !string.IsNullOrEmpty(tblCentros.Calle) ? tblCentros.Calle.ToUpper() : tblCentros.Calle;
                    tblCentros.LocalidadMunicipio = !string.IsNullOrEmpty(tblCentros.LocalidadMunicipio) ? tblCentros.LocalidadMunicipio.ToUpper() : tblCentros.LocalidadMunicipio;
                    tblCentros.Ciudad = !string.IsNullOrEmpty(tblCentros.Ciudad) ? tblCentros.Ciudad.ToUpper() : tblCentros.Ciudad;
                    tblCentros.Estado = !string.IsNullOrEmpty(tblCentros.Estado) ? tblCentros.Estado.ToUpper() : tblCentros.Estado;
                    tblCentros.IdEmpresa = idEmpresa.IdEmpresa;
                    _context.SaveChanges();
                    _context.Add(tblCentros);
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
            return View(tblCentros);
        }

        // GET: tblCentros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblCentros = await _context.TblCentros.FindAsync(id);
            if (tblCentros == null)
            {
                return NotFound();
            }
            return View(tblCentros);
        }

        // POST: tblCentros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEmpresaFiscales,NombreCentro,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdEstatusRegistro,IdEmpresa")] TblCentros tblCentros)
        {
            if (id != tblCentros.IdCentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tblCentros.FechaRegistro = DateTime.Now;
                    tblCentros.NombreCentro = tblCentros.NombreCentro.ToString().ToUpper();

                    tblCentros.IdEstatusRegistro = 1;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCentros.Colonia).FirstOrDefault();
                    tblCentros.IdColonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? tblCentros.Colonia : tblCentros.Colonia;
                    tblCentros.Colonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? strColonia.Dasenta.ToUpper() : tblCentros.Colonia;
                    tblCentros.Calle = !string.IsNullOrEmpty(tblCentros.Calle) ? tblCentros.Calle.ToUpper() : tblCentros.Calle;
                    tblCentros.LocalidadMunicipio = !string.IsNullOrEmpty(tblCentros.LocalidadMunicipio) ? tblCentros.LocalidadMunicipio.ToUpper() : tblCentros.LocalidadMunicipio;
                    tblCentros.Ciudad = !string.IsNullOrEmpty(tblCentros.Ciudad) ? tblCentros.Ciudad.ToUpper() : tblCentros.Ciudad;
                    tblCentros.Estado = !string.IsNullOrEmpty(tblCentros.Estado) ? tblCentros.Estado.ToUpper() : tblCentros.Estado;
                    _context.Update(tblCentros);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblCentrosExists(tblCentros.IdCentro))
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
            return View(tblCentros);
        }

        // GET: tblCentros/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCentros = await _context.TblCentros
                .FirstOrDefaultAsync(m => m.IdCentro == id);
            if (tblCentros == null)
            {
                return NotFound();
            }

            return View(tblCentros);
        }

        // POST: tblCentros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblCentros = await _context.TblCentros.FindAsync(id);
            tblCentros.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool tblCentrosExists(Guid id)
        {
            return _context.TblCentros.Any(e => e.IdCentro == id);
        }
    }
}