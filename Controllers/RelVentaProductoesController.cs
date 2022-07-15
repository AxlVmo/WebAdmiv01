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
    public class RelVentaProductoesController : Controller
    {
        private readonly nDbContext _context;

        public RelVentaProductoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: RelVentaProductoes
        public async Task<IActionResult> Index()
        {
            var fProductoVenta = _context.TblVenta.Include(s => s.IdVenta);
            return View(await _context.RelVentaProducto.ToListAsync());
        }

        // GET: RelVentaProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentaProducto = await _context.RelVentaProducto
                .FirstOrDefaultAsync(m => m.IdRelVentaProducto == id);
            if (relVentaProducto == null)
            {
                return NotFound();
            }

            return View(relVentaProducto);
        }

        // GET: RelVentaProductoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RelVentaProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRelVentaProducto,IdCategoria,IdProducto,Cantidad,ProductoPrecioUno,IdCotizacionGeneral,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] RelVentaProducto relVentaProducto)
        {
            if (ModelState.IsValid)
            {
                //relVentaProducto.IdRelVentaProducto = Guid.NewGuid();
                _context.Add(relVentaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(relVentaProducto);
        }

        // GET: RelVentaProductoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentaProducto = await _context.RelVentaProducto.FindAsync(id);
            if (relVentaProducto == null)
            {
                return NotFound();
            }
            return View(relVentaProducto);
        }

        // POST: RelVentaProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRelVentaProducto,IdCategoria,IdProducto,Cantidad,ProductoPrecioUno,IdCotizacionGeneral,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] RelVentaProducto relVentaProducto)
        {
            if (id != relVentaProducto.IdRelVentaProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relVentaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelVentaProductoExists(relVentaProducto.IdRelVentaProducto))
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
            return View(relVentaProducto);
        }

        // GET: RelVentaProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relVentaProducto = await _context.RelVentaProducto
                .FirstOrDefaultAsync(m => m.IdRelVentaProducto == id);
            if (relVentaProducto == null)
            {
                return NotFound();
            }

            return View(relVentaProducto);
        }

        // POST: RelVentaProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var relVentaProducto = await _context.RelVentaProducto.FindAsync(id);
            _context.RelVentaProducto.Remove(relVentaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelVentaProductoExists(int id)
        {
            return _context.RelVentaProducto.Any(e => e.IdRelVentaProducto == id);
        }
    }
}
