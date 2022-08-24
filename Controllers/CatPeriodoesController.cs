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
    public class CatPeriodoesController : Controller
    {
        private readonly nDbContext _context;

        public CatPeriodoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatPeriodoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatPeriodo.ToListAsync());
        }

        // GET: CatPeriodoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatPeriodo == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodo
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (catPeriodo == null)
            {
                return NotFound();
            }

            return View(catPeriodo);
        }

        // GET: CatPeriodoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatPeriodoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeriodo,PeriodoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatPeriodo catPeriodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catPeriodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catPeriodo);
        }

        // GET: CatPeriodoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatPeriodo == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodo.FindAsync(id);
            if (catPeriodo == null)
            {
                return NotFound();
            }
            return View(catPeriodo);
        }

        // POST: CatPeriodoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeriodo,PeriodoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatPeriodo catPeriodo)
        {
            if (id != catPeriodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catPeriodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatPeriodoExists(catPeriodo.IdPeriodo))
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
            return View(catPeriodo);
        }

        // GET: CatPeriodoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatPeriodo == null)
            {
                return NotFound();
            }

            var catPeriodo = await _context.CatPeriodo
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (catPeriodo == null)
            {
                return NotFound();
            }

            return View(catPeriodo);
        }

        // POST: CatPeriodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatPeriodo == null)
            {
                return Problem("Entity set 'nDbContext.CatPeriodo'  is null.");
            }
            var catPeriodo = await _context.CatPeriodo.FindAsync(id);
            if (catPeriodo != null)
            {
                _context.CatPeriodo.Remove(catPeriodo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatPeriodoExists(int id)
        {
          return _context.CatPeriodo.Any(e => e.IdPeriodo == id);
        }
    }
}
