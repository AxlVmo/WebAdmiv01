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
    public class CatTipoVentasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoVentasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoVentas
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
            var fCatTipoVentas = from a in _context.CatTipoVentas

                                  select new CatTipoVenta
                                  {
                                      IdTipoVenta = a.IdTipoVenta,
                                      TipoVentaDesc = a.TipoVentaDesc,
                                      FechaRegistro = a.FechaRegistro,
                                      IdEstatusRegistro = a.IdEstatusRegistro
                                  };

            return View(await fCatTipoVentas.ToListAsync());
        }

        // GET: CatTipoVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoVentas = await _context.CatTipoVentas
                .FirstOrDefaultAsync(m => m.IdTipoVenta == id);
            if (catTipoVentas == null)
            {
                return NotFound();
            }

            return View(catTipoVentas);
        }

        // GET: CatTipoVentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoVenta,TipoVentaDesc")] CatTipoVenta catTipoVentas)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoVentas
               .Where(s => s.TipoVentaDesc == catTipoVentas.TipoVentaDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoVentas.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoVentas.TipoVentaDesc = catTipoVentas.TipoVentaDesc.ToString().ToUpper().Trim();
                    catTipoVentas.FechaRegistro = DateTime.Now;
                    catTipoVentas.IdEstatusRegistro = 1;
                    _context.Add(catTipoVentas);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoVentas con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoVentas"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catTipoVentas.IdTipoVentas);
            return View(catTipoVentas);
        }

        // GET: CatTipoVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catTipoVentas = await _context.CatTipoVentas.FindAsync(id);
            if (catTipoVentas == null)
            {
                return NotFound();
            }
            return View(catTipoVentas);
        }

        // POST: CatTipoVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoVenta,TipoVentaDesc,IdEstatusRegistro")] CatTipoVenta catTipoVentas)
        {
            if (id != catTipoVentas.IdTipoVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoVentas.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoVentas.TipoVentaDesc = catTipoVentas.TipoVentaDesc.ToString().ToUpper().Trim();
                    catTipoVentas.FechaRegistro = DateTime.Now;
                    catTipoVentas.IdEstatusRegistro = catTipoVentas.IdEstatusRegistro;
                    _context.Add(catTipoVentas);
                    _context.Update(catTipoVentas);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoVentasExists(catTipoVentas.IdTipoVenta))
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
            return View(catTipoVentas);
        }

        // GET: CatTipoVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoVentas = await _context.CatTipoVentas
                .FirstOrDefaultAsync(m => m.IdTipoVenta == id);
            if (catTipoVentas == null)
            {
                return NotFound();
            }

            return View(catTipoVentas);
        }

        // POST: CatTipoVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoVentas = await _context.CatTipoVentas.FindAsync(id);
            catTipoVentas.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoVentasExists(int id)
        {
            return _context.CatTipoVentas.Any(e => e.IdTipoVenta == id);
        }
    }
}
