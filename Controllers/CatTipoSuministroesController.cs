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
    public class CatTipoSuministroesController : Controller
    {
        private readonly nDbContext _context;

        public CatTipoSuministroesController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatTipoSuministroes
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatTipoSuministros.ToListAsync());
        }

        // GET: CatTipoSuministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTipoSuministros == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros
                .FirstOrDefaultAsync(m => m.IdTipoSuministro == id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }

            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoSuministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoSuministro,TipoSuministroDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoSuministro catTipoSuministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoSuministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTipoSuministros == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros.FindAsync(id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }
            return View(catTipoSuministro);
        }

        // POST: CatTipoSuministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoSuministro,TipoSuministroDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoSuministro catTipoSuministro)
        {
            if (id != catTipoSuministro.IdTipoSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoSuministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoSuministroExists(catTipoSuministro.IdTipoSuministro))
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
            return View(catTipoSuministro);
        }

        // GET: CatTipoSuministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTipoSuministros == null)
            {
                return NotFound();
            }

            var catTipoSuministro = await _context.CatTipoSuministros
                .FirstOrDefaultAsync(m => m.IdTipoSuministro == id);
            if (catTipoSuministro == null)
            {
                return NotFound();
            }

            return View(catTipoSuministro);
        }

        // POST: CatTipoSuministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTipoSuministros == null)
            {
                return Problem("Entity set 'nDbContext.CatTipoSuministros'  is null.");
            }
            var catTipoSuministro = await _context.CatTipoSuministros.FindAsync(id);
            if (catTipoSuministro != null)
            {
                _context.CatTipoSuministros.Remove(catTipoSuministro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoSuministroExists(int id)
        {
          return _context.CatTipoSuministros.Any(e => e.IdTipoSuministro == id);
        }
    }
}
