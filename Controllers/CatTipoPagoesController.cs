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
    public class CatTipoPagoesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoPagoesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoPagoes
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatTipoPagos.ToListAsync());
        }

        // GET: CatTipoPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPago = await _context.CatTipoPagos
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (catTipoPago == null)
            {
                return NotFound();
            }

            return View(catTipoPago);
        }

        // GET: CatTipoPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPago,TipoPagoDesc")] CatTipoPago catTipoPago)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.CatTipoPagos
                       .Where(s => s.TipoPagoDesc == catTipoPago.TipoPagoDesc)
                       .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPago.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoPago.FechaRegistro = DateTime.Now;
                    catTipoPago.TipoPagoDesc = catTipoPago.TipoPagoDesc.ToString().ToUpper();
                    catTipoPago.IdEstatusRegistro = 1;
                    _context.Add(catTipoPago);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoPago);
        }

        // GET: CatTipoPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPago = await _context.CatTipoPagos.FindAsync(id);
            if (catTipoPago == null)
            {
                return NotFound();
            }
            return View(catTipoPago);
        }

        // POST: CatTipoPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPago,TipoPagoDesc,IdEstatusRegistro")] CatTipoPago catTipoPago)
        {
            if (id != catTipoPago.IdTipoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoPago.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoPago.FechaRegistro = DateTime.Now;
                    catTipoPago.TipoPagoDesc = catTipoPago.TipoPagoDesc.ToString().ToUpper();
                    catTipoPago.IdEstatusRegistro = catTipoPago.IdEstatusRegistro;
                    _context.Update(catTipoPago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoPagoExists(catTipoPago.IdTipoPago))
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
            return View(catTipoPago);
        }

        // GET: CatTipoPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoPago = await _context.CatTipoPagos
                .FirstOrDefaultAsync(m => m.IdTipoPago == id);
            if (catTipoPago == null)
            {
                return NotFound();
            }

            return View(catTipoPago);
        }

        // POST: CatTipoPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoPago = await _context.CatTipoPagos.FindAsync(id);
            catTipoPago.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoPagoExists(int id)
        {
            return _context.CatTipoPagos.Any(e => e.IdTipoPago == id);
        }
    }
}