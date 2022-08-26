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
    public class CatTipoCancelacionesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoCancelacionesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoCancelaciones
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
            var fCatTipoCancelaciones = from a in _context.CatTipoCancelaciones

                                        select new CatTipoCancelacion
                                        {
                                            IdTipoCancelacion = a.IdTipoCancelacion,
                                            TipoCancelacionDesc = a.TipoCancelacionDesc,
                                            FechaRegistro = a.FechaRegistro,
                                            IdEstatusRegistro = a.IdEstatusRegistro
                                        };

            return View(await fCatTipoCancelaciones.ToListAsync());
        }

        // GET: CatTipoCancelaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoCancelaciones = await _context.CatTipoCancelaciones
                .FirstOrDefaultAsync(m => m.IdTipoCancelacion == id);
            if (catTipoCancelaciones == null)
            {
                return NotFound();
            }

            return View(catTipoCancelaciones);
        }

        // GET: CatTipoCancelaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoCancelaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCancelacion,TipoCancelacionDesc")] CatTipoCancelacion catTipoCancelaciones)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoCancelaciones
               .Where(s => s.TipoCancelacionDesc == catTipoCancelaciones.TipoCancelacionDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoCancelaciones.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoCancelaciones.TipoCancelacionDesc= catTipoCancelaciones.TipoCancelacionDesc.ToString().ToUpper().Trim();
                    catTipoCancelaciones.FechaRegistro = DateTime.Now;
                    catTipoCancelaciones.IdEstatusRegistro = 1;
                    _context.Add(catTipoCancelaciones);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoCancelaciones con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoCancelaciones"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catTipoCancelaciones.IdTipoCancelaciones);
            return View(catTipoCancelaciones);
        }

        // GET: CatTipoCancelaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catTipoCancelaciones = await _context.CatTipoCancelaciones.FindAsync(id);
            if (catTipoCancelaciones == null)
            {
                return NotFound();
            }
            return View(catTipoCancelaciones);
        }

        // POST: CatTipoCancelaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCancelacion,TipoCancelacionDesc,IdEstatusRegistro")] CatTipoCancelacion catTipoCancelaciones)
        {
            if (id != catTipoCancelaciones.IdTipoCancelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoCancelaciones.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoCancelaciones.TipoCancelacionDesc = catTipoCancelaciones.TipoCancelacionDesc.ToString().ToUpper().Trim();
                    catTipoCancelaciones.FechaRegistro = DateTime.Now;
                    catTipoCancelaciones.IdEstatusRegistro = catTipoCancelaciones.IdEstatusRegistro;
                    _context.Add(catTipoCancelaciones);
                    _context.Update(catTipoCancelaciones);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoCancelacionesExists(catTipoCancelaciones.IdTipoCancelacion))
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
            return View(catTipoCancelaciones);
        }

        // GET: CatTipoCancelaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoCancelaciones = await _context.CatTipoCancelaciones
                .FirstOrDefaultAsync(m => m.IdTipoCancelacion == id);
            if (catTipoCancelaciones == null)
            {
                return NotFound();
            }

            return View(catTipoCancelaciones);
        }

        // POST: CatTipoCancelaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoCancelaciones = await _context.CatTipoCancelaciones.FindAsync(id);
            catTipoCancelaciones.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoCancelacionesExists(int id)
        {
            return _context.CatTipoCancelaciones.Any(e => e.IdTipoCancelacion == id);
        }
    }
}
