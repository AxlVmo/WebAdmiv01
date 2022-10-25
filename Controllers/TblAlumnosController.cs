using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // GET: TblAlumnoes
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

            var f_user = _userService.GetUserId();
            var tblAlumno = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (tblAlumno.IdArea == 2 && tblAlumno.IdPerfil == 3 && tblAlumno.IdRol == 2)
            {
                var fAlumnoCntro = from a in _context.TblAlumnos
                                   join b in _context.CatTipoAlumnos on a.IdTipoAlumno equals b.IdTipoAlumno
                                   where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                   select new TblAlumno
                                   {
                                       IdAlumno = a.IdAlumno,
                                       TipoAlumnoDesc = b.TipoAlumnoDesc,
                                       NombreAlumno = a.NombreAlumno,
                                       ApellidoPaterno = a.ApellidoPaterno,
                                       ApellidoMaterno = a.ApellidoMaterno,
                                       IdUCorporativoCentro = a.IdUCorporativoCentro,
                                       FechaRegistro = a.FechaRegistro,
                                       IdEstatusRegistro = a.IdEstatusRegistro
                                   };
                return View(await fAlumnoCntro.ToListAsync());
            }
            var fAlumno = from a in _context.TblAlumnos
                          join b in _context.CatTipoAlumnos on a.IdTipoAlumno equals b.IdTipoAlumno
                          select new TblAlumno
                          {
                              IdAlumno = a.IdAlumno,
                              TipoAlumnoDesc = b.TipoAlumnoDesc,
                              NombreAlumno = a.NombreAlumno,
                              ApellidoPaterno = a.ApellidoPaterno,
                              ApellidoMaterno = a.ApellidoMaterno,
                              IdUCorporativoCentro = a.IdUCorporativoCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro
                          };
            return View(await fAlumno.ToListAsync());
        }
        [HttpGet]
        public ActionResult sDatosAlumno(Guid id)
        {
            var f_alumno = _context.TblAlumnos.First(m => m.IdAlumno == id);
            return Json(f_alumno);
        }
        [HttpGet]
        public ActionResult DatosAlumnos()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fTotalesA = from a in _context.TblAlumnos
                                where a.IdEstatusRegistro == 1 && a.IdTipoAlumno == 1
                                select new
                                {
                                    fRegistros = _context.TblAlumnos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                    fTipo = a.IdTipoAlumno
                                };

                var fTotalesD = from a in _context.TblAlumnos
                                where a.IdEstatusRegistro == 1 && a.IdTipoAlumno == 2
                                select new
                                {
                                    fRegistros = _context.TblAlumnos.Where(a => a.IdEstatusRegistro == 2 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                    fTipo = a.IdTipoAlumno
                                };

                var fTotales = fTotalesA.Union(fTotalesD);
                return Json(fTotales);
            }
            else
            {
                return Json(0);

            }
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
        // GET: TblAlumnoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblAlumnos == null)
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

        // GET: TblAlumnoes/Create
        public IActionResult Create()
        {
            
            var fTipoAlumnos = from a in _context.CatTipoAlumnos
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoAlumno
                                  {
                                      IdTipoAlumno = a.IdTipoAlumno,
                                      TipoAlumnoDesc = a.TipoAlumnoDesc
                                  };
                                  
            ViewBag.ListaTipoAlumnos = fTipoAlumnos.ToList();

            var fNivelEscolar = from a in _context.CatNivelEscolares
                                  where a.IdEstatusRegistro == 1
                                  select new CatNivelEscolar
                                  {
                                      IdNivelEscolar = a.IdNivelEscolar,
                                      NivelEscolarDesc = a.NivelEscolarDesc
                                  };
                                  
            ViewBag.ListaNivelEscolar = fNivelEscolar.ToList();

            var fEscolaridades = from a in _context.CatEscolaridades
                                  where a.IdEstatusRegistro == 1
                                  select new CatEscolaridad
                                  {
                                      IdEscolaridad = a.IdEscolaridad,
                                      EscolaridadDesc = a.EscolaridadDesc
                                  };
                                  
            ViewBag.ListaEscolaridades = fEscolaridades.ToList();

            return View();
        }

        // POST: TblAlumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,IdTipoAlumno,NombreAlumno,ApellidoPaterno,ApellidoMaterno")] TblAlumno tblAlumno)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblAlumnos
                                      .Where(s => s.NombreAlumno == tblAlumno.NombreAlumno.ToString().ToUpper().Trim() && s.ApellidoPaterno == tblAlumno.ApellidoPaterno.ToString().ToUpper().Trim() && s.ApellidoMaterno == tblAlumno.ApellidoMaterno.ToString().ToUpper().Trim())
                                      .ToList();

                if (vDuplicado.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblAlumno.IdCorpCent = fCorpCent;
                    tblAlumno.IdUCorporativoCentro = fCentroCorporativo;
                    tblAlumno.IdUsuarioModifico = Guid.Parse(f_user);
                    tblAlumno.FechaRegistro = DateTime.Now;
                    tblAlumno.NombreAlumno = tblAlumno.NombreAlumno.ToString().ToUpper().Trim();
                    tblAlumno.ApellidoPaterno = tblAlumno.ApellidoPaterno.ToUpper().Trim();
                    tblAlumno.ApellidoMaterno = tblAlumno.ApellidoMaterno.ToUpper().Trim();
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
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TblAlumnoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatTipoAlumno> ListaTipoAlumnos = new List<CatTipoAlumno>();
            ListaTipoAlumnos = (from c in _context.CatTipoAlumnos select c).Distinct().ToList();
            ViewBag.ListaTipoAlumnos = ListaTipoAlumnos;

            List<CatGenero> ListaGenero = new List<CatGenero>();
            ListaGenero = (from c in _context.CatGeneros select c).Distinct().ToList();
            ViewBag.ListaGenero = ListaGenero;

            List<CatNivelEscolar> ListaNivelEscolar = new List<CatNivelEscolar>();
            ListaNivelEscolar = (from c in _context.CatNivelEscolares select c).Distinct().ToList();
            ViewBag.ListaNivelEscolar = ListaNivelEscolar;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null || _context.TblAlumnos == null)
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

        // POST: TblAlumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdAlumno,IdTipoAlumno,IdGenero,FechaNacimiento,IdNivelEscolar,NombreTutor,ApellidoPaternoTutor,ApellidoMaternoTutor,NombreAlumno,ApellidoPaterno,ApellidoMaterno,IdUCorporativoCentro,IdCorpCent,CorreoAcceso,Telefono,TelefonoTutor,AlumnoCurp,AlumnoGrupoSanguineo,ClaveAcceso,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,IdUsuarioModifico,FechaRegistro,FechaAcceso,IdEstatusRegistro")] TblAlumno tblAlumno)
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
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblAlumno.IdCorpCent = fCorpCent;
                    tblAlumno.IdUCorporativoCentro = fCentroCorporativo;
                    tblAlumno.IdUsuarioModifico = Guid.Parse(f_user);
                    tblAlumno.FechaRegistro = DateTime.Now;
                    tblAlumno.NombreAlumno = tblAlumno.NombreAlumno.ToString().ToUpper().Trim();
                    tblAlumno.ApellidoPaterno = tblAlumno.ApellidoPaterno.ToUpper().Trim();
                    tblAlumno.ApellidoMaterno = tblAlumno.ApellidoMaterno.ToUpper().Trim();
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblAlumno.Colonia).FirstOrDefault();
                    tblAlumno.IdColonia = !string.IsNullOrEmpty(tblAlumno.Colonia) ? tblAlumno.Colonia : tblAlumno.Colonia;
                    tblAlumno.Colonia = !string.IsNullOrEmpty(tblAlumno.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblAlumno.Colonia;
                    tblAlumno.Calle = !string.IsNullOrEmpty(tblAlumno.Calle) ? tblAlumno.Calle.ToUpper().Trim() : tblAlumno.Calle;
                    tblAlumno.LocalidadMunicipio = !string.IsNullOrEmpty(tblAlumno.LocalidadMunicipio) ? tblAlumno.LocalidadMunicipio.ToUpper().Trim() : tblAlumno.LocalidadMunicipio;
                    tblAlumno.Ciudad = !string.IsNullOrEmpty(tblAlumno.Ciudad) ? tblAlumno.Ciudad.ToUpper().Trim() : tblAlumno.Ciudad;
                    tblAlumno.Estado = !string.IsNullOrEmpty(tblAlumno.Estado) ? tblAlumno.Estado.ToUpper().Trim() : tblAlumno.Estado;

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
                return RedirectToAction(nameof(Index));
            }
            return View(tblAlumno);
        }

        // GET: TblAlumnoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblAlumnos == null)
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

        // POST: TblAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblAlumnos == null)
            {
                return Problem("Entity set 'nDbContext.TblAlumnos'  is null.");
            }
            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            if (tblAlumno != null)
            {

                tblAlumno.IdEstatusRegistro = 2;
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                _notyf.Error("Registro desactivado con éxito", 5);
                return RedirectToAction(nameof(Index));
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAlumnoExists(Guid id)
        {
            return _context.TblAlumnos.Any(e => e.IdAlumno == id);
        }
    }
}
