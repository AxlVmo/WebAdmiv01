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
    public class TblAlumnoDireccionesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblAlumnoDireccionesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblAlumnoDirecciones
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
                        var ValidaTipoDireccion = _context.CatTipoDirecciones.ToList();

                        if (ValidaTipoDireccion.Count > 1)
                        {
                            ViewBag.TipoDireccionFlag = 1;
                        }
                        else
                        {
                            ViewBag.TipoDireccionFlag = 0;
                            _notyf.Information("Favor de registrar los datos de la Tipo Dirección para la Aplicación", 5);
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
            var fTblAlumnoDirecciones = from a in _context.TblAlumnoDirecciones
                                        join b in _context.CatTipoDirecciones on a.IdTipoDireccion equals b.IdTipoDireccion
                                        join c in _context.TblAlumnos on a.IdAlumno equals c.IdAlumno
                                        select new TblAlumnoDireccion
                                        {
                                            IdAlumnoDirecciones = a.IdAlumnoDirecciones,
                                            NombreAlumno = c.NombreAlumno,
                                            TipoDireccionDesc = b.TipoDireccionDesc,
                                            CorreoElectronico = a.CorreoElectronico,
                                            Telefono = a.Telefono,
                                            FechaRegistro = a.FechaRegistro,
                                            IdEstatusRegistro = a.IdEstatusRegistro
                                        };

            return View(await fTblAlumnoDirecciones.ToListAsync());
            //return View(await _context.TblAlumnoDirecciones.ToListAsync());
        }

        // GET: TblAlumnoDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoDirecciones = await _context.TblAlumnoDirecciones
                .FirstOrDefaultAsync(m => m.IdAlumnoDirecciones == id);
            if (tblAlumnoDirecciones == null)
            {
                return NotFound();
            }

            return View(tblAlumnoDirecciones);
        }

        // GET: TblAlumnoDirecciones/Create
        public IActionResult Create()
        {
            List<TblAlumno> ListaAlumno = new List<TblAlumno>();
            ListaAlumno = (from c in _context.TblAlumnos select c).Distinct().ToList();
            ViewBag.ListaAlumno = ListaAlumno;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            return View();
        }

        // POST: TblAlumnoDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumnoDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdAlumno")] TblAlumnoDireccion tblAlumnoDirecciones)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblAlumnoDirecciones
                        .Where(s => s.Calle == tblAlumnoDirecciones.Calle && s.CodigoPostal == tblAlumnoDirecciones.CodigoPostal)
                        .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblAlumnoDirecciones.IdUsuarioModifico = Guid.Parse(fuser);
                    var fAlumno = (from c in _context.TblAlumnos where c.IdAlumno == tblAlumnoDirecciones.IdAlumno select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblAlumnoDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblAlumnoDirecciones.FechaRegistro = DateTime.Now;
                    tblAlumnoDirecciones.IdEstatusRegistro = 1;

                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblAlumnoDirecciones.Colonia).FirstOrDefault();
                    tblAlumnoDirecciones.IdColonia = !string.IsNullOrEmpty(tblAlumnoDirecciones.Colonia) ? tblAlumnoDirecciones.Colonia : tblAlumnoDirecciones.Colonia;
                    tblAlumnoDirecciones.Colonia = !string.IsNullOrEmpty(tblAlumnoDirecciones.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblAlumnoDirecciones.Colonia;
                    tblAlumnoDirecciones.Calle = !string.IsNullOrEmpty(tblAlumnoDirecciones.Calle) ? tblAlumnoDirecciones.Calle.ToUpper().Trim() : tblAlumnoDirecciones.Calle;
                    tblAlumnoDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblAlumnoDirecciones.LocalidadMunicipio) ? tblAlumnoDirecciones.LocalidadMunicipio.ToUpper().Trim() : tblAlumnoDirecciones.LocalidadMunicipio;
                    tblAlumnoDirecciones.Ciudad = !string.IsNullOrEmpty(tblAlumnoDirecciones.Ciudad) ? tblAlumnoDirecciones.Ciudad.ToUpper().Trim() : tblAlumnoDirecciones.Ciudad;
                    tblAlumnoDirecciones.Estado = !string.IsNullOrEmpty(tblAlumnoDirecciones.Estado) ? tblAlumnoDirecciones.Estado.ToUpper().Trim() : tblAlumnoDirecciones.Estado;

                    _context.SaveChanges();
                    _context.Add(tblAlumnoDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Direccion con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tblAlumnoDirecciones);
        }

        // GET: TblAlumnoDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblAlumno> ListaAlumno = new List<TblAlumno>();
            ListaAlumno = (from c in _context.TblAlumnos select c).Distinct().ToList();
            ViewBag.ListaAlumno = ListaAlumno;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoDirecciones = await _context.TblAlumnoDirecciones.FindAsync(id);
            if (tblAlumnoDirecciones == null)
            {
                return NotFound();
            }
            return View(tblAlumnoDirecciones);
        }

        // POST: TblAlumnoDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumnoDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdAlumno,IdEstatusRegistro")] TblAlumnoDireccion tblAlumnoDirecciones)
        {
            if (id != tblAlumnoDirecciones.IdAlumnoDirecciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblAlumnoDirecciones.IdUsuarioModifico = Guid.Parse(fuser);
                    var fAlumno = (from c in _context.TblAlumnos where c.IdAlumno == tblAlumnoDirecciones.IdAlumno select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblAlumnoDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblAlumnoDirecciones.FechaRegistro = DateTime.Now;
                    tblAlumnoDirecciones.IdEstatusRegistro = 1;

                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblAlumnoDirecciones.Colonia).FirstOrDefault();
                    tblAlumnoDirecciones.IdColonia = !string.IsNullOrEmpty(tblAlumnoDirecciones.Colonia) ? tblAlumnoDirecciones.Colonia : tblAlumnoDirecciones.Colonia;
                    tblAlumnoDirecciones.Colonia = !string.IsNullOrEmpty(tblAlumnoDirecciones.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblAlumnoDirecciones.Colonia;
                    tblAlumnoDirecciones.Calle = !string.IsNullOrEmpty(tblAlumnoDirecciones.Calle) ? tblAlumnoDirecciones.Calle.ToUpper().Trim() : tblAlumnoDirecciones.Calle;
                    tblAlumnoDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblAlumnoDirecciones.LocalidadMunicipio) ? tblAlumnoDirecciones.LocalidadMunicipio.ToUpper().Trim() : tblAlumnoDirecciones.LocalidadMunicipio;
                    tblAlumnoDirecciones.Ciudad = !string.IsNullOrEmpty(tblAlumnoDirecciones.Ciudad) ? tblAlumnoDirecciones.Ciudad.ToUpper().Trim() : tblAlumnoDirecciones.Ciudad;
                    tblAlumnoDirecciones.Estado = !string.IsNullOrEmpty(tblAlumnoDirecciones.Estado) ? tblAlumnoDirecciones.Estado.ToUpper().Trim() : tblAlumnoDirecciones.Estado;

                    _context.Update(tblAlumnoDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAlumnoDireccionesExists(tblAlumnoDirecciones.IdAlumnoDirecciones))
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
            return View(tblAlumnoDirecciones);
        }

        // GET: TblAlumnoDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblAlumnoDirecciones = await _context.TblAlumnoDirecciones
                .FirstOrDefaultAsync(m => m.IdAlumnoDirecciones == id);
            if (tblAlumnoDirecciones == null)
            {
                return NotFound();
            }

            return View(tblAlumnoDirecciones);
        }

        // POST: TblAlumnoDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblAlumnoDirecciones = await _context.TblAlumnoDirecciones.FindAsync(id);
            tblAlumnoDirecciones.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblAlumnoDireccionesExists(int id)
        {
            return _context.TblAlumnoDirecciones.Any(e => e.IdAlumnoDirecciones == id);
        }
    }
}