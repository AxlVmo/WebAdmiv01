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
            var fCorp = from a in _context.TblCorporativos
                        where a.IdEstatusRegistro == 1
                        select new
                        {
                            IdCentro = a.IdCorporativo,
                            CentroDesc = a.NombreCorporativo
                        };
            var sCorpCent = fCorp.Union(fCent);
            TempData["l_centros"] = sCorpCent.ToList();
            ViewBag.ListaCorpCent = TempData["l_centros"];

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
 [HttpGet]
        public ActionResult DatosUsuarios()
        {

            var fuser = _userService.GetUserId();
            var tblUsuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(fuser));

            var fTotalesA = from a in _context.TblUsuarios
                           where a.IdEstatusRegistro == 1
                           select new
                           {
                               fRegistros = _context.TblUsuarios.Where(a => a.IdEstatusRegistro == 1 && a.IdCorporativo == fIdCentro.IdCentro).Count(),
                               fTipo = "ACTIVO"
                           };

            var fTotalesD = from a in _context.TblUsuarios
                           where a.IdEstatusRegistro == 2
                           select new
                           {
                               fRegistros = _context.TblUsuarios.Where(a => a.IdEstatusRegistro == 2 && a.IdCorporativo == fIdCentro.IdCentro).Count(),
                               fTipo = "DESACTIVO"
                           };
            var fTotales = fTotalesA.Union(fTotalesD);
            return Json(fTotales);
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
        public ActionResult RegistroUsuario()
        {
            bool vUsuario = false;
            var fUsuario = _context.TblUsuarios.ToList();
            if (fUsuario.Count != 0)
            {
                vUsuario = true;
            }
            return Json(vUsuario);
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
                    tblUsuario.Nombres = tblUsuario.Nombres.ToUpper().Trim();
                    tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper().Trim();
                    tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper().Trim();
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
            TempData["l_estatus"] = _context.CatEstatus.ToList();
            ViewBag.ListaCatEstatus = TempData["l_estatus"];

            TempData["l_area"] = _context.CatAreas.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaArea = TempData["l_area"];

            TempData["l_genero"] = _context.CatGeneros.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaGenero = TempData["l_genero"];

            TempData["l_perfil"] = _context.CatPerfiles.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaPerfil = TempData["l_perfil"];

            TempData["l_rol"] = _context.CatRoles.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaRol = TempData["l_rol"];

            TempData["l_tipos_contrataciones"] = _context.CatTipoContrataciones.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaContratacion = TempData["l_tipos_contrataciones"];

            TempData["l_formas_pagos"] = _context.CatTipoFormaPagos.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaFormaPago = TempData["l_formas_pagos"];

            TempData["l_personal_estudios"] = _context.CatPersonalEstudios.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaPersonalEstudio = TempData["l_personal_estudios"];

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

                if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
                {
                    fCorpCent = 2;
                    tblUsuario.IdCorpCent = fCorpCent;
                }
                if (tblUsuario.IdArea == 1 && tblUsuario.IdPerfil == 1 && tblUsuario.IdRol == 2)
                {
                    var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                    fCentroCorporativo = fCorp.IdCorporativo;
                    fCorpCent = 1;
                    tblUsuario.IdCorpCent = fCorpCent;
                    tblUsuario.IdCorporativo = fCentroCorporativo;
                }
                tblUsuario.IdUsuarioModifico = Guid.Parse(fuser);
                tblUsuario.FechaRegistro = DateTime.Now;
                tblUsuario.Nombres = tblUsuario.Nombres.ToUpper().Trim();
                tblUsuario.ApellidoPaterno = tblUsuario.ApellidoPaterno.ToUpper().Trim();
                tblUsuario.ApellidoMaterno = tblUsuario.ApellidoMaterno.ToUpper().Trim();
                var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblUsuario.Colonia).FirstOrDefault();
                tblUsuario.IdColonia = !string.IsNullOrEmpty(tblUsuario.Colonia) ? tblUsuario.Colonia : tblUsuario.Colonia;
                tblUsuario.Colonia = !string.IsNullOrEmpty(tblUsuario.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblUsuario.Colonia;
                tblUsuario.Calle = !string.IsNullOrEmpty(tblUsuario.Calle) ? tblUsuario.Calle.ToUpper().Trim() : tblUsuario.Calle;
                tblUsuario.LocalidadMunicipio = !string.IsNullOrEmpty(tblUsuario.LocalidadMunicipio) ? tblUsuario.LocalidadMunicipio.ToUpper().Trim() : tblUsuario.LocalidadMunicipio;
                tblUsuario.Ciudad = !string.IsNullOrEmpty(tblUsuario.Ciudad) ? tblUsuario.Ciudad.ToUpper().Trim() : tblUsuario.Ciudad;
                tblUsuario.Estado = !string.IsNullOrEmpty(tblUsuario.Estado) ? tblUsuario.Estado.ToUpper().Trim() : tblUsuario.Estado;
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