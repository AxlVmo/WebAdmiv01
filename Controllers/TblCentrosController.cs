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
                        // var ValidaUsuarios = _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdArea == 2 && m.IdPerfil == 3 && m.IdRol == 2);
                        var ValidaUsuarios = _context.TblUsuarios.ToList();

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
                var DuplicadosEstatus = _context.TblCentros
                       .Where(s => s.NombreCentro == tblCentros.NombreCentro)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var DuplicadoUsuarioAsignado = _context.TblCentros
                      .Where(s => s.IdUsuarioControl == tblCentros.IdUsuarioControl)
                      .ToList();

                    if (DuplicadoUsuarioAsignado.Count == 0)
                    {

                        var fuser = _userService.GetUserId();
                        var isLoggedIn = _userService.IsAuthenticated();
                        tblCentros.IdUsuarioModifico = Guid.Parse(fuser);
                        var idCorporativos = _context.TblCorporativos.FirstOrDefault();
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

                        _notyf.Warning("Favor de validar, este Usurio ya esta asignado a otro centro", 5);
                        return View(tblCentros);
                    }
                }
                else
                {

                    _notyf.Warning("Favor de validar, existe una Estatus con el mismo nombre", 5);
                    return View(tblCentros);
                }


            }
            return RedirectToAction(nameof(Index));

        }

        // GET: tblCentros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

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
                    tblCentros.NombreCentro = tblCentros.NombreCentro.ToString().ToUpper();
                    tblCentros.IdEstatusRegistro = tblCentros.IdEstatusRegistro;
                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblCentros.Colonia).FirstOrDefault();
                    tblCentros.IdColonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? tblCentros.Colonia : tblCentros.Colonia;
                    tblCentros.Colonia = !string.IsNullOrEmpty(tblCentros.Colonia) ? strColonia.Dasenta.ToUpper() : tblCentros.Colonia;
                    tblCentros.Calle = !string.IsNullOrEmpty(tblCentros.Calle) ? tblCentros.Calle.ToUpper() : tblCentros.Calle;
                    tblCentros.LocalidadMunicipio = !string.IsNullOrEmpty(tblCentros.LocalidadMunicipio) ? tblCentros.LocalidadMunicipio.ToUpper() : tblCentros.LocalidadMunicipio;
                    tblCentros.Ciudad = !string.IsNullOrEmpty(tblCentros.Ciudad) ? tblCentros.Ciudad.ToUpper() : tblCentros.Ciudad;
                    tblCentros.Estado = !string.IsNullOrEmpty(tblCentros.Estado) ? tblCentros.Estado.ToUpper() : tblCentros.Estado;
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