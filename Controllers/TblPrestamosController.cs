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
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

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
                                 if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
                                {
                                    var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                                    double f_presupuesto = _context.TblCentros.Where(a => a.IdCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.CentroPresupuesto)).Sum();

                                    double totalQuantity = _context.TblVenta.Where(x => x.IdUCorporativoCentro == f_centro.IdCentro)
                                        .Join(_context.RelVentaProducto.Where(x => x.FechaRegistro.Month >= DateTime.Now.Month), pl => pl.IdVenta, p => p.IdVenta, (pl, p) => new { Quantity = p.TotalPrecio })
                                        .ToList().Sum(x => x.Quantity);

                                    if (totalQuantity > f_presupuesto)
                                    {
                                        ViewBag.PresupuestoFlag = 1;
                                    }
                                    else
                                    {
                                        _notyf.Information("Caja sin Fondos", 5);
                                    }
                                }
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


            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fPrestamoCntro = from a in _context.TblPrestamos
                                     join c in _context.CatTipoPrestamos on a.IdTipoPrestamo equals c.IdTipoPrestamo
                                     join d in _context.CatPeriodosAmortizaciones on a.IdPeriodoAmortiza equals d.IdPeriodoAmortiza
                                     join e in _context.CatTipoFormaPagos on a.IdTipoFormaPago equals e.IdTipoFormaPago
                                     where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                     select new TblPrestamo
                                     {
                                         IdPrestamo = a.IdPrestamo,
                                         TipoPrestamoDesc = c.TipoPrestamoDesc,
                                         CantidadPrestamo = a.CantidadPrestamo,
                                         PeriodoAmortizaDesc = d.PeriodoAmortizaDesc,
                                         TipoFormaPagoDesc = e.TipoFormaPagoDesc,
                                         IdUCorporativoCentro = a.IdUCorporativoCentro,
                                         FechaRegistro = a.FechaRegistro,
                                         IdEstatusRegistro = a.IdEstatusRegistro
                                     };
                return View(await fPrestamoCntro.ToListAsync());
            }

            var fPrestamo = from a in _context.TblPrestamos
                            join c in _context.CatTipoPrestamos on a.IdTipoPrestamo equals c.IdTipoPrestamo
                            join d in _context.CatPeriodosAmortizaciones on a.IdPeriodoAmortiza equals d.IdPeriodoAmortiza
                            join e in _context.CatTipoFormaPagos on a.IdTipoFormaPago equals e.IdTipoFormaPago
                            select new TblPrestamo
                            {
                                IdPrestamo = a.IdPrestamo,
                                TipoFormaPagoDesc = e.TipoFormaPagoDesc,
                                CantidadPrestamo = a.CantidadPrestamo,
                                TipoPrestamoDesc = c.TipoPrestamoDesc,
                                PeriodoAmortizaDesc = d.PeriodoAmortizaDesc,
                                IdUCorporativoCentro = a.IdUCorporativoCentro,
                                FechaRegistro = a.FechaRegistro,
                                IdEstatusRegistro = a.IdEstatusRegistro
                            };

            return View(await fPrestamo.ToListAsync());
        }
        [HttpGet]
        public ActionResult DatosPrestamos()
        {
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

            var fTotales = from a in _context.TblPrestamos
                                  where a.IdEstatusRegistro == 1
                                  select new
                                  {
                                      fRegistros = _context.TblPrestamos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                      fMontos = _context.TblPrestamos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.CantidadPrestamo)).Sum()
                                  };
            return Json(fTotales);
                
            }
            else
            {
            return Json(0);
            }
        }
        // GET: TblPrestamos/Details/5
        public async Task<IActionResult> Details(Guid? id)
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
            var f_user = _userService.GetUserId();
            var fIdUsuario = (from a in _context.TblUsuarios
                              where a.IdPerfil == 3 && a.IdRol == 2 && a.IdArea == 2 && a.IdUsuario == Guid.Parse(f_user)
                              select new TblUsuario
                              {
                                  IdUsuario = a.IdUsuario,
                                  IdArea = a.IdArea,
                                  IdPerfil = a.IdPerfil,
                                  IdRol = a.IdRol
                              }).ToList();

            if (fIdUsuario.Count == 1)
            {
                var fCent2 = from a in _context.TblCentros
                             where a.IdEstatusRegistro == 1
                             select new
                             {
                                 IdCentro = a.IdCentro,
                                 CentroDesc = a.NombreCentro
                             };
                TempData["fTS"] = fCent2.ToList();
                ViewBag.ListaCorpCent = TempData["fTS"];
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

            List<CatTipoPrestamo> ListaCatTipoPrestamo = new List<CatTipoPrestamo>();
            ListaCatTipoPrestamo = (from c in _context.CatTipoPrestamos select c).Distinct().ToList();
            ViewBag.ListaCatTipoPrestamo = ListaCatTipoPrestamo;

            List<CatPeriodoAmortiza> ListaCatPeriodoAmortiza = new List<CatPeriodoAmortiza>();
            ListaCatPeriodoAmortiza = (from c in _context.CatPeriodosAmortizaciones select c).Distinct().ToList();
            ViewBag.ListaCatPeriodoAmortiza = ListaCatPeriodoAmortiza;

            List<CatTipoFormaPago> ListaCatTipoFormaPago = new List<CatTipoFormaPago>();
            ListaCatTipoFormaPago = (from c in _context.CatTipoFormaPagos select c).Distinct().ToList();
            ViewBag.ListaCatTipoFormaPago = ListaCatTipoFormaPago;

            return View();
        }

        // POST: TblPrestamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPrestamo,PrestamoDesc,CantidadPrestamo,IdCentroPrestamo,IdPeriodoAmortiza,IdTipoFormaPago,Nombres,ApellidoPaterno,ApellidoMaterno,curp,ine")] TblPrestamo TblPrestamo)
        {
            var vDuplicado = _context.TblPrestamos.Where(s => s.PrestamoDesc == TblPrestamo.PrestamoDesc).ToList();
            if (vDuplicado.Count == 0)
            {
                Guid fCentroCorporativo = Guid.Empty;
                int fCorpCent = 0;
                var f_user = _userService.GetUserId();
                var isLoggedIn = _userService.IsAuthenticated();
                var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                fCentroCorporativo = fCorp.IdCorporativo;
                fCorpCent = 1;
                if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                {
                    var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                    fCentroCorporativo = fIdCentro.IdCentro;
                    fCorpCent = 2;
                }
                TblPrestamo.IdCorpCent = fCorpCent;
                TblPrestamo.IdUCorporativoCentro = fCentroCorporativo;

                TblPrestamo.Nombres = !string.IsNullOrEmpty(TblPrestamo.Nombres) ? TblPrestamo.Nombres.ToUpper().Trim() : TblPrestamo.Nombres;
                TblPrestamo.ApellidoPaterno = !string.IsNullOrEmpty(TblPrestamo.ApellidoPaterno) ? TblPrestamo.ApellidoPaterno.ToUpper().Trim() : TblPrestamo.ApellidoPaterno;
                TblPrestamo.ApellidoMaterno = !string.IsNullOrEmpty(TblPrestamo.ApellidoMaterno) ? TblPrestamo.ApellidoMaterno.ToUpper().Trim() : TblPrestamo.ApellidoMaterno;
                TblPrestamo.curp = !string.IsNullOrEmpty(TblPrestamo.curp) ? TblPrestamo.curp.ToUpper().Trim() : TblPrestamo.curp;
                TblPrestamo.ine = !string.IsNullOrEmpty(TblPrestamo.ine) ? TblPrestamo.ine.ToUpper().Trim() : TblPrestamo.ine;
                TblPrestamo.IdUsuarioModifico = Guid.Parse(f_user);
                TblPrestamo.PrestamoDesc = !string.IsNullOrEmpty(TblPrestamo.PrestamoDesc) ? TblPrestamo.PrestamoDesc.ToUpper().Trim() : TblPrestamo.PrestamoDesc;
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

        // GET: TblPrestamos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           List<CatTipoPrestamo> ListaCatTipoPrestamo = new List<CatTipoPrestamo>();
            ListaCatTipoPrestamo = (from c in _context.CatTipoPrestamos select c).Distinct().ToList();
            ViewBag.ListaCatTipoPrestamo = ListaCatTipoPrestamo;

            List<CatPeriodoAmortiza> ListaCatPeriodoAmortiza = new List<CatPeriodoAmortiza>();
            ListaCatPeriodoAmortiza = (from c in _context.CatPeriodosAmortizaciones select c).Distinct().ToList();
            ViewBag.ListaCatPeriodoAmortiza = ListaCatPeriodoAmortiza;

            List<CatTipoFormaPago> ListaCatTipoFormaPago = new List<CatTipoFormaPago>();
            ListaCatTipoFormaPago = (from c in _context.CatTipoFormaPagos select c).Distinct().ToList();
            ViewBag.ListaCatTipoFormaPago = ListaCatTipoFormaPago;

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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdTipoPrestamo,PrestamoDesc,NumeroReferencia,FechaFacturacion,MontoPrestamo,IdEstatusRegistro")] TblPrestamo TblPrestamo)
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
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;

                    TblPrestamo.IdCorpCent = fCorpCent;
                    TblPrestamo.IdUCorporativoCentro = fCentroCorporativo;
                    TblPrestamo.PrestamoDesc = TblPrestamo.PrestamoDesc.ToString().ToUpper().Trim();
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
        public async Task<IActionResult> Delete(Guid? id)
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblPrestamo = await _context.TblPrestamos.FindAsync(id);
            TblPrestamo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblPrestamoExists(Guid id)
        {
            return _context.TblPrestamos.Any(e => e.IdPrestamo == id);
        }
    }
}