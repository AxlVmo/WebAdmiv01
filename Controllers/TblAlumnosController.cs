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
    public class TblAlumnosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblAlumnosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblAlumnos
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
            return View(await _context.TblAlumnos.ToListAsync());
        }

        [HttpGet]
        public ActionResult FiltroAlumno(Guid id)
        {
            var fAlumno = (from a in _context.TblAlumnos
                           join b in _context.TblAlumnoDirecciones on a.IdAlumno equals b.IdAlumno
                           where a.IdAlumno == id && b.IdTipoDireccion == 1
                           select new
                           {
                               IdAlumno = a.IdAlumno,
                               NombreAlumno = a.NombreAlumno,
                               CalleAlumno = b.Calle,
                               CodigoPostalAlumno = b.CodigoPostal,
                               ColoniaAlumno = b.Colonia,
                               CiudadAlumno = b.Ciudad,
                               EstadoAlumno = b.Estado,
                               CorreoElectronicoAlumno = b.CorreoElectronico,
                               TelefonoAlumno = b.Telefono
                           }).Distinct().ToList();

            return Json(fAlumno);
        }

        // GET: TblAlumnos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            return View(tblAlumno);
        }

        // GET: TblAlumnos/Create
        public IActionResult Create()
        {
            List<CatTipoAlumno> ListaTipoAlumnos = new List<CatTipoAlumno>();
            ListaTipoAlumnos = (from c in _context.CatTipoAlumnos select c).Distinct().ToList();
            ViewBag.ListaTipoAlumnos = ListaTipoAlumnos;

            return View();
        }

        // POST: TblAlumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,IdTipoAlumno,NombreAlumno,ApellidoPaterno,ApellidoMaterno")] TblAlumno tblAlumno)
        {
            var vDuplicado = _context.TblAlumnos
                                      .Where(s => s.NombreAlumno == tblAlumno.NombreAlumno && s.ApellidoPaterno == tblAlumno.ApellidoPaterno && s.ApellidoMaterno == tblAlumno.ApellidoMaterno)
                                      .ToList();

            if (vDuplicado.Count == 0)
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
                tblAlumno.IdCorpCent = fCorpCent;
                tblAlumno.IdUCorporativoCentro = fCentroCorporativo;
                tblAlumno.IdUsuarioModifico = Guid.Parse(fuser);
                tblAlumno.FechaRegistro = DateTime.Now;
                tblAlumno.ApellidoPaterno = tblAlumno.ApellidoPaterno.ToUpper();
                tblAlumno.ApellidoPaterno = tblAlumno.ApellidoMaterno.ToUpper();
                tblAlumno.IdEstatusRegistro = 1;

                _context.Add(tblAlumno);
                await _context.SaveChangesAsync();
                _notyf.Success("Registro creado con éxito", 5);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _notyf.Warning("Favor de validar, existe una Alumno con el mismo nombre", 5);

            }

            return RedirectToAction(nameof(Index));
        }

        // GET: TblAlumnos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfiles select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatRole> ListaRol = new List<CatRole>();
            ListaRol = (from c in _context.CatRoles select c).Distinct().ToList();
            ViewBag.ListaRol = ListaRol;

            if (id == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            if (tblAlumno == null)
            {
                return NotFound();
            }
            return View(tblAlumno);
        }

        // POST: TblAlumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdAlumno,IdTipoAlumno,NombreAlumno,ApellidoPaterno,ApellidoMaterno,IdEstatusRegistro")] TblAlumno tblAlumno)
        {
            if (id != tblAlumno.IdAlumno)
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
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblAlumno.IdCorpCent = fCorpCent;
                    tblAlumno.IdUCorporativoCentro = fCentroCorporativo;
                    tblAlumno.IdUsuarioModifico = Guid.Parse(fuser);
                    tblAlumno.FechaRegistro = DateTime.Now;
                    tblAlumno.NombreAlumno = tblAlumno.NombreAlumno.ToString().ToUpper();

                    _context.Update(tblAlumno);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAlumnoExists(tblAlumno.IdAlumno))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TblAlumnos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            return View(tblAlumno);
        }

        // POST: TblAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            tblAlumno.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblAlumnoExists(Guid id)
        {
            return _context.TblAlumnos.Any(e => e.IdAlumno == id);
        }
    }
}