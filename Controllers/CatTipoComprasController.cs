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
    public class CatTipoComprasController : Controller
    {
        private readonly nDbContext _context;

        public CatTipoComprasController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatTipoCompras
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatTipoCompras.ToListAsync());
        }

        // GET: CatTipoCompras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTipoCompras == null)
            {
                return NotFound();
            }

            var catTipoCompra = await _context.CatTipoCompras
                .FirstOrDefaultAsync(m => m.IdTipoCompra == id);
            if (catTipoCompra == null)
            {
                return NotFound();
            }

            return View(catTipoCompra);
        }

        // GET: CatTipoCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCompra,TipoCompraDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoCompra catTipoCompra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTipoCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoCompra);
        }

        // GET: CatTipoCompras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTipoCompras == null)
            {
                return NotFound();
            }

            var catTipoCompra = await _context.CatTipoCompras.FindAsync(id);
            if (catTipoCompra == null)
            {
                return NotFound();
            }
            return View(catTipoCompra);
        }

        // POST: CatTipoCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCompra,TipoCompraDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatTipoCompra catTipoCompra)
        {
            if (id != catTipoCompra.IdTipoCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTipoCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoCompraExists(catTipoCompra.IdTipoCompra))
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
            return View(catTipoCompra);
        }

        // GET: CatTipoCompras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTipoCompras == null)
            {
                return NotFound();
            }

            var catTipoCompra = await _context.CatTipoCompras
                .FirstOrDefaultAsync(m => m.IdTipoCompra == id);
            if (catTipoCompra == null)
            {
                return NotFound();
            }

            return View(catTipoCompra);
        }

        // POST: CatTipoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTipoCompras == null)
            {
                return Problem("Entity set 'nDbContext.CatTipoCompras'  is null.");
            }
            var catTipoCompra = await _context.CatTipoCompras.FindAsync(id);
            if (catTipoCompra != null)
            {
                _context.CatTipoCompras.Remove(catTipoCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoCompraExists(int id)
        {
          return _context.CatTipoCompras.Any(e => e.IdTipoCompra == id);
        }
    }
}
