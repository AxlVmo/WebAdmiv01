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
    public class CatTipoFormaPagoesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoFormaPagoesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoFormaPagos
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
            var fCatTipoFormaPago= from a in _context.CatTipoFormaPagos

                                select new CatTipoFormaPago
                                {
                                    IdTipoFormaPago= a.IdTipoFormaPago,
                                    TipoFormaPagoDesc = a.TipoFormaPagoDesc,

                                    FechaRegistro = a.FechaRegistro,
                                    IdEstatusRegistro = a.IdEstatusRegistro
                                };

            return View(await fCatTipoFormaPago.ToListAsync());
        }

        // GET: CatTipoFormaPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoFormaPago= await _context.CatTipoFormaPagos
                .FirstOrDefaultAsync(m => m.IdTipoFormaPago== id);
            if (catTipoFormaPago== null)
            {
                return NotFound();
            }

            return View(catTipoFormaPago);
        }

        // GET: CatTipoFormaPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoFormaPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoFormaPago,TipoFormaPagoDesc")] CatTipoFormaPago catTipoFormaPago)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoFormaPagos
               .Where(s => s.TipoFormaPagoDesc == catTipoFormaPago.TipoFormaPagoDesc)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoFormaPago.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoFormaPago.TipoFormaPagoDesc = catTipoFormaPago.TipoFormaPagoDesc.ToString().ToUpper();
                    catTipoFormaPago.FechaRegistro = DateTime.Now;
                    catTipoFormaPago.IdEstatusRegistro = 1;
                    _context.Add(catTipoFormaPago);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoFormaPagocon el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoFormaPago"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", catTipoFormaPago.IdTipoFormaPago);
            return View(catTipoFormaPago);
        }

        // GET: CatTipoFormaPagos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catTipoFormaPago= await _context.CatTipoFormaPagos.FindAsync(id);
            if (catTipoFormaPago== null)
            {
                return NotFound();
            }
            return View(catTipoFormaPago);
        }

        // POST: CatTipoFormaPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoFormaPago,TipoFormaPagoDesc,IdEstatusRegistro")] CatTipoFormaPago catTipoFormaPago)
        {
            if (id != catTipoFormaPago.IdTipoFormaPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoFormaPago.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoFormaPago.TipoFormaPagoDesc = catTipoFormaPago.TipoFormaPagoDesc.ToString().ToUpper();
                    catTipoFormaPago.FechaRegistro = DateTime.Now;
                    catTipoFormaPago.IdEstatusRegistro = catTipoFormaPago.IdEstatusRegistro;
                    _context.Add(catTipoFormaPago);
                    _context.Update(catTipoFormaPago);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoFormaPagoExists(catTipoFormaPago.IdTipoFormaPago))
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
            return View(catTipoFormaPago);
        }

        // GET: CatTipoFormaPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoFormaPago= await _context.CatTipoFormaPagos
                .FirstOrDefaultAsync(m => m.IdTipoFormaPago== id);
            if (catTipoFormaPago== null)
            {
                return NotFound();
            }

            return View(catTipoFormaPago);
        }

        // POST: CatTipoFormaPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoFormaPago= await _context.CatTipoFormaPagos.FindAsync(id);
            catTipoFormaPago.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoFormaPagoExists(int id)
        {
            return _context.CatTipoFormaPagos.Any(e => e.IdTipoFormaPago== id);
        }
    }
}
