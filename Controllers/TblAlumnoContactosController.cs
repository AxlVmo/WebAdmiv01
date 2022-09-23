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
    public class TblAlumnoContactosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblAlumnoContactosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblAlumnoContactoes
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
                    var ValidaAlumno = _context.TblAlumnos.ToList();

                    if (ValidaAlumno.Count >= 1)
                    {
                        ViewBag.AlumnoFlag = 1;
                        var ValidaPerfil = _context.CatPerfiles.ToList();

                        if (ValidaPerfil.Count >= 1)
                        {
                            ViewBag.PerfilFlag = 1;
                        }
                        else
                        {
                            ViewBag.PerfilFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Perfil para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.AlumnoFlag = 0;
                        _notyf.Information("Favor de registrar los datos de la Proveedor para la Aplicación", 5);
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
            var fTblAlumnoContacto = from a in _context.TblAlumnoContactos
                                     join b in _context.CatPerfiles on a.IdPerfil equals b.IdPerfil
                                     join c in _context.TblAlumnos on a.IdAlumno equals c.IdAlumno
                                     select new TblAlumnoContacto
                                     {
                                         IdAlumnoContacto = a.IdAlumnoContacto,
                                         NombreAlumno = c.NombreAlumno,
                                         NombreAlumnoContacto = a.NombreAlumnoContacto,
                                         PerfilDesc = b.PerfilDesc,
                                         FechaRegistro = a.FechaRegistro,
                                         IdEstatusRegistro = a.IdEstatusRegistro
                                     };

            return View(await fTblAlumnoContacto.ToListAsync());
            //return View(await _context.TblAlumnoDirecciones.ToListAsync());
        }

        [HttpGet]
        public ActionResult FiltroContactos(Guid id)
        {
            var fAlumnoContacto = (from a in _context.TblAlumnoContactos
                                   join b in _context.CatPerfiles on a.IdPerfil equals b.IdPerfil
                                   where a.IdAlumno == id
                                   select new
                                   {
                                       IdAlumnoContacto = a.IdAlumnoContacto,
                                       NombreAlumnoContacto = a.NombreAlumnoContacto,
                                   }).Distinct().ToList();

            return Json(fAlumnoContacto);
        }

        [HttpGet]
        public ActionResult FiltroDatosContactos(int id)
        {
            var fAlumnoContacto = (from a in _context.TblAlumnoContactos
                                   join b in _context.CatPerfiles on a.IdPerfil equals b.IdPerfil
                                   where a.IdAlumnoContacto == id
                                   select new
                                   {
                                       IdAlumnoContacto = a.IdAlumnoContacto,
                                       PerfilDesc = b.PerfilDesc,
                                       NombreAlumnoContacto = a.NombreAlumnoContacto,
                                       CorreoElectronicoAlumnoContacto = a.CorreoElectronico,
                                       TelefonoAlumnoContacto = a.Telefono,
                                       TelefonoMovilAlumnoContacto = a.TelefonoMovil
                                   }).Distinct().ToList();

            return Json(fAlumnoContacto);
        }

        // GET: TblAlumnoContactoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoContacto = await _context.TblAlumnoContactos
                .FirstOrDefaultAsync(m => m.IdAlumnoContacto == id);
            if (tblAlumnoContacto == null)
            {
                return NotFound();
            }

            return View(tblAlumnoContacto);
        }

        // GET: TblAlumnoContactoes/Create
        public IActionResult Create()
        {
            List<TblAlumno> ListaAlumno = new List<TblAlumno>();
            ListaAlumno = (from c in _context.TblAlumnos select c).Distinct().ToList();
            ViewBag.ListaAlumno = ListaAlumno;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfiles select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            return View();
        }

        // POST: TblAlumnoContactoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumnoContacto,NombreAlumnoContacto,CorreoElectronico,Telefono,TelefonoMovil,IdAlumno,IdPerfil")] TblAlumnoContacto tblAlumnoContacto)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblAlumnoContactos
                       .Where(s => s.NombreAlumnoContacto == tblAlumnoContacto.NombreAlumnoContacto)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblAlumnoContacto.IdUsuarioModifico = Guid.Parse(f_user);
                    var fAlumno = (from c in _context.TblAlumnos where c.IdAlumno == tblAlumnoContacto.IdAlumno select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfiles where c.IdPerfil == tblAlumnoContacto.IdPerfil select c).Distinct().ToList();
                    tblAlumnoContacto.NombreAlumnoContacto = tblAlumnoContacto.NombreAlumnoContacto.ToString().ToUpper().Trim();
                    tblAlumnoContacto.FechaRegistro = DateTime.Now;
                    tblAlumnoContacto.IdEstatusRegistro = 1;

                    _context.SaveChanges();
                    _context.Add(tblAlumnoContacto);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe un Contacto con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblAlumnoContacto);
        }

        // GET: TblAlumnoContactoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblAlumno> ListaAlumno = new List<TblAlumno>();
            ListaAlumno = (from c in _context.TblAlumnos select c).Distinct().ToList();
            ViewBag.ListaAlumno = ListaAlumno;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfiles select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoContacto = await _context.TblAlumnoContactos.FindAsync(id);
            if (tblAlumnoContacto == null)
            {
                return NotFound();
            }
            return View(tblAlumnoContacto);
        }

        // POST: TblAlumnoContactoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumnoContacto,NombreAlumnoContacto,CorreoElectronico,Telefono,TelefonoMovil,IdAlumno,IdPerfil,IdEstatusRegistro")] TblAlumnoContacto tblAlumnoContacto)
        {
            if (id != tblAlumnoContacto.IdAlumnoContacto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblAlumnoContacto.IdUsuarioModifico = Guid.Parse(f_user);
                    var fAlumno = (from c in _context.TblAlumnos where c.IdAlumno == tblAlumnoContacto.IdAlumno select c).Distinct().ToList();
                    var fPerfil = (from c in _context.CatPerfiles where c.IdPerfil == tblAlumnoContacto.IdPerfil select c).Distinct().ToList();
                    tblAlumnoContacto.NombreAlumnoContacto = tblAlumnoContacto.NombreAlumnoContacto.ToString().ToUpper().Trim();
                    tblAlumnoContacto.FechaRegistro = DateTime.Now;
                    tblAlumnoContacto.IdEstatusRegistro = 1;

                    _context.Update(tblAlumnoContacto);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAlumnoContactoExists(tblAlumnoContacto.IdAlumnoContacto))
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
            return View(tblAlumnoContacto);
        }

        // GET: TblAlumnoContactoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoContacto = await _context.TblAlumnoContactos
                .FirstOrDefaultAsync(m => m.IdAlumnoContacto == id);
            if (tblAlumnoContacto == null)
            {
                return NotFound();
            }

            return View(tblAlumnoContacto);
        }

        // POST: TblAlumnoContactoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAlumnoContacto = await _context.TblAlumnoContactos.FindAsync(id);
            tblAlumnoContacto.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblAlumnoContactoExists(int id)
        {
            return _context.TblAlumnoContactos.Any(e => e.IdAlumnoContacto == id);
        }
    }
}