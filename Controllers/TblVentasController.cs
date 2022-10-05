using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;
using AspNetCoreHero.ToastNotification.Abstractions;
using WebAdmin.ViewModels;
using System.IO;
using System.Text;


namespace WebAdmin.Controllers
{
    public class TblVentasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;


        public TblVentasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;

        }

        // GET: TblVentas
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
                                var ValidaTipoServicio = _context.CatTipoServicios.ToList();

                                if (ValidaTipoServicio.Count >= 1)
                                {
                                    ViewBag.TipoServiciosFlag = 1;
                                    var ValidaServicio = _context.TblServicio.ToList();

                                    if (ValidaServicio.Count >= 1)
                                    {
                                        ViewBag.ServiciosFlag = 1;
                                        var ValidaAlumnos = _context.TblAlumnos.ToList();

                                        if (ValidaAlumnos.Count >= 1)
                                        {
                                            ViewBag.AlumnosFlag = 1;
                                        }
                                        else
                                        {
                                            ViewBag.AlumnosFlag = 0;
                                            _notyf.Information("Favor de registrar los datos de Alumnos para la Aplicación", 5);
                                        }
                                    }
                                    else
                                    {
                                        ViewBag.TipoServicioFlag = 0;
                                        _notyf.Information("Favor de registrar los datos de Servicios para la Aplicación", 5);
                                    }
                                }
                                else
                                {
                                    ViewBag.TipoServicioFlag = 0;
                                    _notyf.Information("Favor de registrar los datos de Tipo Servicio para la Aplicación", 5);
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


            var f_user = _userService.GetUserId();
            var tblUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
            {
                var fVentasCnto = from a in _context.TblVenta
                                  join b in _context.TblAlumnos on a.IdCliente equals b.IdAlumno
                                  join c in _context.TblCentros on a.IdUCorporativoCentro equals c.IdCentro
                                  where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                  select new TblVenta
                                  {
                                      IdVenta = a.IdVenta,
                                      FolioVenta = a.FolioVenta,
                                      NombreCompletoAlumno = b.NombreAlumno + " " + b.ApellidoPaterno + " " + b.ApellidoPaterno,
                                      CentroDesc = c.NombreCentro,
                                      IdUCorporativoCentro = a.IdUCorporativoCentro,
                                      FechaRegistro = a.FechaRegistro,
                                      IdEstatusRegistro = a.IdEstatusRegistro
                                  };

                return View(await fVentasCnto.ToListAsync());
            }

            var fVentas = from a in _context.TblVenta
                          join b in _context.TblAlumnos on a.IdCliente equals b.IdAlumno
                          join c in _context.TblCentros on a.IdUCorporativoCentro equals c.IdCentro
                          select new TblVenta
                          {
                              IdVenta = a.IdVenta,
                              NumeroVenta = a.NumeroVenta,
                              NombreCompletoAlumno = b.NombreAlumno + " " + b.ApellidoPaterno + " " + b.ApellidoPaterno,
                              CentroDesc = c.NombreCentro,
                              IdUCorporativoCentro = a.IdUCorporativoCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro
                          };

            return View(await fVentas.ToListAsync());
        }
        [HttpGet]
        public ActionResult DatosVentas()
        {
            var f_user = _userService.GetUserId();
            var f_usuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (f_usuario.IdArea == 2 && f_usuario.IdPerfil == 3 && f_usuario.IdRol == 2)
            {
                var f_centro = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));

                var totalQuantity = _context.TblVenta.Where(x => x.IdUCorporativoCentro == f_centro.IdCentro)
                    .Join(_context.RelVentaProducto.Where(x => x.FechaRegistro.Month >= DateTime.Now.Month), pl => pl.IdVenta, p => p.IdVenta, (pl, p) => new { Quantity = p.TotalPrecio })
                    .ToList().Sum(x => x.Quantity);

                //   var totalQuantity = _context.TblVenta.Where(x => x.IdUCorporativoCentro == fIdCentro.IdCentro)
                //     .Join(_context.RelCompraProductos.Where(x => x.PurchaseDate >= firstDay && x.PurchaseDate < lastDay), pl => pl.PurchaseId, p => p.PurchaseId, (pl, p) => new { Quantity = pl.Quantity })
                //     .ToList().Sum(x => x.Quantity);
                // return totalQuantity;
                // var fVentas = _context.TblVenta
                //                 .Where(rr => rr.IdUCorporativoCentro == fIdCentro.IdCentro)
                //                 .SelectMany(rr => rr.RelVentaProductos)
                //                 .GroupBy(ri => ri.TotalPrecio)
                //                 .Select(g => new {
                //                 Quantity = g.Sum(ri => ri.TotalPrecio)
                //                 });

                var fTotales = from a in _context.TblVenta
                               where a.IdEstatusRegistro == 1
                               select new
                               {
                                   fRegistros = _context.TblVenta.Where(a => a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == f_centro.IdCentro).Count(),
                                   fMontos = Convert.ToDouble(totalQuantity)
                               };
                return Json(fTotales);
            }
            else
            {
                return Json(0);

            }
        }
        [HttpPost]
        public IActionResult Index([FromBody] VentasViewModel oVentaVM)
        {
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
            var nVenta = Guid.NewGuid();
            bool respuesta = false;

            if (oVentaVM != null)
            {
                foreach (var itemP in oVentaVM.RelVentaProductos)
                {
                    //item.IdRelVentaProducto = Guid.NewGuid();
                    itemP.Cantidad = 1;
                    itemP.IdUsuarioModifico = Guid.Parse(f_user);
                    itemP.FechaRegistro = DateTime.Now;
                    itemP.IdEstatusRegistro = 1;
                    itemP.IdVenta = nVenta;
                    _context.RelVentaProducto.Add(itemP);
                }
                foreach (var item in oVentaVM.RelVentaPagos)
                {
                    //item.IdRelVentaProducto = Guid.NewGuid();
                    item.IdUsuarioModifico = Guid.Parse(f_user);
                    item.FechaRegistro = DateTime.Now;
                    item.IdEstatusRegistro = 1;
                    item.IdVenta = nVenta;
                    _context.RelVentasPagos.Add(item);
                }

                TblVenta oVenta = oVentaVM.TblVentas;

                oVenta.IdCorpCent = fCorpCent;
                oVenta.IdUCorporativoCentro = fCentroCorporativo;
                oVenta.IdUsuarioModifico = Guid.Parse(f_user);
                oVenta.IdVenta = nVenta;
                oVenta.NumeroVenta = _context.TblVenta.Count() + 1;
                oVenta.IdUsuarioVenta = Guid.Parse(f_user);
                oVenta.IdCentro = fCentroCorporativo;
                oVenta.FechaRegistro = DateTime.Now;
                oVenta.IdEstatusRegistro = 1;
                _context.TblVenta.Add(oVenta);

                var pago_venta = oVentaVM.RelVentaPagos.Where(a => a.IdVenta == nVenta).Select(i => Convert.ToDouble(i.CantidadPago)).Sum();

                var addMovimiento = new TblMovimiento
                    {
                        IdMovimiento = Guid.NewGuid(),
                        IdSubTipoMovimiento = 4,
                        IdTipoMovimiento = 1,
                        MovimientoDesc = oVenta.FolioVenta,
                        MontoMovimiento = pago_venta,
                        IdUCorporativoCentro = fCentroCorporativo,
                        IdCaracteristicaMovimiento = 2,
                        IdTipoRecurso = oVentaVM.RelVentaPagos[0].IdTipoPago,
                        IdRefereciaMovimiento = nVenta,
                        FechaRegistro = DateTime.Now,
                        IdUsuarioModifico = Guid.Parse(f_user),
                        IdCorpCent = fCorpCent,
                        IdEstatusRegistro = 1
                    };
                    _context.Add(addMovimiento);
                _context.SaveChanges();

                respuesta = true;
                _notyf.Success("Registro creado con éxito", 5);
            }
            return Json(new { respuesta });
        }
        // GET: TblVentas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta.Include(u => u.RelVentaProductos)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (tblVenta == null)
            {
                return NotFound();
            }

            return View(tblVenta);
        }

        // GET: TblVentas/Create
        public IActionResult Create()
        {
            var fTipoVenta = from a in _context.CatTipoVentas
                             where a.IdEstatusRegistro == 1
                             select new CatTipoVenta
                             {
                                 IdTipoVenta = a.IdTipoVenta,
                                 TipoVentaDesc = a.TipoVentaDesc
                             };
            TempData["fTV"] = fTipoVenta.ToList();
            ViewBag.ListaTipoVenta = TempData["fTV"];

            var fTipoServicio = from a in _context.CatTipoServicios
                                where a.IdEstatusRegistro == 1
                                select new CatTipoServicio
                                {
                                    IdTipoServicio = a.IdTipoServicio,
                                    TipoServicioDesc = a.TipoServicioDesc
                                };
            TempData["fTS"] = fTipoServicio.ToList();
            ViewBag.ListaTipoServicio = TempData["fTS"];

            var fTipoPago = from a in _context.CatTipoPagos
                            where a.IdEstatusRegistro == 1
                            select new CatTipoPago
                            {
                                IdTipoPago = a.IdTipoPago,
                                TipoPagoDesc = a.TipoPagoDesc
                            };
            TempData["fTP"] = fTipoPago.ToList();
            ViewBag.ListaTipoPago = TempData["fTP"];

            var f_user = _userService.GetUserId();
            var fIdUsuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));

            if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
            {
                var fIdCentroCent = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fUsuariosCent = from a in _context.TblAlumnos
                                    where a.IdUCorporativoCentro == fIdCentroCent.IdCentro && a.IdCorpCent == 2
                                    where a.IdEstatusRegistro == 1
                                    select new
                                    {
                                        IdUsuario = a.IdAlumno,
                                        NombreUsuario = a.NombreAlumno + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno
                                    };
                TempData["fUC"] = fUsuariosCent.ToList();
                ViewBag.ListaUsuariosCentros = TempData["fUC"];
            }
            else
            {
                var fUsuariosCentros = from a in _context.TblAlumnos
                                       where a.IdEstatusRegistro == 1
                                       select new
                                       {
                                           IdUsuario = a.IdAlumno,
                                           NombreUsuario = a.NombreAlumno + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno
                                       };
                TempData["fUC"] = fUsuariosCentros.ToList();
                ViewBag.ListaUsuariosCentros = TempData["fUC"];
            }
            return View();
        }

        // POST: TblVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdUsuarioVenta,IdAlumno,Descuento,IdTipoPago,FechaAlterna")] TblVenta tblVenta, RelVentaProducto[] VentaProductos)
        {
            if (ModelState.IsValid)
            {
                return View(tblVenta);
            }
            else
            {

                var f_user = _userService.GetUserId();
                var isLoggedIn = _userService.IsAuthenticated();
                var idCorporativos = _context.TblCorporativos.FirstOrDefault();

                tblVenta.FechaRegistro = DateTime.Now;
                tblVenta.IdEstatusRegistro = 1;
                tblVenta.IdVenta = Guid.NewGuid();
                tblVenta.NumeroVenta = _context.TblVenta.Count();
                tblVenta.IdUsuarioVenta = Guid.Parse(f_user);
                tblVenta.IdCentro = idCorporativos.IdCorporativo;
                tblVenta.IdUsuarioModifico = Guid.Parse(f_user);
                tblVenta.FechaRegistro = DateTime.Now;
                tblVenta.IdEstatusRegistro = 1;
                _context.Add(tblVenta);

                var relVentaProductos = VentaProductos;
                var VentaProduct = _context.RelVentaProducto;

                // VentaProduct.IdUsuarioModifico = Guid.Parse(f_user);
                // VentaProduct.IdRelVentaProducto = Guid.NewGuid();
                // VentaProduct.FechaRegistro = DateTime.Now;
                // VentaProduct.IdEstatusRegistro = 1;
                _context.Add(VentaProductos);

                await _context.SaveChangesAsync();
                _notyf.Success("Registro creado con éxito", 5);
            }
            return RedirectToAction(nameof(Index));

        }


        // GET: TblVentas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta.FindAsync(id);
            if (tblVenta == null)
            {
                return NotFound();
            }
            return View(tblVenta);
        }

        // POST: TblVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdVenta,NumeroVenta,IdUsuarioVenta,IdCentro,IdAlumno,Descuento,IdTipoPago,FechaAlterna,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblVenta tblVenta)
        {
            if (id != tblVenta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblVentaExists(tblVenta.IdVenta))
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
            return View(tblVenta);
        }

        // GET: TblVentas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (tblVenta == null)
            {
                return NotFound();
            }

            return View(tblVenta);
        }

        // POST: TblVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var tblVenta = await _context.TblVenta.FindAsync(id);
            tblVenta.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblVentaExists(Guid id)
        {
            return _context.TblVenta.Any(e => e.IdVenta == id);
        }
    }
}
