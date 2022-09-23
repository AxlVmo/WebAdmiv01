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
    public class CatTipoComprasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoComprasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoCompras
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
            var fCatTipoCompras = from a in _context.CatTipoCompras

                                  select new CatTipoCompra
                                  {
                                      IdTipoCompra = a.IdTipoCompra,
                                      TipoCompraDesc = a.TipoCompraDesc,
                                      FechaRegistro = a.FechaRegistro,
                                      IdEstatusRegistro = a.IdEstatusRegistro
                                  };

            return View(await fCatTipoCompras.ToListAsync());
        }

        // GET: CatTipoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoCompras = await _context.CatTipoCompras
                .FirstOrDefaultAsync(m => m.IdTipoCompra == id);
            if (catTipoCompras == null)
            {
                return NotFound();
            }

            return View(catTipoCompras);
        }

        // GET: CatTipoCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCompra,TipoCompraDesc")] CatTipoCompra catTipoCompras)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoCompras
               .Where(s => s.TipoCompraDesc == catTipoCompras.TipoCompraDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoCompras.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoCompras.TipoCompraDesc = catTipoCompras.TipoCompraDesc.ToString().ToUpper().Trim();
                    catTipoCompras.FechaRegistro = DateTime.Now;
                    catTipoCompras.IdEstatusRegistro = 1;
                    _context.Add(catTipoCompras);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoCompras con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoCompras"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catTipoCompras.IdTipoCompras);
            return View(catTipoCompras);
        }

        // GET: CatTipoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catTipoCompras = await _context.CatTipoCompras.FindAsync(id);
            if (catTipoCompras == null)
            {
                return NotFound();
            }
            return View(catTipoCompras);
        }

        // POST: CatTipoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCompra,TipoCompraDesc,IdEstatusRegistro")] CatTipoCompra catTipoCompras)
        {
            if (id != catTipoCompras.IdTipoCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoCompras.IdUsuarioModifico = Guid.Parse(f_user);
                    catTipoCompras.TipoCompraDesc = catTipoCompras.TipoCompraDesc.ToString().ToUpper().Trim();
                    catTipoCompras.FechaRegistro = DateTime.Now;
                    catTipoCompras.IdEstatusRegistro = catTipoCompras.IdEstatusRegistro;
                    _context.Add(catTipoCompras);
                    _context.Update(catTipoCompras);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoComprasExists(catTipoCompras.IdTipoCompra))
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
            return View(catTipoCompras);
        }

        // GET: CatTipoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoCompras = await _context.CatTipoCompras
                .FirstOrDefaultAsync(m => m.IdTipoCompra == id);
            if (catTipoCompras == null)
            {
                return NotFound();
            }

            return View(catTipoCompras);
        }

        // POST: CatTipoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoCompras = await _context.CatTipoCompras.FindAsync(id);
            catTipoCompras.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoComprasExists(int id)
        {
            return _context.CatTipoCompras.Any(e => e.IdTipoCompra == id);
        }
    }
}
