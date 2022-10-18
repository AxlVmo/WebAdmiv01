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
    public class TblSuministroesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblSuministroesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult FiltroSuministros(int id)
        {
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fServicios = from a in _context.TblPresupuestos
                                 join b in _context.CatTipoSuministros on a.IdTipoSuministro equals b.IdTipoSuministro
                                 where b.IdTipoSuministro == id && a.IdUCorporativoCentro == f_centro.IdCentro
                                 select new TblPresupuesto
                                 {
                                     IdPresupuesto = a.IdPresupuesto,
                                     PresupuestoDesc = a.PresupuestoDesc

                                 };
                return Json(fServicios);
            }
            else
            {
                return Json(0);

            }

        }
        [HttpGet]
        public ActionResult FiltroSuministro(Guid id)
        {
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fServicios = from a in _context.TblPresupuestos
                                 where a.IdPresupuesto == id
                                 select new TblPresupuesto
                                 {
                                     IdPresupuesto = a.IdPresupuesto,
                                     PresupuestoDesc = a.PresupuestoDesc,
                                     NumeroReferencia = a.NumeroReferencia,
                                     DiaCorte = a.DiaCorte,
                                     MontoPresupuesto = a.MontoPresupuesto
                                 };
                return Json(fServicios);
            }
            else
            {
                return Json(0);

            }

        }
        // GET: TblSuministros
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
                        var ValidaTipoSuministro = _context.CatTipoSuministros.ToList();

                        if (ValidaTipoSuministro.Count >= 1)
                        {
                            ViewBag.TipoSuministroFlag = 1;
                            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
                            {
                                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                                int f_dia = DateTime.Now.Day;
                                int f_mes = DateTime.Now.Day;
                                var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                                var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();

                                if (f_caja_centro_efectivo > 0 || f_caja_centro_digital > 0)
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
                            ViewBag.TipoSuministroFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Tipo Suministro para la Aplicación", 5);
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
            ViewBag.ListaCorpCent = sCorpCent.ToList(); ;


            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fSuministroCntro = from a in _context.TblSuministros
                                       join b in _context.CatTipoSuministros on a.IdTipoSuministro equals b.IdTipoSuministro
                                       where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                       select new TblSuministro
                                       {
                                           TipoSuministroDesc = b.TipoSuministroDesc,
                                           IdSuministro = a.IdSuministro,
                                           SuministroDesc = a.SuministroDesc,
                                           NumeroReferencia = a.NumeroReferencia,
                                           DiaCorte = a.DiaCorte,
                                           MontoSuministro = a.MontoSuministro,
                                           IdUCorporativoCentro = a.IdUCorporativoCentro,
                                           FechaRegistro = a.FechaRegistro,
                                           IdEstatusRegistro = a.IdEstatusRegistro
                                       };
                return View(await fSuministroCntro.ToListAsync());
            }


            var fSuministro = from a in _context.TblSuministros
                              join b in _context.CatTipoSuministros on a.IdTipoSuministro equals b.IdTipoSuministro

                              select new TblSuministro
                              {

                                  TipoSuministroDesc = b.TipoSuministroDesc,
                                  IdSuministro = a.IdSuministro,
                                  SuministroDesc = a.SuministroDesc,
                                  NumeroReferencia = a.NumeroReferencia,
                                  DiaCorte = a.DiaCorte,
                                  MontoSuministro = a.MontoSuministro,
                                  IdUCorporativoCentro = a.IdUCorporativoCentro,
                                  FechaRegistro = a.FechaRegistro,
                                  IdEstatusRegistro = a.IdEstatusRegistro
                              };


            return View(await fSuministro.ToListAsync());
        }
        [HttpGet]
        public ActionResult DatosSuministros()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));


            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fSuministrosTotales = from a in _context.TblSuministros
                                          where a.IdEstatusRegistro == 1
                                          select new
                                          {
                                              fRegistros = _context.TblSuministros.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                              fMontos = _context.TblSuministros.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.MontoSuministro)).Sum()
                                          };
                return Json(fSuministrosTotales);
            }
            else
            {
                return Json(0);

            }
        }
        // GET: TblSuministros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (TblSuministro == null)
            {
                return NotFound();
            }

            return View(TblSuministro);
        }

        // GET: TblSuministros/Create
        public IActionResult Create()
        {
            var fTipoSuministro = from a in _context.CatTipoSuministros
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoSuministro
                                  {
                                      IdTipoSuministro = a.IdTipoSuministro,
                                      TipoSuministroDesc = a.TipoSuministroDesc
                                  };

            ViewBag.ListaTipoSuministro = fTipoSuministro.ToList();

            var fTipoPago = from a in _context.CatTipoPagos
                            where a.IdEstatusRegistro == 1
                            select new CatTipoPago
                            {
                                IdTipoPago = a.IdTipoPago,
                                TipoPagoDesc = a.TipoPagoDesc
                            };

            ViewBag.ListaTipoPago = fTipoPago.ToList();
            return View();
        }

        // POST: TblSuministros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,IdTipoSuministro,SuministroDesc,NumeroReferencia,DiaCorte,IdPeriodo,MontoSuministro")] TblSuministro tblSuministro)
        {
            Guid fCentroCorporativo = Guid.Empty;
            int fCorpCent = 0;
            var f_user = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
            var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
            fCentroCorporativo = fCorp.IdCorporativo;
            fCorpCent = 1;
            int f_dia = DateTime.Now.Day;
            int f_mes = DateTime.Now.Day;
            if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
            {
                var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                fCentroCorporativo = fIdCentro.IdCentro;
                fCorpCent = 2;
            }

            var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == fCentroCorporativo && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
            var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == fCentroCorporativo && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();

            tblSuministro.IdCorpCent = fCorpCent;
            tblSuministro.IdUCorporativoCentro = fCentroCorporativo;
            tblSuministro.IdUsuarioModifico = Guid.Parse(f_user);
            tblSuministro.SuministroDesc = tblSuministro.SuministroDesc.ToString().ToUpper().Trim();
            tblSuministro.FechaRegistro = DateTime.Now;
            tblSuministro.IdEstatusRegistro = 1;
            _context.Add(tblSuministro);
            await _context.SaveChangesAsync();
            _notyf.Success("Registro creado con éxito", 5);
            return RedirectToAction(nameof(Index));

        }

        // GET: TblSuministros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoSuministro = from a in _context.CatTipoSuministros
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoSuministro
                                  {
                                      IdTipoSuministro = a.IdTipoSuministro,
                                      TipoSuministroDesc = a.TipoSuministroDesc
                                  };
            TempData["fTS"] = fTipoSuministro.ToList();
            ViewBag.ListaTipoSuministro = TempData["fTS"];

            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros.FindAsync(id);
            if (TblSuministro == null)
            {
                return NotFound();
            }
            return View(TblSuministro);
        }

        public async Task<IActionResult> Payment(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoSuministro = from a in _context.CatTipoSuministros
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoSuministro
                                  {
                                      IdTipoSuministro = a.IdTipoSuministro,
                                      TipoSuministroDesc = a.TipoSuministroDesc
                                  };

            ViewBag.ListaTipoSuministro = fTipoSuministro.ToList(); ;

            var fTipopago = from a in _context.CatTipoPagos
                            where a.IdEstatusRegistro == 1
                            select new CatTipoPago
                            {
                                IdTipoPago = a.IdTipoPago,
                                TipoPagoDesc = a.TipoPagoDesc
                            };

            ViewBag.ListaTipopago = fTipopago.ToList(); ;

            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros.FindAsync(id);
            if (TblSuministro == null)
            {
                return NotFound();
            }
            return View(TblSuministro);
        }

        // POST: TblSuministros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdSuministro,IdTipoSuministro,SuministroDesc,NumeroReferencia,DiaFacturacion,IdPeriodo,MontoSuministro,IdTipoPago,IdEstatusRegistro")] TblSuministro tblSuministro)
        {
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
                    tblSuministro.IdCorpCent = fCorpCent;
                    tblSuministro.IdUCorporativoCentro = fCentroCorporativo;
                    tblSuministro.SuministroDesc = tblSuministro.SuministroDesc.ToString().ToUpper().Trim();
                    tblSuministro.IdUsuarioModifico = Guid.Parse(f_user);
                    tblSuministro.FechaRegistro = DateTime.Now;
                    tblSuministro.IdEstatusRegistro = tblSuministro.IdEstatusRegistro;

                    var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                    int f_dia = DateTime.Now.Day;
                    int f_mes = DateTime.Now.Day;
                    var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    if (tblSuministro.IdTipoPago == 1 && f_caja_centro_efectivo == tblSuministro.MontoSuministro)
                    {

                        var addRelSuministroPago = new RelSuministroPago
                        {

                            IdTipoPago = tblSuministro.IdTipoPago,
                            CantidadPago = tblSuministro.MontoSuministro,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdEstatusRegistro = 1,
                            IdSuministro = tblSuministro.IdSuministro,
                        };
                        _context.Add(addRelSuministroPago);
                        var addMovimiento = new TblMovimientoCaja
                        {
                            IdMovimientoCaja = Guid.NewGuid(),
                            IdSubTipoMovimientoCaja = 3,
                            IdTipoMovimientoCaja = 2,
                            MovimientoCajaDesc = tblSuministro.SuministroDesc.ToString().ToUpper().Trim(),
                            MontoMovimientoCaja = tblSuministro.MontoSuministro,
                            IdUCorporativoCentro = fCentroCorporativo,
                            IdCaracteristicaMovimientoCaja = 1,
                            IdTipoRecurso = 1,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdCorpCent = fCorpCent,
                            IdEstatusRegistro = 1
                        };
                        _context.Add(addMovimiento);
                    }
                    else
                    {
                        _notyf.Error("Efectivo insuficiente para realizar el pago", 5);
                    }
                    if (tblSuministro.IdTipoPago == 2 && f_caja_centro_digital == tblSuministro.MontoSuministro)
                    {

                        var addRelSuministroPago = new RelSuministroPago
                        {

                            IdTipoPago = tblSuministro.IdTipoPago,
                            CantidadPago = tblSuministro.MontoSuministro,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdEstatusRegistro = 1,
                            IdSuministro = tblSuministro.IdSuministro,
                        };
                        _context.Add(addRelSuministroPago);
                        var addMovimiento = new TblMovimientoCaja
                        {
                            IdMovimientoCaja = Guid.NewGuid(),
                            IdSubTipoMovimientoCaja = 3,
                            IdTipoMovimientoCaja = 2,
                            MovimientoCajaDesc = tblSuministro.SuministroDesc.ToString().ToUpper().Trim(),
                            MontoMovimientoCaja = tblSuministro.MontoSuministro,
                            IdUCorporativoCentro = fCentroCorporativo,
                            IdCaracteristicaMovimientoCaja = 1,
                            IdTipoRecurso = 1,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdCorpCent = fCorpCent,
                            IdEstatusRegistro = 1
                        };
                        _context.Add(addMovimiento);
                    }
                    else
                    {
                        _notyf.Error("Banca insuficiente para realizar el pago", 5);
                    }


                    _context.Update(tblSuministro);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSuministroExists(tblSuministro.IdSuministro))
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

        // GET: TblSuministros/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (TblSuministro == null)
            {
                return NotFound();
            }

            return View(TblSuministro);
        }

        // POST: TblSuministros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblSuministro = await _context.TblSuministros.FindAsync(id);
            TblSuministro.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblSuministroExists(Guid id)
        {
            return _context.TblSuministros.Any(e => e.IdSuministro == id);
        }
    }
}
