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
using WebAdmin.ViewModels;

namespace WebAdmin.Controllers
{
    public class TblPresupuestosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblPresupuestosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblPresupuestos
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
                            var ValidaTipoPresupuesto = _context.CatTipoPresupuestos.ToList();

                            if (ValidaTipoPresupuesto.Count >= 1)
                            {
                                ViewBag.TipoPresupuestoFlag = 1;

                            }
                            else
                            {
                                ViewBag.TipoPresupuestoFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Tipo Presupuesto para la Aplicación", 5);
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
            ViewBag.ListaCorpCent = sCorpCent.ToList(); ;

            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var fPresupuestoCntro = from a in _context.TblPresupuestos
                                        join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto
                                        join c in _context.CatSubTipoPresupuestos on a.IdSubTipoPresupuesto equals c.IdSubTipoPresupuesto
                                        join d in _context.CatMeses on a.IdMes equals d.IdMes
                                        where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                        select new TblPresupuesto
                                        {
                                            IdPresupuesto = a.IdPresupuesto,
                                            MesDesc = d.MesDesc,
                                            TipoPresupuestoDesc = b.TipoPresupuestoDesc,
                                            SubTipoPresupuestoDesc = c.SubTipoPresupuestoDesc,
                                            MontoPresupuesto = a.MontoPresupuesto,
                                            IdUCorporativoCentro = a.IdUCorporativoCentro,
                                            FechaRegistro = a.FechaRegistro,
                                            IdEstatusRegistro = a.IdEstatusRegistro
                                        };
                return View(await fPresupuestoCntro.ToListAsync());
            }


            var fPresupuesto = from a in _context.TblPresupuestos
                               join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto
                               join c in _context.CatSubTipoPresupuestos on a.IdSubTipoPresupuesto equals c.IdSubTipoPresupuesto
                               join d in _context.CatMeses on a.IdMes equals d.IdMes
                               select new TblPresupuesto
                               {
                                   IdPresupuesto = a.IdPresupuesto,
                                   MesDesc = d.MesDesc,
                                   TipoPresupuestoDesc = b.TipoPresupuestoDesc,
                                   SubTipoPresupuestoDesc = c.SubTipoPresupuestoDesc,
                                   MontoPresupuesto = a.MontoPresupuesto,
                                   IdUCorporativoCentro = a.IdUCorporativoCentro,
                                   FechaRegistro = a.FechaRegistro,
                                   IdEstatusRegistro = a.IdEstatusRegistro
                               };


            return View(await fPresupuesto.ToListAsync());
        }
        [HttpGet]
        public ActionResult DatosPresupuestos()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fPresupuestosTotales = from a in _context.TblPresupuestos
                                           where a.IdEstatusRegistro == 1
                                           select new
                                           {
                                               fRegistros = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                               fMontos = _context.TblPresupuestos.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.MontoPresupuesto)).Sum()
                                           };
                return Json(fPresupuestosTotales);
            }
            else
            {
                return Json(0);

            }
        }
        [HttpGet]
        public ActionResult ProyectarPresupuestos()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fPresupuestosTotales = (from p in _context.TblPresupuestos
                                            where p.IdUCorporativoCentro == f_centro.IdCentro
                                            select p).Distinct().ToList();

                foreach (var order in fPresupuestosTotales)
                {
                    Console.WriteLine(order.PresupuestoDesc);
                }

                return Json(fPresupuestosTotales);
            }
            else
            {
                return Json(0);

            }
        }
        [HttpGet]
        public ActionResult VariacionPresupuestos()
        {

            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var fPresupuestos = new
                {
                    fR_pp_i = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro && a.IdTipoPresupuesto == 1).Count(),
                    fM_pp_i = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro && a.IdTipoPresupuesto == 1).Select(i => Convert.ToDouble(i.MontoPresupuesto)).Sum(),
                    fR_pp_g = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro && a.IdTipoPresupuesto != 1).Count(),
                    fM_pp_g = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro && a.IdTipoPresupuesto != 1).Select(i => Convert.ToDouble(i.MontoPresupuesto)).Sum(),
                    fR_pr_g = _context.RelPresupuestoPagos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                    fM_pr_g = _context.RelPresupuestoPagos.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Select(i => Convert.ToDouble(i.MontoPresupuestoReal)).Sum()
                };
                return Json(fPresupuestos);
            }
            else
            {
                var fPresupuestos = new
                {
                    fR_pp_i = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdTipoPresupuesto == 1).Count(),
                    fM_pp_i = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdTipoPresupuesto == 1).Select(i => Convert.ToDouble(i.MontoPresupuesto)).Sum(),
                    fR_pp_g = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdTipoPresupuesto != 1).Count(),
                    fM_pp_g = _context.TblPresupuestos.Where(a => a.IdEstatusRegistro == 1 && a.IdTipoPresupuesto != 1).Select(i => Convert.ToDouble(i.MontoPresupuesto)).Sum(),
                    fR_pr_g = _context.RelPresupuestoPagos.Where(a => a.IdEstatusRegistro == 1).Count(),
                    fM_pr_g = _context.RelPresupuestoPagos.Where(a => a.IdEstatusRegistro == 1).Select(i => Convert.ToDouble(i.MontoPresupuestoReal)).Sum()
                };
                return Json(fPresupuestos);

            }
        }
        [HttpGet]
        public ActionResult fPresupuestos(Guid? id)
        {
            var fPresupuestoCntro = from a in _context.TblPresupuestos
                                    join b in _context.CatMeses on a.IdMes equals b.IdMes
                                    join c in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals c.IdTipoPresupuesto
                                    join d in _context.CatSubTipoPresupuestos on a.IdSubTipoPresupuesto equals d.IdSubTipoPresupuesto
                                    where a.IdPresupuesto == id
                                    select new
                                    {
                                        IdPresupuesto = a.IdPresupuesto,
                                        TipoPresupuestoDesc = c.TipoPresupuestoDesc,
                                        SubTipoPresupuestoDesc = d.SubTipoPresupuestoDesc,
                                        PresupuestoDesc = a.PresupuestoDesc,
                                        MesDesc = b.MesDesc,
                                        DiaCorte = a.DiaCorte,
                                        MontoPresupuesto = a.MontoPresupuesto,
                                        NumeroReferencia = a.NumeroReferencia,
                                        IdUCorporativoCentro = a.IdUCorporativoCentro,
                                        FechaRegistro = a.FechaRegistro,
                                        IdEstatusRegistro = a.IdEstatusRegistro
                                    };
            return Json(fPresupuestoCntro);
        }
        [HttpGet]
        public ActionResult fPresupuestosPagos(Guid? id)
        {
            var fPresupuestoCntro = from a in _context.RelPresupuestoPagos
                                    join b in _context.CatTipoPagos on a.IdTipoPago equals b.IdTipoPago
                                    where a.IdPresupuesto == id
                                    select new RelPresupuestoPago
                                    {
                                        IdPresupuesto = a.IdPresupuesto,
                                        TipoPagoDesc = b.TipoPagoDesc,
                                        FolioPago = a.FolioPago,
                                        MontoPresupuestoReal = a.MontoPresupuestoReal,
                                        FechaRegistro = a.FechaRegistro,
                                        IdEstatusRegistro = a.IdEstatusRegistro
                                    };
            return Json(fPresupuestoCntro);
        }
        // GET: TblPresupuestos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuesto = await _context.TblPresupuestos
                .FirstOrDefaultAsync(m => m.IdPresupuesto == id);
            if (TblPresupuesto == null)
            {
                return NotFound();
            }

            return View(TblPresupuesto);
        }

        // GET: TblPresupuestos/Create
        public IActionResult Create()
        {
            var fTipoPresupuesto = from a in _context.CatTipoPresupuestos
                                   where a.IdEstatusRegistro == 1
                                   select new CatTipoPresupuesto
                                   {
                                       IdTipoPresupuesto = a.IdTipoPresupuesto,
                                       TipoPresupuestoDesc = a.TipoPresupuestoDesc
                                   };

            ViewBag.ListaTipoPresupuesto = fTipoPresupuesto.ToList();
            var fMes = from a in _context.CatMeses
                       where a.IdEstatusRegistro == 1
                       select new CatMes
                       {
                           IdMes = a.IdMes,
                           MesDesc = a.MesDesc
                       };

            ViewBag.ListaMes = fMes.ToList();
            var fSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatSubTipoPresupuesto
                                      {
                                          IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                          SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                                      };

            ViewBag.ListaSubTipoPresupuesto = fSubTipoPresupuesto.ToList();

            var fTipoServicio = from a in _context.CatTipoServicios
                                where a.IdEstatusRegistro == 1
                                select new CatTipoServicio
                                {
                                    IdTipoServicio = a.IdTipoServicio,
                                    TipoServicioDesc = a.TipoServicioDesc
                                };

            ViewBag.ListaTipoServicio = fTipoServicio.ToList();
            return View();
        }
        public IActionResult GuardaAlt([FromBody] TblPresupuesto n_presupuesto)
        {
            bool respuesta = false;
            var f_user = _userService.GetUserId();
            Guid fCentroCorporativo = Guid.Empty;
            int fCorpCent = 0;
            var isLoggedIn = _userService.IsAuthenticated();
            var fIdUsuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));
            var fCorp = _context.TblCorporativos.First();
            fCentroCorporativo = fCorp.IdCorporativo;
            fCorpCent = 1;
            if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                fCentroCorporativo = f_centro.IdCentro;
                fCorpCent = 2;
            }
            var nPresupuesto = Guid.NewGuid();
            var addMovimiento = new TblPresupuesto
            {
                IdPresupuesto = Guid.NewGuid(),
                IdTipoPresupuesto = n_presupuesto.IdTipoPresupuesto,
                IdSubTipoPresupuesto = n_presupuesto.IdSubTipoPresupuesto,
                PresupuestoDesc = n_presupuesto.PresupuestoDesc,
                IdMes = n_presupuesto.IdMes,
                NumeroReferencia = n_presupuesto.NumeroReferencia,
                DiaCorte = n_presupuesto.DiaCorte,
                MontoPresupuesto = n_presupuesto.MontoPresupuesto,
                IdUCorporativoCentro = fCentroCorporativo,
                FechaRegistro = DateTime.Now,
                IdUsuarioModifico = Guid.Parse(f_user),
                IdCorpCent = fCorpCent,
                IdEstatusRegistro = 1
            };
            _context.Add(addMovimiento);
            _context.SaveChanges();

            respuesta = true;
            return Json(new { respuesta });
        }
        // POST: TblPresupuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresupuesto,IdTipoPresupuesto,IdMes,IdSubTipoPresupuesto,PresupuestoDesc,NumeroReferencia,DiaCorte,MontoPresupuesto")] TblPresupuesto tblPresupuesto)
        {
            if (ModelState.IsValid)
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

                tblPresupuesto.IdCorpCent = fCorpCent;
                tblPresupuesto.IdUCorporativoCentro = fCentroCorporativo;
                tblPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                tblPresupuesto.PresupuestoDesc = tblPresupuesto.PresupuestoDesc.ToString().ToUpper().Trim();
                tblPresupuesto.FechaRegistro = DateTime.Now;
                tblPresupuesto.IdEstatusRegistro = 1;
                _context.Add(tblPresupuesto);


                await _context.SaveChangesAsync();
                _notyf.Success("Registro creado con éxito", 5);

                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoPresupuesto"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblPresupuesto.IdTipoPresupuesto);
            return View(tblPresupuesto);
        }

        // GET: TblPresupuestos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoPresupuesto = from a in _context.CatTipoPresupuestos
                                   where a.IdEstatusRegistro == 1
                                   select new CatTipoPresupuesto
                                   {
                                       IdTipoPresupuesto = a.IdTipoPresupuesto,
                                       TipoPresupuestoDesc = a.TipoPresupuestoDesc
                                   };

            ViewBag.ListaTipoPresupuesto = fTipoPresupuesto.ToList();
            var fMes = from a in _context.CatMeses
                       where a.IdEstatusRegistro == 1
                       select new CatMes
                       {
                           IdMes = a.IdMes,
                           MesDesc = a.MesDesc
                       };

            ViewBag.ListaMes = fMes.ToList();
            var fSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatSubTipoPresupuesto
                                      {
                                          IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                          SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                                      };

            ViewBag.ListaSubTipoPresupuesto = fSubTipoPresupuesto.ToList();

            var fTipoServicio = from a in _context.CatTipoServicios
                                where a.IdEstatusRegistro == 1
                                select new CatTipoServicio
                                {
                                    IdTipoServicio = a.IdTipoServicio,
                                    TipoServicioDesc = a.TipoServicioDesc
                                };

            ViewBag.ListaTipoServicio = fTipoServicio.ToList();
            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuesto = await _context.TblPresupuestos.FindAsync(id);
            if (TblPresupuesto == null)
            {
                return NotFound();
            }
            return View(TblPresupuesto);
        }

        public async Task<IActionResult> Payment(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            var fTipoPresupuesto = from a in _context.CatTipoPresupuestos
                                   where a.IdEstatusRegistro == 1
                                   select new CatTipoPresupuesto
                                   {
                                       IdTipoPresupuesto = a.IdTipoPresupuesto,
                                       TipoPresupuestoDesc = a.TipoPresupuestoDesc
                                   };

            ViewBag.ListaTipoPresupuesto = fTipoPresupuesto.ToList(); ;

            var fTipopago = from a in _context.CatTipoPagos
                            where a.IdEstatusRegistro == 1
                            select new CatTipoPago
                            {
                                IdTipoPago = a.IdTipoPago,
                                TipoPagoDesc = a.TipoPagoDesc
                            };

            ViewBag.ListaTipopago = fTipopago.ToList();

            var fMes = from a in _context.CatMeses
                       where a.IdEstatusRegistro == 1
                       select new CatMes
                       {
                           IdMes = a.IdMes,
                           MesDesc = a.MesDesc
                       };

            ViewBag.ListaMes = fMes.ToList();
            var fSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                      where a.IdEstatusRegistro == 1
                                      select new CatSubTipoPresupuesto
                                      {
                                          IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                          SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                                      };

            ViewBag.ListaSubTipoPresupuesto = fSubTipoPresupuesto.ToList();

            var fTipoServicio = from a in _context.CatTipoServicios
                                where a.IdEstatusRegistro == 1
                                select new CatTipoServicio
                                {
                                    IdTipoServicio = a.IdTipoServicio,
                                    TipoServicioDesc = a.TipoServicioDesc
                                };

            ViewBag.ListaTipoServicio = fTipoServicio.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuesto = await _context.TblPresupuestos.FindAsync(id);
            if (TblPresupuesto == null)
            {
                return NotFound();
            }
            return View(TblPresupuesto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Guid id, [Bind("IdPresupuesto,IdTipoPresupuesto,IdMes,IdSubTipoPresupuesto,PresupuestoDesc,NumeroReferencia,DiaCorte,MontoPresupuesto,IdTipoPago,FolioPago,MontoPresupuestoReal,Comentarios,IdEstatusRegistro")] TblPresupuesto tblPresupuesto)
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
                    tblPresupuesto.IdCorpCent = fCorpCent;
                    tblPresupuesto.IdUCorporativoCentro = fCentroCorporativo;
                    tblPresupuesto.PresupuestoDesc = tblPresupuesto.PresupuestoDesc.ToString().ToUpper().Trim();
                    tblPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    tblPresupuesto.FechaRegistro = DateTime.Now;
                    tblPresupuesto.IdEstatusRegistro = tblPresupuesto.IdEstatusRegistro;

                    var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                    int f_dia = DateTime.Now.Day;
                    int f_mes = DateTime.Now.Day;
                    var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();

                    if (tblPresupuesto.IdTipoPago == 1)
                    {
                        if (f_caja_centro_efectivo > tblPresupuesto.MontoPresupuesto)
                        {
                            var addRelPresupeustoPagos = new RelPresupuestoPago
                            {
                                IdPresupuesto = tblPresupuesto.IdPresupuesto,
                                IdTipoPago = tblPresupuesto.IdTipoPago,
                                FolioPago = tblPresupuesto.FolioPago,
                                MontoPresupuestoReal = tblPresupuesto.MontoPresupuestoReal,
                                Comentarios = tblPresupuesto.Comentarios,
                                IdUsuarioModifico = Guid.Parse(f_user),
                                IdUCorporativoCentro = fCentroCorporativo,
                                FechaRegistro = DateTime.Now,
                                IdEstatusRegistro = 1
                            };
                            _context.Add(addRelPresupeustoPagos);
                            await _context.SaveChangesAsync();
                            _notyf.Warning("Registro actualizado con éxito", 5);
                        }
                        else
                        {
                            _notyf.Warning("Sin recursos en efectivo suficientes para esta transaccion", 5);
                        }
                    }
                    else
                    {
                        if (f_caja_centro_digital > tblPresupuesto.MontoPresupuesto)
                        {
                            var addRelPresupeustoPagos = new RelPresupuestoPago
                            {
                                IdPresupuesto = tblPresupuesto.IdPresupuesto,
                                IdTipoPago = tblPresupuesto.IdTipoPago,
                                FolioPago = tblPresupuesto.FolioPago,
                                MontoPresupuestoReal = tblPresupuesto.MontoPresupuestoReal,
                                Comentarios = tblPresupuesto.Comentarios,
                                IdUsuarioModifico = Guid.Parse(f_user),
                                IdUCorporativoCentro = fCentroCorporativo,
                                FechaRegistro = DateTime.Now,
                                IdEstatusRegistro = 1
                            };
                            _context.Add(addRelPresupeustoPagos);
                            await _context.SaveChangesAsync();
                            _notyf.Warning("Registro actualizado con éxito", 5);
                        }
                        else
                        {
                            _notyf.Warning("Sin recursos en electronico suficientes para esta transaccion", 5);
                        }
                    }


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPresupuestoExists(tblPresupuesto.IdPresupuesto))
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

        // POST: TblPresupuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPresupuesto,IdTipoPresupuesto,IdMes,IdSubTipoPresupuesto,PresupuestoDesc,NumeroReferencia,DiaCorte,MontoPresupuesto,IdEstatusRegistro")] TblPresupuesto tblPresupuesto)
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
                    tblPresupuesto.IdCorpCent = fCorpCent;
                    tblPresupuesto.IdUCorporativoCentro = fCentroCorporativo;
                    tblPresupuesto.PresupuestoDesc = tblPresupuesto.PresupuestoDesc.ToString().ToUpper().Trim();
                    tblPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    tblPresupuesto.FechaRegistro = DateTime.Now;
                    tblPresupuesto.IdEstatusRegistro = tblPresupuesto.IdEstatusRegistro;

                    var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                    int f_dia = DateTime.Now.Day;
                    int f_mes = DateTime.Now.Day;
                    var f_caja_centro_efectivo = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 1 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();
                    var f_caja_centro_digital = _context.TblMovimientoCajas.Where(a => a.IdUCorporativoCentro == f_centro.IdCentro && a.IdEstatusRegistro == 1 && a.IdSubTipoMovimientoCaja == 1 && a.IdTipoRecurso == 2 && a.FechaRegistro.Day == f_dia).Select(i => Convert.ToDouble(i.MontoMovimientoCaja)).Sum();

                    _context.Update(tblPresupuesto);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPresupuestoExists(tblPresupuesto.IdPresupuesto))
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

        // GET: TblPresupuestos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblPresupuesto = await _context.TblPresupuestos
                .FirstOrDefaultAsync(m => m.IdPresupuesto == id);
            if (TblPresupuesto == null)
            {
                return NotFound();
            }

            return View(TblPresupuesto);
        }

        // POST: TblPresupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var TblPresupuesto = await _context.TblPresupuestos.FindAsync(id);
            TblPresupuesto.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblPresupuestoExists(Guid id)
        {
            return _context.TblPresupuestos.Any(e => e.IdPresupuesto == id);
        }
    }
}
