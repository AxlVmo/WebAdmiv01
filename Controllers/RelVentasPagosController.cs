using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdmin.Data;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class RelVentasPagosController : Controller
    {
        private readonly nDbContext _context;

        public RelVentasPagosController(nDbContext context)
        {
            _context = context;
        }

        // GET: RelVentasPagos
        public async Task<IActionResult> Index()
        {
            return View(await _context.RelVentasPagos.ToListAsync());
        }

        // GET: RelVentasPagos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentasPagos = await _context.RelVentasPagos
                .FirstOrDefaultAsync(m => m.IdRelVentasPago == id);
            if (relVentasPagos == null)
            {
                return NotFound();
            }

            return View(relVentasPagos);
        }

        // GET: RelVentasPagos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelVentasPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRelVentasPago,CodigoReferencia,CantidadPago,IdCotizacionGeneral,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] RelVentaPagos relVentasPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relVentasPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relVentasPagos);
        }

        // GET: RelVentasPagos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentasPagos = await _context.RelVentasPagos.FindAsync(id);
            if (relVentasPagos == null)
            {
                return NotFound();
            }
            return View(relVentasPagos);
        }

        // POST: RelVentasPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRelVentasPago,CodigoReferencia,CantidadPago,IdCotizacionGeneral,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] RelVentaPagos relVentasPagos)
        {
            if (id != relVentasPagos.IdRelVentasPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relVentasPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelVentasPagosExists(relVentasPagos.IdRelVentasPago))
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
            return View(relVentasPagos);
        }

        // GET: RelVentasPagos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentasPagos = await _context.RelVentasPagos
                .FirstOrDefaultAsync(m => m.IdRelVentasPago == id);
            if (relVentasPagos == null)
            {
                return NotFound();
            }

            return View(relVentasPagos);
        }

        // POST: RelVentasPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relVentasPagos = await _context.RelVentasPagos.FindAsync(id);
            _context.RelVentasPagos.Remove(relVentasPagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelVentasPagosExists(int id)
        {
            return _context.RelVentasPagos.Any(e => e.IdRelVentasPago == id);
        }
    }
}
