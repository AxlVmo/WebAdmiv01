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
    public class TblMovimientoCajasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblMovimientoCajasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblMovimientoCajas
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
                            ViewBag.CentroFlag = 1;
                            var ValidaTipoMovimiento = _context.CatTipoMovimientos.ToList();

                            if (ValidaTipoMovimiento.Count >= 1)
                            {
                                ViewBag.TipoMovimientoCajaFlag = 1;

                            }
                            else
                            {
                                ViewBag.TipoMovimientoCajaFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Tipo Movimiento para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.CentroFlag = 0;
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

            ViewBag.ListaCorpCent = sCorpCent.ToList();

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fMovimientoCaja = from a in _context.TblMovimientoCajas
                                      join b in _context.CatTipoMovimientos on a.IdTipoMovimientoCaja equals b.IdTipoMovimiento
                                      join c in _context.CatSubTipoMovimientos on a.IdSubTipoMovimientoCaja equals c.IdSubTipoMovimiento
                                      join d in _context.CatCaracteristicaMovimientos on a.IdCaracteristicaMovimientoCaja equals d.IdCaracteristicaMovimiento
                                      where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                      select new TblMovimientoCaja
                                      {
                                          TipoMovimientoCajaDesc = b.TipoMovimientoDesc,
                                          IdMovimientoCaja = a.IdMovimientoCaja,
                                          MovimientoCajaDesc = a.MovimientoCajaDesc,
                                          SubTipoMovimientoCajaDesc = c.SubTipoMovimientoDesc,
                                          CaracteristicaMovimientoCajaDesc = d.CaracteristicaMovimientoDesc,
                                          IdTipoRecurso = a.IdTipoRecurso,
                                          MontoMovimientoCaja = a.MontoMovimientoCaja,
                                          IdUCorporativoCentro = a.IdUCorporativoCentro,
                                          FechaRegistro = a.FechaRegistro,
                                          IdEstatusRegistro = a.IdEstatusRegistro
                                      };

                return View(await fMovimientoCaja.ToListAsync());
            }
            else
            {
                var fMovimientoCaja = from a in _context.TblMovimientoCajas
                                      join b in _context.CatTipoMovimientos on a.IdTipoMovimientoCaja equals b.IdTipoMovimiento
                                      join c in _context.CatSubTipoMovimientos on a.IdSubTipoMovimientoCaja equals c.IdSubTipoMovimiento
                                      join d in _context.CatCaracteristicaMovimientos on a.IdCaracteristicaMovimientoCaja equals d.IdCaracteristicaMovimiento
                                      select new TblMovimientoCaja
                                      {
                                          TipoMovimientoCajaDesc = b.TipoMovimientoDesc,
                                          IdMovimientoCaja = a.IdMovimientoCaja,
                                          MovimientoCajaDesc = a.MovimientoCajaDesc,
                                          SubTipoMovimientoCajaDesc = c.SubTipoMovimientoDesc,
                                          CaracteristicaMovimientoCajaDesc = d.CaracteristicaMovimientoDesc,
                                          IdTipoRecurso = a.IdTipoRecurso,
                                          MontoMovimientoCaja = a.MontoMovimientoCaja,
                                          IdUCorporativoCentro = a.IdUCorporativoCentro,
                                          FechaRegistro = a.FechaRegistro,
                                          IdEstatusRegistro = a.IdEstatusRegistro
                                      };

                return View(await fMovimientoCaja.ToListAsync());
            }


        }
        [HttpGet]
        public ActionResult DatosMovimientoCajas()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));
            int f_dia = DateTime.Now.Day;
            int f_mes = DateTime.Now.Day;
            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                var f_entradas_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                var f_entradas_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                var f_salidas_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimientoCaja == 2 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                var f_salidas_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimientoCaja == 2 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();

                var fMovimientoCajasTotales = from a in _context.CatEstatus
                                              where a.IdEstatusRegistro == 1
                                              select new
                                              {
                                                  v_caja_centro_efectivo = f_caja_centro_efectivo,
                                                  v_caja_centro_digital = f_caja_centro_digital,
                                                  v_entradas_centro_efectivo = f_entradas_centro_efectivo,
                                                  v_entradas_centro_digital = f_entradas_centro_digital,
                                                  v_salidas_centro_efectivo = f_salidas_centro_efectivo,
                                                  v_salidas_centro_digital = f_salidas_centro_digital
                                              };
                return Json(fMovimientoCajasTotales);
            }
            else
            {
                return Json(0);

            }
        }
        // GET: TblMovimientoCajas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblMovimientoCaja = await _context.TblMovimientoCajas
                .FirstOrDefaultAsync(m => m.IdMovimientoCaja == id);
            if (TblMovimientoCaja == null)
            {
                return NotFound();
            }

            return View(TblMovimientoCaja);
        }

        // GET: TblMovimientoCajas/Create
        public IActionResult Create()
        {
            var fSubTipoMovimientoCaja = from a in _context.CatSubTipoMovimientos
                                         where a.IdEstatusRegistro == 1
                                         select new CatSubTipoMovimiento
                                         {
                                             IdSubTipoMovimiento = a.IdSubTipoMovimiento,
                                             SubTipoMovimientoDesc = a.SubTipoMovimientoDesc
                                         };
            ViewBag.ListaSubTipoMovimientoCaja = fSubTipoMovimientoCaja.ToList();

            var fTipoRecurso = from a in _context.CatTipoRecursos
                               where a.IdEstatusRegistro == 1
                               select new CatTipoRecurso
                               {
                                   IdTipoRecurso = a.IdTipoRecurso,
                                   TipoRecursoDesc = a.TipoRecursoDesc
                               };
            ViewBag.ListaTipoRecurso = fTipoRecurso.ToList();

            return View();
        }

        // POST: TblMovimientoCajas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimientoCaja,IdSubTipoMovimientoCaja,IdTipoRecurso,MovimientoCajaDesc,MontoMovimientoCaja")] TblMovimientoCaja tblMovimientoCaja)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblMovimientoCajas
               .Where(s => s.MovimientoCajaDesc == tblMovimientoCaja.MovimientoCajaDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    int fTipoMovimientoCaja = 0;
                    int fCaracteristicaMovimientoCaja = 0;
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                    fCentroCorporativo = fCorp.IdCorporativo;
                    fCorpCent = 1;

                    if (tblMovimientoCaja.IdSubTipoMovimientoCaja == 1)
                    {
                        fTipoMovimientoCaja = 1;
                        fCaracteristicaMovimientoCaja = 1;
                    }
                    else
                    {
                        fTipoMovimientoCaja = 2;
                        fCaracteristicaMovimientoCaja = 2;
                    }

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;



                    }
                    tblMovimientoCaja.IdTipoMovimientoCaja = fTipoMovimientoCaja;
                    tblMovimientoCaja.IdCaracteristicaMovimientoCaja = fCaracteristicaMovimientoCaja;
                    tblMovimientoCaja.IdCorpCent = fCorpCent;
                    tblMovimientoCaja.IdUCorporativoCentro = fCentroCorporativo;
                    tblMovimientoCaja.IdUsuarioModifico = Guid.Parse(f_user);
                    tblMovimientoCaja.MovimientoCajaDesc = tblMovimientoCaja.MovimientoCajaDesc.ToString().ToUpper().Trim();
                    tblMovimientoCaja.FechaRegistro = DateTime.Now;
                    tblMovimientoCaja.IdEstatusRegistro = 1;
                    _context.Add(tblMovimientoCaja);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoMovimientoCaja con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoMovimientoCaja"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblMovimientoCaja.IdTipoMovimientoCaja);
            return View(tblMovimientoCaja);
        }

        // GET: TblMovimientoCajas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoMovimientoCaja = from a in _context.CatTipoMovimientos
                                      where a.IdEstatusRegistro == 1
                                      select new CatTipoMovimiento
                                      {
                                          IdTipoMovimiento = a.IdTipoMovimiento,
                                          TipoMovimientoDesc = a.TipoMovimientoDesc
                                      };
            TempData["fTS"] = fTipoMovimientoCaja.ToList();
            ViewBag.ListaTipoMovimientoCaja = TempData["fTS"];

            if (id == null)
            {
                return NotFound();
            }

            var TblMovimientoCaja = await _context.TblMovimientoCajas.FindAsync(id);
            if (TblMovimientoCaja == null)
            {
                return NotFound();
            }
            return View(TblMovimientoCaja);
        }

        // POST: TblMovimientoCajas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdMovimientoCaja,IdTipoMovimientoCaja,MovimientoCajaDesc,NumeroReferencia,DiaFacturacion,IdPeriodo,MontoMovimientoCaja,IdEstatusRegistro")] TblMovimientoCaja tblMovimientoCaja)
        {
            if (id != tblMovimientoCaja.IdMovimientoCaja)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    int fTipoMovimientoCaja = 0;
                    int fCaracteristicaMovimientoCaja = 0;
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (tblMovimientoCaja.IdSubTipoMovimientoCaja == 1)
                    {
                        fTipoMovimientoCaja = 1;
                        fCaracteristicaMovimientoCaja = 1;
                    }
                    else
                    {
                        fTipoMovimientoCaja = 2;
                        fCaracteristicaMovimientoCaja = 2;
                    }

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblMovimientoCaja.IdTipoMovimientoCaja = fTipoMovimientoCaja;
                    tblMovimientoCaja.IdCaracteristicaMovimientoCaja = fCaracteristicaMovimientoCaja;
                    tblMovimientoCaja.IdCorpCent = fCorpCent;
                    tblMovimientoCaja.IdUCorporativoCentro = fCentroCorporativo;
                    tblMovimientoCaja.MovimientoCajaDesc = tblMovimientoCaja.MovimientoCajaDesc.ToString().ToUpper().Trim();
                    tblMovimientoCaja.IdUsuarioModifico = Guid.Parse(f_user);
                    tblMovimientoCaja.FechaRegistro = DateTime.Now;
                    tblMovimientoCaja.IdEstatusRegistro = tblMovimientoCaja.IdEstatusRegistro;
                    _context.Update(tblMovimientoCaja);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMovimientoCajaExists(tblMovimientoCaja.IdMovimientoCaja))
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

        // GET: TblMovimientoCajas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblMovimientoCaja = await _context.TblMovimientoCajas
                .FirstOrDefaultAsync(m => m.IdMovimientoCaja == id);
            if (TblMovimientoCaja == null)
            {
                return NotFound();
            }

            return View(TblMovimientoCaja);
        }

        // POST: TblMovimientoCajas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblMovimientoCaja = await _context.TblMovimientoCajas.FindAsync(id);
            TblMovimientoCaja.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblMovimientoCajaExists(Guid id)
        {
            return _context.TblMovimientoCajas.Any(e => e.IdMovimientoCaja == id);
        }
    }
}
