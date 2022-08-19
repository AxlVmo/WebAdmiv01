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
    public class TblUsuariosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblUsuariosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblUsuarios
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
                        var ValidaGenero = _context.CatGeneros.ToList();

                        if (ValidaGenero.Count >= 1)
                        {
                            ViewBag.GeneroFlag = 1;
                            var ValidaArea = _context.CatAreas.ToList();

                            if (ValidaArea.Count >= 1)
                            {
                                ViewBag.AreaFlag = 1;
                                var ValidaPerfil = _context.CatPerfiles.ToList();

                                if (ValidaPerfil.Count >= 1)
                                {
                                    ViewBag.PerfilFlag = 1;
                                    var ValidaRol = _context.CatRoles.ToList();

                                    if (ValidaRol.Count >= 1)
                                    {
                                        ViewBag.RolFlag = 1;
                                    }
                                    else
                                    {
                                        ViewBag.RolFlag = 0;
                                        _notyf.Information("Favor de registrar los datos de Rol para la Aplicación", 5);
                                    }
                                }
                                else
                                {
                                    ViewBag.PerfilFlag = 0;
                                    _notyf.Information("Favor de registrar los datos de Perfil para la Aplicación", 5);
                                }
                            }
                            else
                            {
                                ViewBag.AreaFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Area para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.vGeneroFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Genero para la Aplicación", 5);
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
            TempData["fTS"] = fCent.ToList();
            ViewBag.ListaCorpCent = TempData["fTS"];

            var fuser = _userService.GetUserId();
            var tblUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));

            if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
            {
                var fUsuario = from a in _context.TblUsuarios
                               where a.IdCorporativo == fIdCentro.IdCentro && a.IdCorpCent == 2 && a.IdUsuario != Guid.Parse(fuser)
                               select new TblUsuario
                               {
                                   IdUsuario = a.IdUsuario,
                                   Nombres = a.Nombres,
                                   ApellidoPaterno = a.ApellidoPaterno,
                                   ApellidoMaterno = a.ApellidoMaterno,
                                   IdCorpCent = a.IdCorpCent,
                                   IdCorporativo = a.IdCorporativo,
                                   FechaRegistro = a.FechaRegistro,
                                   IdEstatusRegistro = a.IdEstatusRegistro,
                               };
                return View(await fUsuario.ToListAsync());
            }
            var UsuarioF = from a in _context.TblUsuarios
                           where a.IdUsuario != Guid.Parse(fuser)
                           select new TblUsuario
                           {
                               IdUsuario = a.IdUsuario,
                               Nombres = a.Nombres,
                               ApellidoPaterno = a.ApellidoPaterno,
                               ApellidoMaterno = a.ApellidoMaterno,
                               IdCorpCent = a.IdCorpCent,
                               IdCorporativo = a.IdCorporativo,
                               FechaRegistro = a.FechaRegistro,
                               IdEstatusRegistro = a.IdEstatusRegistro,
                           };
            return View(await UsuarioF.ToListAsync());
        }

        // GET: TblUsuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }
        [HttpGet]
        public ActionResult FiltroUsuario()
        {
            var fuser = _userService.GetUserId();
            var fUsuario = from a in _context.TblUsuarios
                           where a.IdUsuario == Guid.Parse(fuser)
                           select new TblUsuario
                           {
                               IdUsuario = a.IdUsuario,
                               IdCorporativo = a.IdCorporativo,
                               IdCorpCent = a.IdCorpCent,
                               IdPerfil = a.IdPerfil,
                               IdRol = a.IdRol,
                               IdArea = a.IdArea
                           };
            return Json(fUsuario);
        }
        // GET: TblUsuarios/Create
        public IActionResult Create()
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            List<CatArea> ListaArea = new List<CatArea>();
            ListaArea = (from c in _context.CatAreas select c).Distinct().ToList();
            ViewBag.ListaArea = ListaArea;

            List<CatGenero> ListaGenero = new List<CatGenero>();
            ListaGenero = (from c in _context.CatGeneros select c).Distinct().ToList();
            ViewBag.ListaGenero = ListaGenero;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfiles select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatRole> ListaRol = new List<CatRole>();
            ListaRol = (from c in _context.CatRoles select c).Distinct().ToList();
            ViewBag.ListaRol = ListaRol;

            return View();
        }
        [HttpGet]
        public ActionResult fUsuarioNomina(Guid id)
        {
            var fUsuarioNominaR = from a in _context.TblUsuarios
                             where a.IdUsuario == id
                             select new TblUsuario
                             {
                                 IdUsuario = a.IdUsuario,
                                 UsuarioRemuneracion = a.UsuarioRemuneracion
                             };
            return Json(fUsuarioNominaR);
        }
        // POST: TblUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdGenero,IdArea,IdPerfil,IdRol,FechaNacimiento,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso")] TblUsuario tblUsuario)
        {
            if (ModelState.IsValid)
            {
                var vDuplicados = _context.TblUsuarios
                                .Where(s => s.Nombres == tblUsuario.Nombres && s.ApellidoPaterno == tblUsuario.ApellidoPaterno && s.ApellidoMaterno == tblUsuario.ApellidoMaterno)
                                .ToList();

                if (vDuplicados.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
                    var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                    fCentroCorporativo = fCorp.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblUsuario.IdCorpCent = fCorpCent;
                    tblUsuario.IdCorporativo = fCentroCorporativo;
                    tblUsuario.IdUsuarioModifico = Guid.Parse(fuser);
                    tblUsuario.FechaRegistro = DateTime.Now;
                    tblUsuario.IdEstatusRegistro = 1;
                    tblUsuario.Nombres = tblUsuario.Nombres.ToUpper();
                    tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper();
                    tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper();
                    tblUsuario.IdUsuario = Guid.NewGuid();
                    _context.Add(tblUsuario);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe Usuario con el mismo nombre.", 5);
                }

                return RedirectToAction(nameof(Index));
            }
            return View(tblUsuario);
        }

        // GET: TblUsuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            List<CatArea> ListaArea = new List<CatArea>();
            ListaArea = (from c in _context.CatAreas select c).Distinct().ToList();
            ViewBag.ListaArea = ListaArea;

            List<CatGenero> ListaGenero = new List<CatGenero>();
            ListaGenero = (from c in _context.CatGeneros select c).Distinct().ToList();
            ViewBag.ListaGenero = ListaGenero;

            List<CatPerfil> ListaPerfil = new List<CatPerfil>();
            ListaPerfil = (from c in _context.CatPerfiles select c).Distinct().ToList();
            ViewBag.ListaPerfil = ListaPerfil;

            List<CatRole> ListaRol = new List<CatRole>();
            ListaRol = (from c in _context.CatRoles select c).Distinct().ToList();
            ViewBag.ListaRol = ListaRol;

            List<CatTipoContratacion> ListaContratacion = new List<CatTipoContratacion>();
            ListaContratacion = (from c in _context.CatTipoContrataciones select c).Distinct().ToList();
            ViewBag.ListaContratacion = ListaContratacion;

            List<CatTipoFormaPago> ListaFormaPago = new List<CatTipoFormaPago>();
            ListaFormaPago = (from c in _context.CatTipoFormaPagos select c).Distinct().ToList();
            ViewBag.ListaFormaPago = ListaFormaPago;

            List<CatPersonalEstudio> ListaPersonalEstudio = new List<CatPersonalEstudio>();
            ListaPersonalEstudio = (from c in _context.CatPersonalEstudios select c).Distinct().ToList();
            ViewBag.ListaPersonalEstudio = ListaPersonalEstudio;

            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound();
            }
            return View(tblUsuario);
        }

        // POST: TblUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdUsuario,IdGenero,IdArea,IdCorpCent,IdCorporativo,IdPerfil,IdRol,FechaNacimiento,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso,Telefono,UsuarioCurp,UsuarioRfc,UsuarioNss,IdTipoContratacion,FechaContratacion,IdTipoFormaPago,IdPersonalEstudio,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,UsuarioRemuneracion,IdEstatusRegistro")] TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuario)
            {
                return NotFound();
            }
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
                    tblUsuario.IdCorpCent = fCorpCent;
                    tblUsuario.IdCorporativo = fCentroCorporativo;
                }
                if (fIdUsuario.IdArea == 1 && fIdUsuario.IdPerfil == 1 && fIdUsuario.IdRol == 2 && tblUsuario.IdCorpCent == 1)
                {
                    var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                    fCentroCorporativo = fCorp.IdCorporativo;
                    fCorpCent = 1;
                    tblUsuario.IdCorpCent = fCorpCent;
                    tblUsuario.IdCorporativo = fCentroCorporativo;
                }
                tblUsuario.IdUsuarioModifico = Guid.Parse(fuser);
                tblUsuario.FechaRegistro = DateTime.Now;
                tblUsuario.Nombres = tblUsuario.Nombres.ToUpper();
                tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper();
                tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper();
                var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblUsuario.Colonia).FirstOrDefault();
                tblUsuario.IdColonia = !string.IsNullOrEmpty(tblUsuario.Colonia) ? tblUsuario.Colonia : tblUsuario.Colonia;
                tblUsuario.Colonia = !string.IsNullOrEmpty(tblUsuario.Colonia) ? strColonia.Dasenta.ToUpper() : tblUsuario.Colonia;
                tblUsuario.Calle = !string.IsNullOrEmpty(tblUsuario.Calle) ? tblUsuario.Calle.ToUpper() : tblUsuario.Calle;
                tblUsuario.LocalidadMunicipio = !string.IsNullOrEmpty(tblUsuario.LocalidadMunicipio) ? tblUsuario.LocalidadMunicipio.ToUpper() : tblUsuario.LocalidadMunicipio;
                tblUsuario.Ciudad = !string.IsNullOrEmpty(tblUsuario.Ciudad) ? tblUsuario.Ciudad.ToUpper() : tblUsuario.Ciudad;
                tblUsuario.Estado = !string.IsNullOrEmpty(tblUsuario.Estado) ? tblUsuario.Estado.ToUpper() : tblUsuario.Estado;
                _context.Update(tblUsuario);
                await _context.SaveChangesAsync();
                _notyf.Warning("Registro actualizado con éxito", 5);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsuarioExists(tblUsuario.IdUsuario))
                {
                    return NotFound();
                }
                else
                {

                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TblUsuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblUsuario = await _context.TblUsuarios
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (tblUsuario == null)
            {
                return NotFound();
            }

            return View(tblUsuario);
        }

        // POST: TblUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            tblUsuario.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblUsuarioExists(Guid id)
        {
            return _context.TblUsuarios.Any(e => e.IdUsuario == id);
        }
    }
}