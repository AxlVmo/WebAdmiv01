using AspNetCoreHero.ToastNotification.Abstractions;
using FastReport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class TblNominasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TblNominasController(nDbContext context, INotyfService notyf, IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: TblNominas
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
                            ViewBag.CentrosFlag = 1;
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
                var fNominaCntro = from a in _context.TblNominas
                                   join b in _context.TblUsuarios on a.IdUsuarioRemuneracion equals b.IdUsuario
                                   join c in _context.CatTipoPagos on a.IdTipoPago equals c.IdTipoPago
                                   where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                   select new TblNomina
                                   {
                                       IdNomina = a.IdNomina,
                                       UsuarioAsignado = b.Nombres + " " + b.ApellidoPaterno + " " + b.ApellidoMaterno,
                                       NominaDesc = a.NominaDesc,
                                       UsuarioRemuneracion = a.UsuarioRemuneracion,
                                       TipoPagoDesc = c.TipoPagoDesc,
                                       IdUCorporativoCentro = a.IdUCorporativoCentro,
                                       FechaRegistro = a.FechaRegistro,
                                       IdEstatusRegistro = a.IdEstatusRegistro
                                   };
                return View(await fNominaCntro.ToListAsync());
            }

            var fNomina = from a in _context.TblNominas
                          join b in _context.TblUsuarios on a.IdUsuarioRemuneracion equals b.IdUsuario
                          join c in _context.CatTipoPagos on a.IdTipoPago equals c.IdTipoPago
                          select new TblNomina
                          {
                              IdNomina = a.IdNomina,
                              UsuarioAsignado = b.Nombres + " " + b.ApellidoPaterno + " " + b.ApellidoMaterno,
                              NominaDesc = a.NominaDesc,
                              UsuarioRemuneracion = a.UsuarioRemuneracion,
                              TipoPagoDesc = c.TipoPagoDesc,
                              IdUCorporativoCentro = a.IdUCorporativoCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro
                          };

            return View(await fNomina.ToListAsync());
        }
        public IActionResult ImprimirNomina(int IdNomina)
        {
            // FastReport.Utils.Config.WebMode = true;
            // Report rep = new Report();
            // string webRootPath = _webHostEnvironment.WebRootPath;
            // string contentRootPath = _webHostEnvironment.ContentRootPath;
            // string path = Path.GetFullPath("Reports/im_nomina.frx");

            // var fNomina = _context.TblNominas.ToList();
            // var dt = new DataTable();
            // dt.Load((IDataReader)fNomina);
            // DataSet n = new DataSet();
            // n.Tables.Add(dt);
            // rep.Load(path);
            // rep.SetParameterValue("p1", "1");
            // rep.SetParameterValue("p2", "2");
            // rep.RegisterData(n);
            // 
            var fNomina = _context.TblNominas.First();
            return new ViewAsPdf("ImprimirNomina", fNomina)
            {
                FileName = $" nomina_{fNomina.IdNomina.ToString()}.pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait,
                PageSize = Rotativa.AspNetCore.Options.Size.Legal
            };
            // return null;
        }
        // GET: TblNominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas
                .FirstOrDefaultAsync(m => m.IdNomina == id);
            if (TblNomina == null)
            {
                return NotFound();
            }

            return View(TblNomina);
        }

        // GET: TblNominas/Create
        public IActionResult Create()
        {
            var fuser = _userService.GetUserId();
            var fIdUsuario = _context.TblUsuarios
                .Where(a => a.IdPerfil == 3 && a.IdRol == 2 && a.IdArea == 2 && a.IdUsuario == Guid.Parse(fuser)).ToList();

            if (fIdUsuario.Count != 0)
            {
                var fIdCentroCorp = _context.TblCentros
                                      .Where(s => s.IdUsuarioControl == Guid.Parse(fuser))
                                      .FirstOrDefault();

                var fUsuariosCentrosCorp = from a in _context.TblUsuarios
                                           where a.IdCorporativo == fIdCentroCorp.IdCentro
                                           where a.IdUsuario != Guid.Parse(fuser)
                                           select new
                                           {
                                               IdUsuario = a.IdUsuario,
                                               NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                               NominaDesc = "NOMINA",
                                               UsuarioRemuneracion = a.UsuarioRemuneracion
                                           };

                ViewBag.ListaUsuariosCentros = fUsuariosCentrosCorp;
            }
            else
            {
                var fUsuariosCentros = from a in _context.TblUsuarios
                                       select new
                                       {
                                           IdUsuario = a.IdUsuario,
                                           NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                           NominaDesc = "NOMINA",
                                           UsuarioRemuneracion = a.UsuarioRemuneracion
                                       };
                ViewBag.ListaUsuariosCentros = fUsuariosCentros;
            }
            List<CatTipoContratacion> ListaContratacion = new List<CatTipoContratacion>();
            ListaContratacion = (from c in _context.CatTipoContrataciones select c).Distinct().ToList();
            ViewBag.ListaContratacion = ListaContratacion;

            List<CatTipoPago> ListaTipopago = new List<CatTipoPago>();
            ListaTipopago = (from c in _context.CatTipoPagos select c).Distinct().ToList();
            ViewBag.ListaTipopago = ListaTipopago;

            return View();
        }

        // POST: TblNominas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoNomina,IdUsuarioRemuneracion,NominaDesc,IdTipoPago,UsuarioRemuneracion")] TblNomina TblNomina)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblNominas
               .Where(s => s.NominaDesc == TblNomina.NominaDesc)
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
                    TblNomina.IdCorpCent = fCorpCent;
                    TblNomina.IdUCorporativoCentro = fCentroCorporativo;
                    TblNomina.IdUsuarioModifico = Guid.Parse(fuser);
                    TblNomina.NominaDesc = TblNomina.NominaDesc.ToString().ToUpper();
                    TblNomina.FechaRegistro = DateTime.Now;
                    TblNomina.IdEstatusRegistro = 1;
                    _context.Add(TblNomina);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoNomina con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoNomina"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblNomina.IdTipoNomina);
            return View(TblNomina);
        }

        // GET: TblNominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var fIdUsuario = _context.TblNominas
                .Where(a => a.IdNomina == id).FirstOrDefault();

            var fUsuariosCentrosCorp = from a in _context.TblUsuarios
                                       where a.IdUsuario == fIdUsuario.IdUsuarioRemuneracion
                                       select new
                                       {
                                           IdUsuario = a.IdUsuario,
                                           NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                       };

            ViewBag.ListaUsuariosCentros = fUsuariosCentrosCorp;

            List<CatTipoPago> ListaTipopago = new List<CatTipoPago>();
            ListaTipopago = (from c in _context.CatTipoPagos select c).Distinct().ToList();
            ViewBag.ListaTipopago = ListaTipopago;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas.FindAsync(id);
            if (TblNomina == null)
            {
                return NotFound();
            }
            return View(TblNomina);
        }

        // POST: TblNominas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNomina,IdTipoNomina,NominaDesc,IdUsuarioRemuneracion,IdTipoPago,UsuarioRemuneracion,IdEstatusRegistro")] TblNomina TblNomina)
        {
            if (id != TblNomina.IdNomina)
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
                    TblNomina.IdCorpCent = fCorpCent;
                    TblNomina.IdUCorporativoCentro = fCentroCorporativo;
                    TblNomina.NominaDesc = TblNomina.NominaDesc.ToString().ToUpper();
                    TblNomina.IdUsuarioModifico = Guid.Parse(fuser);
                    TblNomina.FechaRegistro = DateTime.Now;
                    TblNomina.IdEstatusRegistro = TblNomina.IdEstatusRegistro;
                    _context.Update(TblNomina);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblNominaExists(TblNomina.IdNomina))
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

        // GET: TblNominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas
                .FirstOrDefaultAsync(m => m.IdNomina == id);
            if (TblNomina == null)
            {
                return NotFound();
            }

            return View(TblNomina);
        }

        // POST: TblNominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblNomina = await _context.TblNominas.FindAsync(id);
            TblNomina.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblNominaExists(int id)
        {
            return _context.TblNominas.Any(e => e.IdNomina == id);
        }
    }
}