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
    public class TblCentrosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblCentrosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: tblCentros
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

                        var ValidaUsuarios = _context.TblUsuarios.Where(m => m.IdArea == 2 && m.IdPerfil == 3 && m.IdRol == 2).ToList();

                        if (ValidaUsuarios.Count >= 1)
                        {
                            ViewBag.UsuariosFlag = 1;
                        }
                        else
                        {
                            ViewBag.UsuariosFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Usuarios para la Aplicación con perfil para los Centros", 5);
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

            var CentroF = from a in _context.TblCentros
                          join b in _context.TblUsuarios on a.IdUsuarioControl equals b.IdUsuario
                          select new TblCentro
                          {
                              IdCentro = a.IdCentro,
                              UsuarioAsignado = b.Nombres + ' ' + b.ApellidoPaterno + ' ' + b.ApellidoMaterno,
                              NombreCentro = a.NombreCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro,
                          };
            return View(await CentroF.ToListAsync());
        }
        [HttpGet]
        public ActionResult fDatosCentro()
        {
            var fuser = _userService.GetUserId();
            var tblUsuario = _context.TblUsuarios.First(f => f.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = _context.TblCentros.First(c => c.IdUsuarioControl == Guid.Parse(fuser) && c.IdEstatusRegistro == 1);
            return Json(fIdCentro);
        }
        [HttpGet]
        public ActionResult DatosPresupuesto()
        {

            var fuser = _userService.GetUserId();
            var tblUsuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(fuser));

            var fTotales = from a in _context.TblCentros
                           where a.IdEstatusRegistro == 1
                           select new
                           {
                               fRegistros = _context.TblCentros.Where(a => a.IdEstatusRegistro == 1 && a.IdCentro == fIdCentro.IdCentro).Count(),
                               fMontos = _context.TblCentros.Where(a => a.IdCentro == fIdCentro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.CentroPresupuesto)).Sum()
                           };
            return Json(fTotales);
        }
        [HttpGet]
        public ActionResult FiltroCentro(Guid id)
        {
            var fCentro = (from ta in _context.TblCentros
                           where ta.IdCentro == id
                           select ta).Distinct().ToList();

            return Json(fCentro);
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
            List<CatTipoCentro> ListaTipoCentro = new List<CatTipoCentro>();
            ListaTipoCentro = (from c in _context.CatTipoCentros select c).Distinct().ToList();
            ViewBag.ListaTipoCentro = ListaTipoCentro;

            List<CaTipotLicencia> ListaLicencia = new List<CaTipotLicencia>();
            ListaLicencia = (from c in _context.CaTipotLicencias select c).Distinct().ToList();
            ViewBag.ListaLicencia = ListaLicencia;

            var fUsuariosCentros = from a in _context.TblUsuarios
                                   where a.IdPerfil == 3 && a.IdRol == 2
                                   select new
                                   {
                                       IdUsuario = a.IdUsuario,
                                       NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,

                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];

            return View();
        }

        // POST: tblCentros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCentro,IdTipoLicencia,IdTipoCentro,NombreCentro,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,CentroPresupuesto,IdUsuarioControl")] TblCentro tblCentros)
        {
            if (ModelState.IsValid)
            {
                var vNombreCentro = _context.TblCentros
                .Where(a => a.NombreCentro == tblCentros.NombreCentro.ToUpper().Trim()).ToList();

                if (vNombreCentro.Count == 0)
                {
                    var vUsuarioAsignado = _context.TblCentros
                      .Where(s => s.IdUsuarioControl == tblCentros.IdUsuarioControl)
                      .ToList();

                    if (vUsuarioAsignado.Count == 0)
                    {
                        var fuser = _userService.GetUserId();
                        var isLoggedIn = _userService.IsAuthenticated();
                        tblCentros.IdUsuarioModifico = Guid.Parse(fuser);
                        var idCorporativos = _context.TblCorporativos.FirstOrDefault();
                        tblCentros.FechaRegistro = DateTime.Now;
                        tblCentros.NombreCentro = tblCentros.NombreCentro.ToString().ToUpper().Trim();
                        tblCentros.IdEstatusRegistro = 1;
                        var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCentros.Colonia).FirstOrDefault();
                        tblCentros.IdColonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? tblCentros.Colonia : tblCentros.Colonia;
                        tblCentros.Colonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblCentros.Colonia;
                        tblCentros.Calle = !string.IsNullOrEmpty(tblCentros.Calle) ? tblCentros.Calle.ToUpper().Trim() : tblCentros.Calle;
                        tblCentros.LocalidadMunicipio = !string.IsNullOrEmpty(tblCentros.LocalidadMunicipio) ? tblCentros.LocalidadMunicipio.ToUpper().Trim() : tblCentros.LocalidadMunicipio;
                        tblCentros.Ciudad = !string.IsNullOrEmpty(tblCentros.Ciudad) ? tblCentros.Ciudad.ToUpper().Trim() : tblCentros.Ciudad;
                        tblCentros.Estado = !string.IsNullOrEmpty(tblCentros.Estado) ? tblCentros.Estado.ToUpper().Trim() : tblCentros.Estado;
                        tblCentros.IdUsuarioControl = tblCentros.IdUsuarioControl;
                        tblCentros.IdUCorporativoCentro = idCorporativos.IdCorporativo;
                        _context.Add(tblCentros);

                        var tbluser = _context.TblUsuarios
                                                        .Where(s => s.IdUsuario == tblCentros.IdUsuarioControl)
                                                        .FirstOrDefault();
                        tbluser.IdCorpCent = 2;
                        tbluser.IdCorporativo = tblCentros.IdCentro;

                        _context.Update(tbluser);
                        await _context.SaveChangesAsync();
                        _notyf.Success("Registro creado con éxito", 5);
                    }
                    else
                    {

                        _notyf.Warning("Favor de validar, este Usuario ya esta asignado a otro centro", 5);

                    }
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Centro con el mismo nombre", 5);
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: tblCentros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            TempData["l_estatus"] = _context.CatEstatus.ToList();
            ViewBag.ListaCatEstatus = TempData["l_estatus"];

            TempData["l_tipo_centros"] = _context.CatTipoCentros.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaTipoCentro = TempData["l_tipo_centros"];

            TempData["l_tipos_licencias"] = _context.CaTipotLicencias.Where(f => f.IdEstatusRegistro == 1).ToList();
            ViewBag.ListaLicencia = TempData["l_tipos_licencias"];

            var fUsuariosCentros = from a in _context.TblUsuarios
                                   where a.IdPerfil == 3 && a.IdRol == 2
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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCentro,IdTipoLicencia,IdTipoCentro,NombreCentro,RFC,RegimenFiscal,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,CentroPresupuesto,IdEstatusRegistro,IdEmpresa,IdUsuarioControl")] TblCentro tblCentros)
        {
            if (id != tblCentros.IdCentro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblCentros.IdUsuarioModifico = Guid.Parse(fuser);
                    tblCentros.FechaRegistro = DateTime.Now;
                    tblCentros.NombreCentro = tblCentros.NombreCentro.ToString().ToUpper().Trim();
                    tblCentros.IdEstatusRegistro = tblCentros.IdEstatusRegistro;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCentros.Colonia).FirstOrDefault();
                    tblCentros.IdColonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? tblCentros.Colonia : tblCentros.Colonia;
                    tblCentros.Colonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblCentros.Colonia;
                    tblCentros.Calle = !string.IsNullOrEmpty(tblCentros.Calle) ? tblCentros.Calle.ToUpper().Trim() : tblCentros.Calle;
                    tblCentros.LocalidadMunicipio = !string.IsNullOrEmpty(tblCentros.LocalidadMunicipio) ? tblCentros.LocalidadMunicipio.ToUpper().Trim() : tblCentros.LocalidadMunicipio;
                    tblCentros.Ciudad = !string.IsNullOrEmpty(tblCentros.Ciudad) ? tblCentros.Ciudad.ToUpper().Trim() : tblCentros.Ciudad;
                    tblCentros.Estado = !string.IsNullOrEmpty(tblCentros.Estado) ? tblCentros.Estado.ToUpper().Trim() : tblCentros.Estado;
                    tblCentros.IdUsuarioControl = tblCentros.IdUsuarioControl;
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