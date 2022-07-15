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
    public class CatTipoFormaPagoesController : Controller
    {
        private readonly nDbContext _context;

        public CatTipoFormaPagoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatTipoFormaPagoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatTipoFormaPagos.ToListAsync());
        }

        // GET: CatTipoFormaPagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTipoFormaPagos == null)
            {
                return NotFound();
            }

            var catTipoFormaPago = await _context.CatTipoFormaPagos
                .FirstOrDefaultAsync(m => m.IdTipoFormaPago == id);
            if (catTipoFormaPago == null)
            {
                return NotFound();
            }

            return View(catTipoFormaPago);
        }

        // GET: CatTipoFormaPagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoFormaPagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoFormaPago,TipoFormaPagoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoFormaPago catTipoFormaPago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoFormaPago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoFormaPago);
        }

        // GET: CatTipoFormaPagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTipoFormaPagos == null)
            {
                return NotFound();
            }

            var catTipoFormaPago = await _context.CatTipoFormaPagos.FindAsync(id);
            if (catTipoFormaPago == null)
            {
                return NotFound();
            }
            return View(catTipoFormaPago);
        }

        // POST: CatTipoFormaPagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoFormaPago,TipoFormaPagoDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoFormaPago catTipoFormaPago)
        {
            if (id != catTipoFormaPago.IdTipoFormaPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoFormaPago);
                    await _context.SaveChangesAsync();
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

        // GET: CatTipoFormaPagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTipoFormaPagos == null)
            {
                return NotFound();
            }

            var catTipoFormaPago = await _context.CatTipoFormaPagos
                .FirstOrDefaultAsync(m => m.IdTipoFormaPago == id);
            if (catTipoFormaPago == null)
            {
                return NotFound();
            }

            return View(catTipoFormaPago);
        }

        // POST: CatTipoFormaPagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTipoFormaPagos == null)
            {
                return Problem("Entity set 'nDbContext.CatTipoFormaPagos'  is null.");
            }
            var catTipoFormaPago = await _context.CatTipoFormaPagos.FindAsync(id);
            if (catTipoFormaPago != null)
            {
                _context.CatTipoFormaPagos.Remove(catTipoFormaPago);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoFormaPagoExists(int id)
        {
          return _context.CatTipoFormaPagos.Any(e => e.IdTipoFormaPago == id);
        }
    }
}
