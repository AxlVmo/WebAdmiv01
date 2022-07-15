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
    public class TblComprasController : Controller
    {
        private readonly nDbContext _context;

        public TblComprasController(nDbContext context)
        {
            _context = context;
        }

        // GET: TblCompras
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblCompras.ToListAsync());
        }

        // GET: TblCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            return View(tblCompra);
        }

        // GET: TblCompras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,NumeroCompra,IdUsuarioCompra,IdCentro,IdCliente,IdTipoPago,CodigoPago,FechaAlterna,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro,Total")] TblCompra tblCompra)
        {
            if (ModelState.IsValid)
            {
                tblCompra.IdCompra = Guid.NewGuid();
                _context.Add(tblCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompra);
        }

        // GET: TblCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra == null)
            {
                return NotFound();
            }
            return View(tblCompra);
        }

        // POST: TblCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCompra,NumeroCompra,IdUsuarioCompra,IdCentro,IdCliente,IdTipoPago,CodigoPago,FechaAlterna,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro,Total")] TblCompra tblCompra)
        {
            if (id != tblCompra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCompraExists(tblCompra.IdCompra))
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
            return View(tblCompra);
        }

        // GET: TblCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblCompras == null)
            {
                return NotFound();
            }

            var tblCompra = await _context.TblCompras
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            return View(tblCompra);
        }

        // POST: TblCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblCompras == null)
            {
                return Problem("Entity set 'nDbContext.TblCompras'  is null.");
            }
            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra != null)
            {
                _context.TblCompras.Remove(tblCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCompraExists(Guid id)
        {
          return _context.TblCompras.Any(e => e.IdCompra == id);
        }
    }
}
