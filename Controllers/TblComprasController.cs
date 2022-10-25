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
    public class TblComprasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;


        public TblComprasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblCompras
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
                        var ValidaTipoCompra = _context.CatTipoCompras.ToList();

                        if (ValidaTipoCompra.Count >= 1)
                        {
                            ViewBag.TipoCompraFlag = 1;
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
                                        var ValidaProveedorCompras = _context.TblProveedorCompras.ToLookup(f => f.IdUCorporativoCentro == f_centro.IdCentro);

                                        if (ValidaProveedorCompras.Count >= 1)
                                        {
                                            ViewBag.ProveedorComprasFlag = 1;
                                        }
                                        else
                                        {
                                            ViewBag.ProveedorComprasFlag = 0;
                                            _notyf.Information("Favor de registrar proveedores de compras para la Aplicación", 5);
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
                            ViewBag.TipoCompraFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Tipo Compra para la Aplicación", 5);
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
                var fCompraCntro = from a in _context.TblCompras
                                   join b in _context.CatTipoCompras on a.IdTipoCompra equals b.IdTipoCompra
                                   where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                   select new TblCompra
                                   {
                                       TipoCompraDesc = b.TipoCompraDesc,
                                       IdCompra = a.IdCompra,
                                       CompraDesc = a.CompraDesc,
                                       IdUCorporativoCentro = a.IdUCorporativoCentro,
                                       FechaRegistro = a.FechaRegistro,
                                       IdEstatusRegistro = a.IdEstatusRegistro
                                   };
                return View(await fCompraCntro.ToListAsync());
            }


            var fCompra = from a in _context.TblCompras
                          join b in _context.CatTipoCompras on a.IdTipoCompra equals b.IdTipoCompra

                          select new TblCompra
                          {

                              TipoCompraDesc = b.TipoCompraDesc,
                              IdCompra = a.IdCompra,
                              CompraDesc = a.CompraDesc,
                              IdUCorporativoCentro = a.IdUCorporativoCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro
                          };


            return View(await fCompra.ToListAsync());
        }

        // GET: TblCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            return View(tblCompra);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult Index([FromBody] ComprasViewModel oCompraVM)
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
            var nCompra = Guid.NewGuid();
            bool respuesta = false;

            if (oCompraVM != null)
            {
                foreach (var itemP in oCompraVM.RelCompraProductos)
                {
                    //item.IdRelCompraProducto = Guid.NewGuid();
                    itemP.Cantidad = 1;
                    itemP.IdUsuarioModifico = Guid.Parse(f_user);
                    itemP.FechaRegistro = DateTime.Now;
                    itemP.IdEstatusRegistro = 1;
                    itemP.IdCompra = nCompra;
                    _context.RelCompraProductos.Add(itemP);
                }
                foreach (var item in oCompraVM.RelCompraPagos)
                {
                    //item.IdRelVentaProducto = Guid.NewGuid();
                    item.IdUsuarioModifico = Guid.Parse(f_user);
                    item.FechaRegistro = DateTime.Now;
                    item.IdEstatusRegistro = 1;
                    item.IdCompra = nCompra;
                    _context.RelCompraPagos.Add(item);
                }
                TblCompra oCompra = oCompraVM.TblCompras;

                oCompra.IdCorpCent = fCorpCent;
                oCompra.IdUCorporativoCentro = fCentroCorporativo;
                oCompra.IdUsuarioModifico = Guid.Parse(f_user);
                oCompra.IdCompra = nCompra;
                oCompra.FechaRegistro = DateTime.Now;
                oCompra.IdEstatusRegistro = 1;
                _context.TblCompras.Add(oCompra);

                var pago_Compra = oCompraVM.RelCompraPagos.Where(a => a.IdCompra == nCompra).Select(i => Convert.ToDouble(i.CantidadPago)).Sum();

                var addMovimiento = new TblMovimientoCaja
                {
                    IdMovimientoCaja = Guid.NewGuid(),
                    IdSubTipoMovimientoCaja = 4,
                    IdTipoMovimientoCaja = 1,
                    MovimientoCajaDesc = oCompra.FolioCompra.ToString(),
                    MontoMovimientoCaja = pago_Compra,
                    IdUCorporativoCentro = fCentroCorporativo,
                    IdCaracteristicaMovimientoCaja = 2,
                    IdTipoRecurso = oCompraVM.RelCompraPagos[0].IdTipoPago,
                    IdRefereciaMovimientoCaja = nCompra,
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
            else
            {
                respuesta = false;
                return Json(new { respuesta });
            }

        }
        // GET: TblCompras/Create
        public IActionResult Create()
        {
            var fTipoCompra = from a in _context.CatTipoCompras
                              where a.IdEstatusRegistro == 1
                              select new CatTipoCompra
                              {
                                  IdTipoCompra = a.IdTipoCompra,
                                  TipoCompraDesc = a.TipoCompraDesc
                              };

            var fTipoPago = from a in _context.CatTipoPagos
                            where a.IdEstatusRegistro == 1
                            select new CatTipoPago
                            {
                                IdTipoPago = a.IdTipoPago,
                                TipoPagoDesc = a.TipoPagoDesc
                            };

            ViewBag.ListaTipoPago = fTipoPago.ToList();

            ViewBag.ListaTipoCompra = fTipoCompra.ToList();

            var f_user = _userService.GetUserId();
            var fIdUsuario = _context.TblUsuarios.First(m => m.IdUsuario == Guid.Parse(f_user));
            if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
            {
                var fIdCentroCent = _context.TblCentros.First(m => m.IdUsuarioControl == Guid.Parse(f_user));
                var fProveedorCompra = from a in _context.TblProveedorCompras
                                       where a.IdEstatusRegistro == 1 && a.IdUCorporativoCentro == fIdCentroCent.IdCentro
                                       select new TblProveedorCompra
                                       {
                                           IdProveedorCompra = a.IdProveedorCompra,
                                           NombreProveedorCompra = a.NombreProveedorCompra
                                       };

                ViewBag.ListaProveedorCompra = fProveedorCompra.ToList();
            }
            else
            {
                var fProveedorCompra = from a in _context.TblProveedorCompras
                                       where a.IdEstatusRegistro == 1
                                       select new TblProveedorCompra
                                       {
                                           IdProveedorCompra = a.IdProveedorCompra,
                                           NombreProveedorCompra = a.NombreProveedorCompra
                                       };

                ViewBag.ListaProveedorCompra = fProveedorCompra.ToList();
            }
            return View();
        }

        // POST: TblCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("IdCompra,NumeroCompra,IdUsuarioCompra,IdCentro,IdCliente,IdTipoPago,CodigoPago,FechaAlterna,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro,Total")] TblCompra tblCompra)
        {
            if (ModelState.IsValid)
            {
                tblCompra.IdCompra = Guid.NewGuid();
                _context.Add(tblCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompra);
        }

        // GET: TblCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra == null)
            {
                return NotFound();
            }
            return View(tblCompra);
        }

        // POST: TblCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCompra,NumeroCompra,IdUsuarioCompra,IdCentro,IdCliente,IdTipoPago,CodigoPago,FechaAlterna,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro,Total")] TblCompra tblCompra)
        {
            if (id != tblCompra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCompraExists(tblCompra.IdCompra))
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
            return View(tblCompra);
        }

        // GET: TblCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            return View(tblCompra);
        }

        // POST: TblCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblCompras == null)
            {
                return Problem("Entity set 'nDbContext.TblCompras'  is null.");
            }
            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra != null)
            {
                _context.TblCompras.Remove(tblCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCompraExists(Guid id)
        {
            return _context.TblCompras.Any(e => e.IdCompra == id);
        }
    }
}
