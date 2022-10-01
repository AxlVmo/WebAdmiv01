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
    public class TblMovimientosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblMovimientosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblMovimientos
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
                                ViewBag.TipoMovimientoFlag = 1;

                            }
                            else
                            {
                                ViewBag.TipoMovimientoFlag = 0;
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
            TempData["fTS"] = sCorpCent.ToList();
            ViewBag.ListaCorpCent = TempData["fTS"];


            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fMovimientoCntro = from a in _context.TblMovimientos
                                       join b in _context.CatTipoMovimientos on a.IdTipoMovimiento equals b.IdTipoMovimiento
                                       where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                       select new TblMovimiento
                                       {
                                           TipoMovimientoDesc = b.TipoMovimientoDesc,
                                           IdMovimiento = a.IdMovimiento,
                                           MovimientoDesc = a.MovimientoDesc,
                                           IdSubTipoMovimiento = a.IdSubTipoMovimiento,
                                           IdCaracteristicaMovimiento = a.IdCaracteristicaMovimiento,
                                           IdTipoRecurso = a.IdTipoRecurso,
                                           MontoMovimiento = a.MontoMovimiento,
                                           IdUCorporativoCentro = a.IdUCorporativoCentro,
                                           FechaRegistro = a.FechaRegistro,
                                           IdEstatusRegistro = a.IdEstatusRegistro
                                       };
                return View(await fMovimientoCntro.ToListAsync());
            }


            var fMovimiento = from a in _context.TblMovimientos
                              join b in _context.CatTipoMovimientos on a.IdTipoMovimiento equals b.IdTipoMovimiento

                              select new TblMovimiento
                              {

                                  TipoMovimientoDesc = b.TipoMovimientoDesc,
                                  IdMovimiento = a.IdMovimiento,
                                  MovimientoDesc = a.MovimientoDesc,
                                  IdSubTipoMovimiento = a.IdSubTipoMovimiento,
                                  IdCaracteristicaMovimiento = a.IdCaracteristicaMovimiento,
                                  IdTipoRecurso = a.IdTipoRecurso,
                                  MontoMovimiento = a.MontoMovimiento,
                                  IdUCorporativoCentro = a.IdUCorporativoCentro,
                                  FechaRegistro = a.FechaRegistro,
                                  IdEstatusRegistro = a.IdEstatusRegistro
                              };


            return View(await fMovimiento.ToListAsync());
        }
        [HttpGet]
        public ActionResult DatosMovimientos()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));
            int f_dia = DateTime.Now.Day;
            int f_mes = DateTime.Now.Day;
            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var f_caja_centro_efectivo = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimiento == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();
                var f_caja_centro_digital = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimiento == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();
                var f_entradas_centro_efectivo = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimiento == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();
                var f_entradas_centro_digital = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimiento == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();
                var f_salidas_centro_efectivo = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimiento == 2 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();
                var f_salidas_centro_digital = _context.TblMovimientos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdTipoMovimiento == 2 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimiento)).Sum();

                var fMovimientosTotales = from a in _context.CatEstatus
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
                return Json(fMovimientosTotales);
            }
            else
            {
                return Json(0);

            }
        }
        // GET: TblMovimientos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblMovimiento = await _context.TblMovimientos
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (TblMovimiento == null)
            {
                return NotFound();
            }

            return View(TblMovimiento);
        }

        // GET: TblMovimientos/Create
        public IActionResult Create()
        {
            var fSubTipoMovimiento = from a in _context.CatSubTipoMovimientos
                                     where a.IdEstatusRegistro == 1
                                     select new CatSubTipoMovimiento
                                     {
                                         IdSubTipoMovimiento = a.IdSubTipoMovimiento,
                                         SubTipoMovimientoDesc = a.SubTipoMovimientoDesc
                                     };
            ViewBag.ListaSubTipoMovimiento = fSubTipoMovimiento.ToList();

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

        // POST: TblMovimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimiento,IdSubTipoMovimiento,IdTipoRecurso,MovimientoDesc,MontoMovimiento")] TblMovimiento tblMovimiento)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblMovimientos
               .Where(s => s.MovimientoDesc == tblMovimiento.MovimientoDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    int fTipoMovimiento = 0;
                    int fCaracteristicaMovimiento = 0;
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    var fCorp = await _context.TblCorporativos.FirstOrDefaultAsync();
                    fCentroCorporativo = fCorp.IdCorporativo;
                    fCorpCent = 1;

                    if (tblMovimiento.IdSubTipoMovimiento == 1)
                    {
                        fTipoMovimiento = 1;
                        fCaracteristicaMovimiento = 1;
                    }
                    else
                    {
                        fTipoMovimiento = 2;
                        fCaracteristicaMovimiento = 2;
                    }

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;



                    }
                    tblMovimiento.IdTipoMovimiento = fTipoMovimiento;
                    tblMovimiento.IdCaracteristicaMovimiento = fCaracteristicaMovimiento;
                    tblMovimiento.IdCorpCent = fCorpCent;
                    tblMovimiento.IdUCorporativoCentro = fCentroCorporativo;
                    tblMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
                    tblMovimiento.MovimientoDesc = tblMovimiento.MovimientoDesc.ToString().ToUpper().Trim();
                    tblMovimiento.FechaRegistro = DateTime.Now;
                    tblMovimiento.IdEstatusRegistro = 1;
                    _context.Add(tblMovimiento);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoMovimiento con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoMovimiento"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblMovimiento.IdTipoMovimiento);
            return View(tblMovimiento);
        }

        // GET: TblMovimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoMovimiento = from a in _context.CatTipoMovimientos
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoMovimiento
                                  {
                                      IdTipoMovimiento = a.IdTipoMovimiento,
                                      TipoMovimientoDesc = a.TipoMovimientoDesc
                                  };
            TempData["fTS"] = fTipoMovimiento.ToList();
            ViewBag.ListaTipoMovimiento = TempData["fTS"];

            if (id == null)
            {
                return NotFound();
            }

            var TblMovimiento = await _context.TblMovimientos.FindAsync(id);
            if (TblMovimiento == null)
            {
                return NotFound();
            }
            return View(TblMovimiento);
        }

        // POST: TblMovimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdMovimiento,IdTipoMovimiento,MovimientoDesc,NumeroReferencia,DiaFacturacion,IdPeriodo,MontoMovimiento,IdEstatusRegistro")] TblMovimiento tblMovimiento)
        {
            if (id != tblMovimiento.IdMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    int fTipoMovimiento = 0;
                    int fCaracteristicaMovimiento = 0;
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (tblMovimiento.IdSubTipoMovimiento == 1)
                    {
                        fTipoMovimiento = 1;
                        fCaracteristicaMovimiento = 1;
                    }
                    else
                    {
                        fTipoMovimiento = 2;
                        fCaracteristicaMovimiento = 2;
                    }

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblMovimiento.IdTipoMovimiento = fTipoMovimiento;
                    tblMovimiento.IdCaracteristicaMovimiento = fCaracteristicaMovimiento;
                    tblMovimiento.IdCorpCent = fCorpCent;
                    tblMovimiento.IdUCorporativoCentro = fCentroCorporativo;
                    tblMovimiento.MovimientoDesc = tblMovimiento.MovimientoDesc.ToString().ToUpper().Trim();
                    tblMovimiento.IdUsuarioModifico = Guid.Parse(f_user);
                    tblMovimiento.FechaRegistro = DateTime.Now;
                    tblMovimiento.IdEstatusRegistro = tblMovimiento.IdEstatusRegistro;
                    _context.Update(tblMovimiento);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMovimientoExists(tblMovimiento.IdMovimiento))
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

        // GET: TblMovimientos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblMovimiento = await _context.TblMovimientos
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (TblMovimiento == null)
            {
                return NotFound();
            }

            return View(TblMovimiento);
        }

        // POST: TblMovimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblMovimiento = await _context.TblMovimientos.FindAsync(id);
            TblMovimiento.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblMovimientoExists(Guid id)
        {
            return _context.TblMovimientos.Any(e => e.IdMovimiento == id);
        }
    }
}
