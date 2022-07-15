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
    public class CatPeriodoAmortizasController : Controller
    {
        private readonly nDbContext _context;

        public CatPeriodoAmortizasController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatPeriodoAmortizas
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatPeriodosAmortizaciones.ToListAsync());
        }

        // GET: CatPeriodoAmortizas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatPeriodosAmortizaciones == null)
            {
                return NotFound();
            }

            var catPeriodoAmortiza = await _context.CatPeriodosAmortizaciones
                .FirstOrDefaultAsync(m => m.IdPeriodoAmortiza == id);
            if (catPeriodoAmortiza == null)
            {
                return NotFound();
            }

            return View(catPeriodoAmortiza);
        }

        // GET: CatPeriodoAmortizas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPeriodoAmortizas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodoAmortiza,PeriodoAmortizaDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatPeriodoAmortiza catPeriodoAmortiza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catPeriodoAmortiza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catPeriodoAmortiza);
        }

        // GET: CatPeriodoAmortizas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatPeriodosAmortizaciones == null)
            {
                return NotFound();
            }

            var catPeriodoAmortiza = await _context.CatPeriodosAmortizaciones.FindAsync(id);
            if (catPeriodoAmortiza == null)
            {
                return NotFound();
            }
            return View(catPeriodoAmortiza);
        }

        // POST: CatPeriodoAmortizas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodoAmortiza,PeriodoAmortizaDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatPeriodoAmortiza catPeriodoAmortiza)
        {
            if (id != catPeriodoAmortiza.IdPeriodoAmortiza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catPeriodoAmortiza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPeriodoAmortizaExists(catPeriodoAmortiza.IdPeriodoAmortiza))
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
            return View(catPeriodoAmortiza);
        }

        // GET: CatPeriodoAmortizas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatPeriodosAmortizaciones == null)
            {
                return NotFound();
            }

            var catPeriodoAmortiza = await _context.CatPeriodosAmortizaciones
                .FirstOrDefaultAsync(m => m.IdPeriodoAmortiza == id);
            if (catPeriodoAmortiza == null)
            {
                return NotFound();
            }

            return View(catPeriodoAmortiza);
        }

        // POST: CatPeriodoAmortizas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatPeriodosAmortizaciones == null)
            {
                return Problem("Entity set 'nDbContext.CatPeriodosAmortizaciones'  is null.");
            }
            var catPeriodoAmortiza = await _context.CatPeriodosAmortizaciones.FindAsync(id);
            if (catPeriodoAmortiza != null)
            {
                _context.CatPeriodosAmortizaciones.Remove(catPeriodoAmortiza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatPeriodoAmortizaExists(int id)
        {
          return _context.CatPeriodosAmortizaciones.Any(e => e.IdPeriodoAmortiza == id);
        }
    }
}
