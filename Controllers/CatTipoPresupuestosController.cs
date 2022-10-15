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
    public class CatTipoPresupuestosController : Controller
    {
        private readonly nDbContext _context;

        public CatTipoPresupuestosController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatTipoPresupuestoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatTipoPresupuestos.ToListAsync());
        }

        // GET: CatTipoPresupuestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTipoPresupuestos == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdTipoPresupuesto == id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoPresupuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoPresupuesto,TipoPresupuestoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoPresupuesto catTipoPresupuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoPresupuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTipoPresupuestos == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos.FindAsync(id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }
            return View(catTipoPresupuesto);
        }

        // POST: CatTipoPresupuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoPresupuesto,TipoPresupuestoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoPresupuesto catTipoPresupuesto)
        {
            if (id != catTipoPresupuesto.IdTipoPresupuesto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoPresupuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoPresupuestoExists(catTipoPresupuesto.IdTipoPresupuesto))
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
            return View(catTipoPresupuesto);
        }

        // GET: CatTipoPresupuestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTipoPresupuestos == null)
            {
                return NotFound();
            }

            var catTipoPresupuesto = await _context.CatTipoPresupuestos
                .FirstOrDefaultAsync(m => m.IdTipoPresupuesto == id);
            if (catTipoPresupuesto == null)
            {
                return NotFound();
            }

            return View(catTipoPresupuesto);
        }

        // POST: CatTipoPresupuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTipoPresupuestos == null)
            {
                return Problem("Entity set 'nDbContext.CatTipoPresupuestos'  is null.");
            }
            var catTipoPresupuesto = await _context.CatTipoPresupuestos.FindAsync(id);
            if (catTipoPresupuesto != null)
            {
                _context.CatTipoPresupuestos.Remove(catTipoPresupuesto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoPresupuestoExists(int id)
        {
          return _context.CatTipoPresupuestos.Any(e => e.IdTipoPresupuesto == id);
        }
    }
}
