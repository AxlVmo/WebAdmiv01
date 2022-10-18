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
    public class TblProveedoresCompraController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;


        public TblProveedoresCompraController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblProveedoresCompra
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
                var fPresupuestoCntro = from a in _context.TblProveedorCompras

                                        where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                        select new TblProveedorCompra
                                        {
                                            IdProveedorCompra = a.IdProveedorCompra,
                                            NombreProveedorCompra = a.NombreProveedorCompra,
                                            GiroComercial = a.GiroComercial,
                                            Rfc = a.Rfc,
                                            IdUCorporativoCentro = a.IdUCorporativoCentro,
                                            FechaRegistro = a.FechaRegistro,
                                            IdEstatusRegistro = a.IdEstatusRegistro
                                        };
                return View(await fPresupuestoCntro.ToListAsync());
            }


            var fPresupuesto = from a in _context.TblProveedorCompras

                               select new TblProveedorCompra
                               {

                                   IdProveedorCompra = a.IdProveedorCompra,
                                   NombreProveedorCompra = a.NombreProveedorCompra,
                                   GiroComercial = a.GiroComercial,
                                   Rfc = a.Rfc,
                                   IdUCorporativoCentro = a.IdUCorporativoCentro,
                                   FechaRegistro = a.FechaRegistro,
                                   IdEstatusRegistro = a.IdEstatusRegistro
                               };


            return View(await fPresupuesto.ToListAsync());
        }

        // GET: TblProveedoresCompra/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblProveedorCompras == null)
            {
                return NotFound();
            }

            var tblProveedorCompra = await _context.TblProveedorCompras
                .FirstOrDefaultAsync(m => m.IdProveedorCompra == id);
            if (tblProveedorCompra == null)
            {
                return NotFound();
            }

            return View(tblProveedorCompra);
        }

        // GET: TblProveedoresCompra/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: TblProveedoresCompra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedorCompra,NombreProveedorCompra,Rfc,GiroComercial,IdCorpCent,IdUsuarioModifico,IdUCorporativoCentro,FechaRegistro,IdEstatusRegistro")] TblProveedorCompra tblProveedorCompra)
        {
            if (ModelState.IsValid)
            {
                tblProveedorCompra.IdProveedorCompra = Guid.NewGuid();
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

                tblProveedorCompra.IdCorpCent = fCorpCent;
                tblProveedorCompra.IdUCorporativoCentro = fCentroCorporativo;
                tblProveedorCompra.IdUsuarioModifico = Guid.Parse(f_user);
                tblProveedorCompra.GiroComercial = tblProveedorCompra.GiroComercial.ToString().ToUpper().Trim();
                tblProveedorCompra.Rfc = tblProveedorCompra.Rfc.ToString().ToUpper().Trim();
                tblProveedorCompra.NombreProveedorCompra = tblProveedorCompra.NombreProveedorCompra.ToString().ToUpper().Trim();
                tblProveedorCompra.FechaRegistro = DateTime.Now;
                tblProveedorCompra.IdEstatusRegistro = 1;
                _context.Add(tblProveedorCompra);
                await _context.SaveChangesAsync();
                _notyf.Success("Registro creado con éxito", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(tblProveedorCompra);
        }

        // GET: TblProveedoresCompra/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null || _context.TblProveedorCompras == null)
            {
                return NotFound();
            }

            var tblProveedorCompra = await _context.TblProveedorCompras.FindAsync(id);
            if (tblProveedorCompra == null)
            {
                return NotFound();
            }
            return View(tblProveedorCompra);
        }

        // POST: TblProveedoresCompra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdProveedorCompra,NombreProveedor,Rfc,GiroComercial,IdCorpCent,IdUsuarioModifico,IdUCorporativoCentro,FechaRegistro,IdEstatusRegistro")] TblProveedorCompra tblProveedorCompra)
        {
            if (id != tblProveedorCompra.IdProveedorCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProveedorCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorCompraExists(tblProveedorCompra.IdProveedorCompra))
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
            return View(tblProveedorCompra);
        }

        // GET: TblProveedoresCompra/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblProveedorCompras == null)
            {
                return NotFound();
            }

            var tblProveedorCompra = await _context.TblProveedorCompras
                .FirstOrDefaultAsync(m => m.IdProveedorCompra == id);
            if (tblProveedorCompra == null)
            {
                return NotFound();
            }

            return View(tblProveedorCompra);
        }

        // POST: TblProveedoresCompra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblProveedorCompras == null)
            {
                return Problem("Entity set 'nDbContext.TblProveedorCompras'  is null.");
            }
            var tblProveedorCompra = await _context.TblProveedorCompras.FindAsync(id);
            if (tblProveedorCompra != null)
            {
                _context.TblProveedorCompras.Remove(tblProveedorCompra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorCompraExists(Guid id)
        {
            return _context.TblProveedorCompras.Any(e => e.IdProveedorCompra == id);
        }
    }
}
