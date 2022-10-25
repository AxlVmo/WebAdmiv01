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
    public class TblPresupuestoMovimientosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblPresupuestoMovimientosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }
        [HttpGet]
        public ActionResult FiltroPresupuestoMovimiento(int id)
        {
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fServicios = from a in _context.TblPresupuestos
                                 join b in _context.CatSubTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto
                                 where b.IdSubTipoPresupuesto == id && a.IdUCorporativoCentro == f_centro.IdCentro
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
        public ActionResult FiltroPresupuestoMovimiento(Guid id)
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
        // GET: TblPresupuestoMovimiento
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
                        var ValidaSubTipoPresupuesto = _context.CatSubTipoPresupuestos.ToList();

                        if (ValidaSubTipoPresupuesto.Count >= 1)
                        {
                            ViewBag.SubTipoPresupuestoFlag = 1;
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
                            ViewBag.SubTipoPresupuestoFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Tipo PresupuestoMovimiento para la Aplicación", 5);
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

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fPresupuestoMovimientoCntro = from a in _context.TblPresupuestoMovimientos
                                                  join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto
                                                  where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                                  select new TblPresupuestoMovimiento
                                                  {
                                                      TipoPresupuestoDesc = b.TipoPresupuestoDesc,
                                                      IdPresupuestoMovimiento = a.IdPresupuestoMovimiento,
                                                      PresupuestoMovimientoDesc = a.PresupuestoMovimientoDesc,
                                                      NumeroReferencia = a.NumeroReferencia,
                                                      DiaCorte = a.DiaCorte,
                                                      MontoPresupuestoMovimiento = a.MontoPresupuestoMovimiento,
                                                      IdUCorporativoCentro = a.IdUCorporativoCentro,
                                                      FechaRegistro = a.FechaRegistro,
                                                      IdEstatusRegistro = a.IdEstatusRegistro
                                                  };
                return View(await fPresupuestoMovimientoCntro.ToListAsync());
            }
            else
            {
                var fPresupuestoMovimiento = from a in _context.TblPresupuestoMovimientos
                                             join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto

                                             select new TblPresupuestoMovimiento
                                             {

                                                 TipoPresupuestoDesc = b.TipoPresupuestoDesc,
                                                 IdPresupuestoMovimiento = a.IdPresupuestoMovimiento,
                                                 PresupuestoMovimientoDesc = a.PresupuestoMovimientoDesc,
                                                 NumeroReferencia = a.NumeroReferencia,
                                                 DiaCorte = a.DiaCorte,
                                                 MontoPresupuestoMovimiento = a.MontoPresupuestoMovimiento,
                                                 IdUCorporativoCentro = a.IdUCorporativoCentro,
                                                 FechaRegistro = a.FechaRegistro,
                                                 IdEstatusRegistro = a.IdEstatusRegistro
                                             };


                return View(await fPresupuestoMovimiento.ToListAsync());
            }
        }
        [HttpGet]
        public ActionResult DatosPresupuestoMovimiento()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));


            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fPresupuestoMovimientoTotales = from a in _context.TblPresupuestoMovimientos
                                                    where a.IdEstatusRegistro == 1
                                                    select new
                                                    {
                                                        fRegistros = _context.TblPresupuestoMovimientos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                                        fMontos = _context.TblPresupuestoMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.MontoPresupuestoMovimiento)).Sum()
                                                    };
                return Json(fPresupuestoMovimientoTotales);
            }
            else
            {
                return Json(0);

            }
        }
        // GET: TblPresupuestoMovimiento/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuestoMovimiento = await _context.TblPresupuestoMovimientos
                .FirstOrDefaultAsync(m => m.IdPresupuestoMovimiento == id);
            if (TblPresupuestoMovimiento == null)
            {
                return NotFound();
            }

            return View(TblPresupuestoMovimiento);
        }

        // GET: TblPresupuestoMovimiento/Create
        public IActionResult Create()
        {
            var fSubTipoPresupuesto = from a in _context.CatTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatTipoPresupuesto
                                      {
                                          IdTipoPresupuesto = a.IdTipoPresupuesto,
                                          TipoPresupuestoDesc = a.TipoPresupuestoDesc
                                      };

            ViewBag.ListaSubTipoPresupuesto = fSubTipoPresupuesto.ToList();

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

        // POST: TblPresupuestoMovimiento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresupuestoMovimiento,IdSubTipoPresupuesto,PresupuestoMovimientoDesc,NumeroReferencia,DiaCorte,IdPeriodo,MontoPresupuestoMovimiento")] TblPresupuestoMovimiento tblPresupuestoMovimiento)
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

            tblPresupuestoMovimiento.IdCorpCent = fCorpCent;
            tblPresupuestoMovimiento.IdUCorporativoCentro = fCentroCorporativo;
            tblPresupuestoMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
            tblPresupuestoMovimiento.PresupuestoMovimientoDesc = tblPresupuestoMovimiento.PresupuestoMovimientoDesc.ToString().ToUpper().Trim();
            tblPresupuestoMovimiento.FechaRegistro = DateTime.Now;
            tblPresupuestoMovimiento.IdEstatusRegistro = 1;
            _context.Add(tblPresupuestoMovimiento);
            await _context.SaveChangesAsync();
            _notyf.Success("Registro creado con éxito", 5);
            return RedirectToAction(nameof(Index));

        }

        // GET: TblPresupuestoMovimiento/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatSubTipoPresupuesto
                                      {
                                          IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                          SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                                      };
            TempData["fTS"] = fSubTipoPresupuesto.ToList();
            ViewBag.ListaSubTipoPresupuesto = TempData["fTS"];

            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuestoMovimiento = await _context.TblPresupuestoMovimientos.FindAsync(id);
            if (TblPresupuestoMovimiento == null)
            {
                return NotFound();
            }
            return View(TblPresupuestoMovimiento);
        }

        public async Task<IActionResult> Payment(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatSubTipoPresupuesto
                                      {
                                          IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                          SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                                      };

            ViewBag.ListaSubTipoPresupuesto = fSubTipoPresupuesto.ToList(); ;

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

            var TblPresupuestoMovimiento = await _context.TblPresupuestoMovimientos.FindAsync(id);
            if (TblPresupuestoMovimiento == null)
            {
                return NotFound();
            }
            return View(TblPresupuestoMovimiento);
        }

        // POST: TblPresupuestoMovimiento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPresupuestoMovimiento,IdSubTipoPresupuesto,PresupuestoMovimientoDesc,NumeroReferencia,DiaFacturacion,IdPeriodo,MontoPresupuestoMovimiento,IdTipoPago,IdEstatusRegistro")] TblPresupuestoMovimiento tblPresupuestoMovimiento)
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
                    tblPresupuestoMovimiento.IdCorpCent = fCorpCent;
                    tblPresupuestoMovimiento.IdUCorporativoCentro = fCentroCorporativo;
                    tblPresupuestoMovimiento.PresupuestoMovimientoDesc = tblPresupuestoMovimiento.PresupuestoMovimientoDesc.ToString().ToUpper().Trim();
                    tblPresupuestoMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
                    tblPresupuestoMovimiento.FechaRegistro = DateTime.Now;
                    tblPresupuestoMovimiento.IdEstatusRegistro = tblPresupuestoMovimiento.IdEstatusRegistro;

                    var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                    int f_dia = DateTime.Now.Day;
                    int f_mes = DateTime.Now.Day;
                    var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    if (tblPresupuestoMovimiento.IdTipoPago == 1 && f_caja_centro_efectivo == tblPresupuestoMovimiento.MontoPresupuestoMovimiento)
                    {

                        var addRelPresupuestoMovimientoPago = new RelPresupuestoMovimientoPago
                        {

                            IdTipoPago = tblPresupuestoMovimiento.IdTipoPago,
                            CantidadPago = tblPresupuestoMovimiento.MontoPresupuestoMovimiento,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdEstatusRegistro = 1,
                            IdPresupuestoMovimiento = tblPresupuestoMovimiento.IdPresupuestoMovimiento,
                        };
                        _context.Add(addRelPresupuestoMovimientoPago);
                        var addMovimiento = new TblMovimientoCaja
                        {
                            IdMovimientoCaja = Guid.NewGuid(),
                            IdSubTipoMovimientoCaja = 3,
                            IdTipoMovimientoCaja = 2,
                            MovimientoCajaDesc = tblPresupuestoMovimiento.PresupuestoMovimientoDesc.ToString().ToUpper().Trim(),
                            MontoMovimientoCaja = tblPresupuestoMovimiento.MontoPresupuestoMovimiento,
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
                    if (tblPresupuestoMovimiento.IdTipoPago == 2 && f_caja_centro_digital == tblPresupuestoMovimiento.MontoPresupuestoMovimiento)
                    {

                        var addRelPresupuestoMovimientoPago = new RelPresupuestoMovimientoPago
                        {

                            IdTipoPago = tblPresupuestoMovimiento.IdTipoPago,
                            CantidadPago = tblPresupuestoMovimiento.MontoPresupuestoMovimiento,
                            FechaRegistro = DateTime.Now,
                            IdUsuarioModifico = Guid.Parse(f_user),
                            IdEstatusRegistro = 1,
                            IdPresupuestoMovimiento = tblPresupuestoMovimiento.IdPresupuestoMovimiento,
                        };
                        _context.Add(addRelPresupuestoMovimientoPago);
                        var addMovimiento = new TblMovimientoCaja
                        {
                            IdMovimientoCaja = Guid.NewGuid(),
                            IdSubTipoMovimientoCaja = 3,
                            IdTipoMovimientoCaja = 2,
                            MovimientoCajaDesc = tblPresupuestoMovimiento.PresupuestoMovimientoDesc.ToString().ToUpper().Trim(),
                            MontoMovimientoCaja = tblPresupuestoMovimiento.MontoPresupuestoMovimiento,
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


                    _context.Update(tblPresupuestoMovimiento);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPresupuestoMovimientoExists(tblPresupuestoMovimiento.IdPresupuestoMovimiento))
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

        // GET: TblPresupuestoMovimiento/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuestoMovimiento = await _context.TblPresupuestoMovimientos
                .FirstOrDefaultAsync(m => m.IdPresupuestoMovimiento == id);
            if (TblPresupuestoMovimiento == null)
            {
                return NotFound();
            }

            return View(TblPresupuestoMovimiento);
        }

        // POST: TblPresupuestoMovimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblPresupuestoMovimiento = await _context.TblPresupuestoMovimientos.FindAsync(id);
            TblPresupuestoMovimiento.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblPresupuestoMovimientoExists(Guid id)
        {
            return _context.TblPresupuestoMovimientos.Any(e => e.IdPresupuestoMovimiento == id);
        }
    }
}
