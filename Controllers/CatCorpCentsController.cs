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
    public class CatCorpCentsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatCorpCentsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatCorpCents
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
            var fnCatCorpCents= from a in _context.CatCorpCents

                                select new CatCorpCent
                                {
                                    IdCorpCent = a.IdCorpCent,
                                    CorpCentDesc = a.CorpCentDesc,

                                    FechaRegistro = a.FechaRegistro,
                                    IdEstatusRegistro = a.IdEstatusRegistro
                                };

            return View(await fnCatCorpCents.ToListAsync());
        }

        // GET: CatCorpCents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCorpCents = await _context.CatCorpCents
                .FirstOrDefaultAsync(m => m.IdCorpCent == id);
            if (catCorpCents == null)
            {
                return NotFound();
            }

            return View(catCorpCents);
        }

        // GET: CatCorpCents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatCorpCents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCorpCent,CorpCentDesc")] CatCorpCent nCatCorpCents)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatCorpCents
               .Where(s => s.CorpCentDesc == nCatCorpCents.CorpCentDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    nCatCorpCents.IdUsuarioModifico = Guid.Parse(fuser);
                    nCatCorpCents.CorpCentDesc = nCatCorpCents.CorpCentDesc.ToString().ToUpper().Trim();
                    nCatCorpCents.FechaRegistro = DateTime.Now;
                    nCatCorpCents.IdEstatusRegistro = 1;
                    _context.Add(nCatCorpCents);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Categoria con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdCategoria"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", nCatCorpCents.IdCategoria);
            return View(nCatCorpCents);
        }

        // GET: CatCorpCents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catCorpCents = await _context.CatCorpCents.FindAsync(id);
            if (catCorpCents == null)
            {
                return NotFound();
            }
            return View(catCorpCents);
        }

        // POST: CatCorpCents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCorpCent,CorpCentDesc,IdEstatusRegistro")] CatCorpCent nCatCorpCents)
        {
            if (id != nCatCorpCents.IdCorpCent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    nCatCorpCents.IdUsuarioModifico = Guid.Parse(fuser);
                    nCatCorpCents.CorpCentDesc = nCatCorpCents.CorpCentDesc.ToString().ToUpper().Trim();
                    nCatCorpCents.FechaRegistro = DateTime.Now;
                    nCatCorpCents.IdEstatusRegistro = nCatCorpCents.IdEstatusRegistro;
                    _context.Update(nCatCorpCents);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!catCorpCentsExists(nCatCorpCents.IdCorpCent))
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
            return View(nCatCorpCents);
        }

        // GET: CatCorpCents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catCorpCents = await _context.CatCorpCents
                .FirstOrDefaultAsync(m => m.IdCorpCent == id);
            if (catCorpCents == null)
            {
                return NotFound();
            }

            return View(catCorpCents);
        }

        // POST: CatCorpCents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nCatCorpCents = await _context.CatCorpCents.FindAsync(id);
            nCatCorpCents.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool catCorpCentsExists(int id)
        {
            return _context.CatCorpCents.Any(e => e.IdCorpCent == id);
        }
    }
}
