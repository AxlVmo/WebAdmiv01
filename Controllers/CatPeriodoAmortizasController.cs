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
    public class CatPeriodoAmortizasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatPeriodoAmortizasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatPeriodoAmortizas
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
            var fCatPeriodoAmortizas = from a in _context.CatPeriodosAmortizaciones

                                select new CatPeriodoAmortiza
                                {
                                    IdPeriodoAmortiza = a.IdPeriodoAmortiza,
                                    PeriodoAmortizaDesc = a.PeriodoAmortizaDesc,

                                    FechaRegistro = a.FechaRegistro,
                                    IdEstatusRegistro = a.IdEstatusRegistro
                                };

            return View(await fCatPeriodoAmortizas.ToListAsync());
        }

        // GET: CatPeriodoAmortizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPeriodoAmortizas = await _context.CatPeriodosAmortizaciones
                .FirstOrDefaultAsync(m => m.IdPeriodoAmortiza == id);
            if (catPeriodoAmortizas== null)
            {
                return NotFound();
            }

            return View(catPeriodoAmortizas);
        }

        // GET: CatPeriodoAmortizas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPeriodoAmortizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodoAmortiza,PeriodoAmortizaDesc")] CatPeriodoAmortiza catPeriodoAmortizas)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatPeriodosAmortizaciones
               .Where(s => s.PeriodoAmortizaDesc == catPeriodoAmortizas.PeriodoAmortizaDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPeriodoAmortizas.IdUsuarioModifico = Guid.Parse(fuser);
                    catPeriodoAmortizas.PeriodoAmortizaDesc = catPeriodoAmortizas.PeriodoAmortizaDesc.ToString().ToUpper().Trim();
                    catPeriodoAmortizas.FechaRegistro = DateTime.Now;
                    catPeriodoAmortizas.IdEstatusRegistro = 1;
                    _context.Add(catPeriodoAmortizas);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Categoria con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdCategoria"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catPeriodoAmortizas.IdPeriodoAmortizas);
            return View(catPeriodoAmortizas);
        }

        // GET: CatPeriodoAmortizas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catPeriodoAmortiza= await _context.CatPeriodosAmortizaciones.FindAsync(id);
            if (catPeriodoAmortiza == null)
            {
                return NotFound();
            }
            return View(catPeriodoAmortiza);
        }

        // POST: CatPeriodoAmortizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodoAmortiza,PeriodoAmortizaDesc,IdEstatusRegistro")] CatPeriodoAmortiza catPeriodoAmortizas)
        {
            if (id != catPeriodoAmortizas.IdPeriodoAmortiza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPeriodoAmortizas.IdUsuarioModifico = Guid.Parse(fuser);
                    catPeriodoAmortizas.PeriodoAmortizaDesc = catPeriodoAmortizas.PeriodoAmortizaDesc.ToString().ToUpper().Trim();
                    catPeriodoAmortizas.FechaRegistro = DateTime.Now;
                    catPeriodoAmortizas.IdEstatusRegistro = catPeriodoAmortizas.IdEstatusRegistro;
                    _context.Add(catPeriodoAmortizas);
                    _context.Update(catPeriodoAmortizas);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPeriodoAmortizaExists(catPeriodoAmortizas.IdPeriodoAmortiza))
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
            return View(catPeriodoAmortizas);
        }

        // GET: CatPeriodoAmortizas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPeriodoAmortizas = await _context.CatPeriodosAmortizaciones
                .FirstOrDefaultAsync(m => m.IdPeriodoAmortiza == id);
            if (catPeriodoAmortizas == null)
            {
                return NotFound();
            }

            return View(catPeriodoAmortizas);
        }

        // POST: CatPeriodoAmortizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catPeriodoAmortiza = await _context.CatPeriodosAmortizaciones.FindAsync(id);
            catPeriodoAmortiza.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatPeriodoAmortizaExists(int id)
        {
            return _context.CatPeriodosAmortizaciones.Any(e => e.IdPeriodoAmortiza == id);
        }
    }
}
