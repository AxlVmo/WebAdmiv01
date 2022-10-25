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
    public class CatSubTipoPresupuestosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatSubTipoPresupuestosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatSubTipoPresupuestos
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
            var fCatSubTipoPresupuesto = from a in _context.CatSubTipoPresupuestos
                                         join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto

                                     select new CatSubTipoPresupuesto
                                     {
                                        TipoPresupuestoDesc = b.TipoPresupuestoDesc,
                                         IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                         SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc,
                                         FechaRegistro = a.FechaRegistro,
                                         IdEstatusRegistro = a.IdEstatusRegistro
                                     };

            return View(await fCatSubTipoPresupuesto.ToListAsync());
        }
             [HttpGet]
        public ActionResult fSubTipoPresupuesto(int idA)
        {
            var _fSubTipoPresupuestos = from a in _context.CatSubTipoPresupuestos
                              join b in _context.CatTipoPresupuestos on a.IdTipoPresupuesto equals b.IdTipoPresupuesto
                             where a.IdTipoPresupuesto == idA
                             select new CatSubTipoPresupuesto
                             {
                                 IdSubTipoPresupuesto = a.IdSubTipoPresupuesto,
                                 SubTipoPresupuestoDesc = a.SubTipoPresupuestoDesc
                             };
                             _notyf.Success("Seleccion de servicios correcta", 5);
            return Json(_fSubTipoPresupuestos);
        }
        // GET: CatSubTipoPresupuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoPresupuesto = await _context.CatSubTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdSubTipoPresupuesto == id);
            if (catSubTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catSubTipoPresupuesto);
        }

        // GET: CatSubTipoPresupuestos/Create
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
            return View();
        }

        // POST: CatSubTipoPresupuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubTipoPresupuesto,SubTipoPresupuestoDesc,IdTipoPresupuesto")] CatSubTipoPresupuesto catSubTipoPresupuesto)
        {
            if (ModelState.IsValid)
            {
                catSubTipoPresupuesto.SubTipoPresupuestoDesc = catSubTipoPresupuesto.SubTipoPresupuestoDesc.ToString().ToUpper().Trim();

                var vDuplicado = _context.CatSubTipoPresupuestos
               .Where(s => s.SubTipoPresupuestoDesc == catSubTipoPresupuesto.SubTipoPresupuestoDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catSubTipoPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    catSubTipoPresupuesto.SubTipoPresupuestoDesc = catSubTipoPresupuesto.SubTipoPresupuestoDesc.ToString().ToUpper().Trim();
                    catSubTipoPresupuesto.FechaRegistro = DateTime.Now;
                    catSubTipoPresupuesto.IdEstatusRegistro = 1;
                    _context.Add(catSubTipoPresupuesto);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Tipo de Suministro con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdSubTipoPresupuesto"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catSubTipoPresupuesto.IdSubTipoPresupuesto);
            return View(catSubTipoPresupuesto);
        }

        // GET: CatSubTipoPresupuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoPresupuesto = await _context.CatSubTipoPresupuestos.FindAsync(id);
            if (catSubTipoPresupuesto == null)
            {
                return NotFound();
            }
            return View(catSubTipoPresupuesto);
        }

        // POST: CatSubTipoPresupuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSubTipoPresupuesto,SubTipoPresupuestoDesc,IdTipoPresupuesto,IdEstatusRegistro")] CatSubTipoPresupuesto catSubTipoPresupuesto)
        {
            if (id != catSubTipoPresupuesto.IdSubTipoPresupuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catSubTipoPresupuesto.IdUsuarioModifico = Guid.Parse(f_user);
                    catSubTipoPresupuesto.SubTipoPresupuestoDesc = catSubTipoPresupuesto.SubTipoPresupuestoDesc.ToString().ToUpper().Trim();
                    catSubTipoPresupuesto.FechaRegistro = DateTime.Now;
                    catSubTipoPresupuesto.IdEstatusRegistro = catSubTipoPresupuesto.IdEstatusRegistro;
                    _context.Add(catSubTipoPresupuesto);
                    _context.Update(catSubTipoPresupuesto);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatSubTipoPresupuestoExists(catSubTipoPresupuesto.IdSubTipoPresupuesto))
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
            return View(catSubTipoPresupuesto);
        }

        // GET: CatSubTipoPresupuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catSubTipoPresupuesto = await _context.CatSubTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdSubTipoPresupuesto == id);
            if (catSubTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catSubTipoPresupuesto);
        }

        // POST: CatSubTipoPresupuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catSubTipoPresupuesto = await _context.CatSubTipoPresupuestos.FindAsync(id);
            catSubTipoPresupuesto.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatSubTipoPresupuestoExists(int id)
        {
            return _context.CatSubTipoPresupuestos.Any(e => e.IdSubTipoPresupuesto == id);
        }
    }
}
