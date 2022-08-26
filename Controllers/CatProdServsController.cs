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
    public class CatProdServsController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatProdServsController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatProdServs
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
            var fCatProdServ = from a in _context.CatProdServs

                                select new CatProdServ
                                {
                                    IdProdServ = a.IdProdServ,
                                    ProdServDesc = a.ProdServDesc,

                                    FechaRegistro = a.FechaRegistro,
                                    IdEstatusRegistro = a.IdEstatusRegistro
                                };

            return View(await fCatProdServ.ToListAsync());
        }

        // GET: CatProdServs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs
                .FirstOrDefaultAsync(m => m.IdProdServ == id);
            if (catProdServ == null)
            {
                return NotFound();
            }

            return View(catProdServ);
        }

        // GET: CatProdServs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatProdServs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdServ,ProdServDesc")] CatProdServ catProdServ)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatProdServs
               .Where(s => s.ProdServDesc == catProdServ.ProdServDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catProdServ.IdUsuarioModifico = Guid.Parse(fuser);
                    catProdServ.ProdServDesc = catProdServ.ProdServDesc.ToString().ToUpper().Trim();
                    catProdServ.FechaRegistro = DateTime.Now;
                    catProdServ.IdEstatusRegistro = 1;
                    _context.Add(catProdServ);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una ProdServ con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdProdServ"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catProdServ.IdProdServ);
            return View(catProdServ);
        }

        // GET: CatProdServs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs.FindAsync(id);
            if (catProdServ == null)
            {
                return NotFound();
            }
            return View(catProdServ);
        }

        // POST: CatProdServs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdServ,ProdServDesc,IdEstatusRegistro")] CatProdServ catProdServ)
        {
            if (id != catProdServ.IdProdServ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catProdServ.IdUsuarioModifico = Guid.Parse(fuser);
                    catProdServ.ProdServDesc = catProdServ.ProdServDesc.ToString().ToUpper().Trim();
                    catProdServ.FechaRegistro = DateTime.Now;
                    catProdServ.IdEstatusRegistro = catProdServ.IdEstatusRegistro;
                    _context.Add(catProdServ);
                    _context.Update(catProdServ);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProdServExists(catProdServ.IdProdServ))
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
            return View(catProdServ);
        }

        // GET: CatProdServs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs
                .FirstOrDefaultAsync(m => m.IdProdServ == id);
            if (catProdServ == null)
            {
                return NotFound();
            }

            return View(catProdServ);
        }

        // POST: CatProdServs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catProdServ = await _context.CatProdServs.FindAsync(id);
            catProdServ.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatProdServExists(int id)
        {
            return _context.CatProdServs.Any(e => e.IdProdServ == id);
        }
    }
}
