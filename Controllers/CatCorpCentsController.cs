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
    public class CatCorpCentsController : Controller
    {
        private readonly nDbContext _context;

        public CatCorpCentsController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatCorpCents
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatCorpCents.ToListAsync());
        }

        // GET: CatCorpCents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatCorpCents == null)
            {
                return NotFound();
            }

            var catCorpCent = await _context.CatCorpCents
                .FirstOrDefaultAsync(m => m.IdCorpCent == id);
            if (catCorpCent == null)
            {
                return NotFound();
            }

            return View(catCorpCent);
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
        public async Task<IActionResult> Create([Bind("IdCorpCent,CorpCentDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatCorpCent catCorpCent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catCorpCent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catCorpCent);
        }

        // GET: CatCorpCents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatCorpCents == null)
            {
                return NotFound();
            }

            var catCorpCent = await _context.CatCorpCents.FindAsync(id);
            if (catCorpCent == null)
            {
                return NotFound();
            }
            return View(catCorpCent);
        }

        // POST: CatCorpCents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCorpCent,CorpCentDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatCorpCent catCorpCent)
        {
            if (id != catCorpCent.IdCorpCent)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catCorpCent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatCorpCentExists(catCorpCent.IdCorpCent))
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
            return View(catCorpCent);
        }

        // GET: CatCorpCents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatCorpCents == null)
            {
                return NotFound();
            }

            var catCorpCent = await _context.CatCorpCents
                .FirstOrDefaultAsync(m => m.IdCorpCent == id);
            if (catCorpCent == null)
            {
                return NotFound();
            }

            return View(catCorpCent);
        }

        // POST: CatCorpCents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatCorpCents == null)
            {
                return Problem("Entity set 'nDbContext.CatCorpCents'  is null.");
            }
            var catCorpCent = await _context.CatCorpCents.FindAsync(id);
            if (catCorpCent != null)
            {
                _context.CatCorpCents.Remove(catCorpCent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatCorpCentExists(int id)
        {
          return _context.CatCorpCents.Any(e => e.IdCorpCent == id);
        }
    }
}
