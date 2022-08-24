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
    public class CatTipoCancelacionsController : Controller
    {
        private readonly nDbContext _context;

        public CatTipoCancelacionsController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatTipoCancelacions
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatTipoCancelacion.ToListAsync());
        }

        // GET: CatTipoCancelacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTipoCancelacion == null)
            {
                return NotFound();
            }

            var catTipoCancelacion = await _context.CatTipoCancelacion
                .FirstOrDefaultAsync(m => m.IdTipoCancelacion == id);
            if (catTipoCancelacion == null)
            {
                return NotFound();
            }

            return View(catTipoCancelacion);
        }

        // GET: CatTipoCancelacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoCancelacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCancelacion,TipoCancelacionDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoCancelacion catTipoCancelacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoCancelacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoCancelacion);
        }

        // GET: CatTipoCancelacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTipoCancelacion == null)
            {
                return NotFound();
            }

            var catTipoCancelacion = await _context.CatTipoCancelacion.FindAsync(id);
            if (catTipoCancelacion == null)
            {
                return NotFound();
            }
            return View(catTipoCancelacion);
        }

        // POST: CatTipoCancelacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCancelacion,TipoCancelacionDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoCancelacion catTipoCancelacion)
        {
            if (id != catTipoCancelacion.IdTipoCancelacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoCancelacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoCancelacionExists(catTipoCancelacion.IdTipoCancelacion))
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
            return View(catTipoCancelacion);
        }

        // GET: CatTipoCancelacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTipoCancelacion == null)
            {
                return NotFound();
            }

            var catTipoCancelacion = await _context.CatTipoCancelacion
                .FirstOrDefaultAsync(m => m.IdTipoCancelacion == id);
            if (catTipoCancelacion == null)
            {
                return NotFound();
            }

            return View(catTipoCancelacion);
        }

        // POST: CatTipoCancelacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTipoCancelacion == null)
            {
                return Problem("Entity set 'nDbContext.CatTipoCancelacion'  is null.");
            }
            var catTipoCancelacion = await _context.CatTipoCancelacion.FindAsync(id);
            if (catTipoCancelacion != null)
            {
                _context.CatTipoCancelacion.Remove(catTipoCancelacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoCancelacionExists(int id)
        {
          return _context.CatTipoCancelacion.Any(e => e.IdTipoCancelacion == id);
        }
    }
}
