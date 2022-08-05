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
    public class TblPrestamosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblPrestamosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblPrestamos
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
                        var ValidaCentro = _context.TblCentros.ToList();

                        if (ValidaCentro.Count >= 1)
                        {
                            var ValidaUsuarios = _context.TblUsuarios.ToList();

                            if (ValidaUsuarios.Count >= 1)
                            {
                                ViewBag.UsuariosFlag = 1;
                            }
                            else
                            {
                                ViewBag.UsuariosFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Usuarios para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.CentrosFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Centros para la Aplicación", 5);
                        }
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

            var fCent = from a in _context.TblCentros
                        where a.IdEstatusRegistro == 1
                        select new
                        {
                            IdCentro = a.IdCentro,
                            CentroDesc = a.NombreCentro
                        };
            var fCorp = from a in _context.TblCorporativos
                        where a.IdEstatusRegistro == 1
                        select new
                        {
                            IdCentro = a.IdCorporativo,
                            CentroDesc = a.NombreCorporativo
                        };
            var sCorpCent = fCorp.Union(fCent);
            TempData["fTS"] = sCorpCent.ToList();
            ViewBag.ListaCorpCent = TempData["fTS"];

            var fuser = _userService.GetUserId();
            var tblUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));

            if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
            {
                var fPrestamoCntro = from a in _context.TblPrestamos
                                     join b in _context.TblUsuarios on a.IdUsuarioPrestamo equals b.IdUsuario
                                     join c in _context.CatTipoPrestamos on a.IdTipoPrestamo equals c.IdTipoPrestamo
                                     join d in _context.CatPeriodosAmortizaciones on a.IdPeriodoAmortiza equals d.IdPeriodoAmortiza
                                     join e in _context.CatTipoFormaPagos on a.IdTipoFormaPago equals e.IdTipoFormaPago
                                     where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                     select new TblPrestamo
                                     {
                                         IdPrestamo = a.IdPrestamo,
                                         PrestamoDesc = a.PrestamoDesc,
                                         CantidadPrestamo = a.CantidadPrestamo,
                                         TipoPrestamoDesc = c.TipoPrestamoDesc,
                                         PeriodoAmortizaDesc = d.PeriodoAmortizaDesc,
                                         TipoFormaPagoDesc = e.TipoFormaPagoDesc,
                                         IdUCorporativoCentro = a.IdUCorporativoCentro,
                                         FechaRegistro = a.FechaRegistro,
                                         IdEstatusRegistro = a.IdEstatusRegistro
                                     };
                return View(await fPrestamoCntro.ToListAsync());
            }

            var fPrestamo = from a in _context.TblPrestamos
                            join b in _context.TblUsuarios on a.IdUsuarioPrestamo equals b.IdUsuario
                            join c in _context.CatTipoPrestamos on a.IdTipoPrestamo equals c.IdTipoPrestamo
                            join d in _context.CatPeriodosAmortizaciones on a.IdPeriodoAmortiza equals d.IdPeriodoAmortiza
                            join e in _context.CatTipoFormaPagos on a.IdTipoFormaPago equals e.IdTipoFormaPago
                            select new TblPrestamo
                            {
                                IdPrestamo = a.IdPrestamo,
                                PrestamoDesc = a.PrestamoDesc,
                                CantidadPrestamo = a.CantidadPrestamo,
                                TipoPrestamoDesc = c.TipoPrestamoDesc,
                                PeriodoAmortizaDesc = d.PeriodoAmortizaDesc,
                                TipoFormaPagoDesc = e.TipoFormaPagoDesc,
                                IdUCorporativoCentro = a.IdUCorporativoCentro,
                                FechaRegistro = a.FechaRegistro,
                                IdEstatusRegistro = a.IdEstatusRegistro
                            };

            return View(await fPrestamo.ToListAsync());
        }

        // GET: TblPrestamos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPrestamo = await _context.TblPrestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (TblPrestamo == null)
            {
                return NotFound();
            }

            return View(TblPrestamo);
        }

        // GET: TblPrestamos/Create
        public IActionResult Create()
        {
            var fuser = _userService.GetUserId();
            var fIdCentro = _context.TblCentros
                                       .Where(s => s.IdUsuarioControl == Guid.Parse(fuser))
                                       .FirstOrDefault();

            var fUsuariosCentros = from a in _context.TblUsuarios
                                   where a.IdCorporativo == fIdCentro.IdCentro
                                   select new
                                   {
                                       IdUsuario = a.IdUsuario,
                                       NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];
            return View();
        }

        // POST: TblPrestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPrestamo,PrestamoDesc,NumeroReferencia,FechaFacturacion,MontoPrestamo")] TblPrestamo TblPrestamo)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblPrestamos
               .Where(s => s.PrestamoDesc == TblPrestamo.PrestamoDesc)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    TblPrestamo.IdCorpCent = fCorpCent;
                    TblPrestamo.IdUCorporativoCentro = fCentroCorporativo;
                    TblPrestamo.IdUsuarioModifico = Guid.Parse(fuser);
                    TblPrestamo.PrestamoDesc = TblPrestamo.PrestamoDesc.ToString().ToUpper();
                    TblPrestamo.FechaRegistro = DateTime.Now;
                    TblPrestamo.IdEstatusRegistro = 1;
                    _context.Add(TblPrestamo);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoPrestamo con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoPrestamo"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblPrestamo.IdTipoPrestamo);
            return View(TblPrestamo);
        }

        // GET: TblPrestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            var fuser = _userService.GetUserId();
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
            var fUsuariosCentros = from a in _context.TblUsuarios
                                   where a.IdCorporativo == fIdCentro.IdCentro
                                   select new
                                   {
                                       IdUsuario = a.IdUsuario,
                                       NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];

            if (id == null)
            {
                return NotFound();
            }

            var TblPrestamo = await _context.TblPrestamos.FindAsync(id);
            if (TblPrestamo == null)
            {
                return NotFound();
            }
            return View(TblPrestamo);
        }

        // POST: TblPrestamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPrestamo,PrestamoDesc,NumeroReferencia,FechaFacturacion,MontoPrestamo,IdEstatusRegistro")] TblPrestamo TblPrestamo)
        {
            if (id != TblPrestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;

                    TblPrestamo.IdCorpCent = fCorpCent;
                    TblPrestamo.IdUCorporativoCentro = fCentroCorporativo;
                    TblPrestamo.PrestamoDesc = TblPrestamo.PrestamoDesc.ToString().ToUpper();
                    TblPrestamo.FechaRegistro = DateTime.Now;
                    TblPrestamo.IdEstatusRegistro = TblPrestamo.IdEstatusRegistro;
                    _context.Add(TblPrestamo);
                    _context.Update(TblPrestamo);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPrestamoExists(TblPrestamo.IdPrestamo))
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
            return View(TblPrestamo);
        }

        // GET: TblPrestamos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPrestamo = await _context.TblPrestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (TblPrestamo == null)
            {
                return NotFound();
            }

            return View(TblPrestamo);
        }

        // POST: TblPrestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblPrestamo = await _context.TblPrestamos.FindAsync(id);
            TblPrestamo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblPrestamoExists(int id)
        {
            return _context.TblPrestamos.Any(e => e.IdPrestamo == id);
        }
    }
}