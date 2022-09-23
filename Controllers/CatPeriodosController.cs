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
    public class CatPeriodosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatPeriodosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatPeriodo
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
            var fCatPeriodo = from a in _context.CatPeriodos

                              select new CatPeriodo
                              {
                                  IdPeriodo = a.IdPeriodo,
                                  PeriodoDesc = a.PeriodoDesc,
                                  FechaRegistro = a.FechaRegistro,
                                  IdEstatusRegistro = a.IdEstatusRegistro
                              };

            return View(await fCatPeriodo.ToListAsync());
        }

        // GET: CatPeriodo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (catPeriodo == null)
            {
                return NotFound();
            }

            return View(catPeriodo);
        }

        // GET: CatPeriodo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPeriodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,PeriodoDesc")] CatPeriodo catPeriodo)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatPeriodos
               .Where(s => s.PeriodoDesc == catPeriodo.PeriodoDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPeriodo.IdUsuarioModifico = Guid.Parse(f_user);
                    catPeriodo.PeriodoDesc = catPeriodo.PeriodoDesc.ToString().ToUpper().Trim();
                    catPeriodo.FechaRegistro = DateTime.Now;
                    catPeriodo.IdEstatusRegistro = 1;
                    _context.Add(catPeriodo);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Periodo con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdPeriodo"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catPeriodo.IdPeriodo);
            return View(catPeriodo);
        }

        // GET: CatPeriodo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodos.FindAsync(id);
            if (catPeriodo == null)
            {
                return NotFound();
            }
            return View(catPeriodo);
        }

        // POST: CatPeriodo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,PeriodoDesc,IdEstatusRegistro")] CatPeriodo catPeriodo)
        {
            if (id != catPeriodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catPeriodo.IdUsuarioModifico = Guid.Parse(f_user);
                    catPeriodo.PeriodoDesc = catPeriodo.PeriodoDesc.ToString().ToUpper().Trim();
                    catPeriodo.FechaRegistro = DateTime.Now;
                    catPeriodo.IdEstatusRegistro = catPeriodo.IdEstatusRegistro;
                    _context.Add(catPeriodo);
                    _context.Update(catPeriodo);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPeriodoExists(catPeriodo.IdPeriodo))
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
            return View(catPeriodo);
        }

        // GET: CatPeriodo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodos
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (catPeriodo == null)
            {
                return NotFound();
            }

            return View(catPeriodo);
        }

        // POST: CatPeriodo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catPeriodo = await _context.CatPeriodos.FindAsync(id);
            catPeriodo.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatPeriodoExists(int id)
        {
            return _context.CatPeriodos.Any(e => e.IdPeriodo == id);
        }
    }
}
