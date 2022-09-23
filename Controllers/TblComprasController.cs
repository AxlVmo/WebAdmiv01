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

            var f_user = _userService.GetUserId();
            var tblUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(f_user));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(f_user));

            if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
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
            TempData["fTS"] = fTipoCompra.ToList();
            ViewBag.ListaTipoCompra = TempData["fTS"];
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
