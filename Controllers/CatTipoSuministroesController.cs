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
    public class CatTipoSuministroesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoSuministroesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoSuministros
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
            var fCatTipoSuministro = from a in _context.CatTipoSuministros

                                     select new CatTipoSuministro
                                     {
                                         IdTipoSuministro = a.IdTipoSuministro,
                                         TipoSuministroDesc = a.TipoSuministroDesc,
                                         FechaRegistro = a.FechaRegistro,
                                         IdEstatusRegistro = a.IdEstatusRegistro
                                     };

            return View(await fCatTipoSuministro.ToListAsync());
        }

        // GET: CatTipoSuministros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros
                .FirstOrDefaultAsync(m => m.IdTipoSuministro == id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }

            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoSuministros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSuministro,TipoSuministroDesc")] CatTipoSuministro catTipoSuministro)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoSuministros
               .Where(s => s.TipoSuministroDesc == catTipoSuministro.TipoSuministroDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoSuministro.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoSuministro.TipoSuministroDesc = catTipoSuministro.TipoSuministroDesc.ToString().ToUpper().Trim();
                    catTipoSuministro.FechaRegistro = DateTime.Now;
                    catTipoSuministro.IdEstatusRegistro = 1;
                    _context.Add(catTipoSuministro);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoSuministro con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoSuministro"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catTipoSuministro.IdTipoSuministro);
            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros.FindAsync(id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }
            return View(catTipoSuministro);
        }

        // POST: CatTipoSuministros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoSuministro,TipoSuministroDesc,IdEstatusRegistro")] CatTipoSuministro catTipoSuministro)
        {
            if (id != catTipoSuministro.IdTipoSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoSuministro.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoSuministro.TipoSuministroDesc = catTipoSuministro.TipoSuministroDesc.ToString().ToUpper().Trim();
                    catTipoSuministro.FechaRegistro = DateTime.Now;
                    catTipoSuministro.IdEstatusRegistro = catTipoSuministro.IdEstatusRegistro;
                    _context.Add(catTipoSuministro);
                    _context.Update(catTipoSuministro);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoSuministroExists(catTipoSuministro.IdTipoSuministro))
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
            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros
                .FirstOrDefaultAsync(m => m.IdTipoSuministro == id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }

            return View(catTipoSuministro);
        }

        // POST: CatTipoSuministros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoSuministro = await _context.CatTipoSuministros.FindAsync(id);
            catTipoSuministro.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoSuministroExists(int id)
        {
            return _context.CatTipoSuministros.Any(e => e.IdTipoSuministro == id);
        }
    }
}
