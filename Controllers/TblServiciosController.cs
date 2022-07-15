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
    public class TblServiciosController : Controller
    {
        private readonly nDbContext _context;

        public TblServiciosController(nDbContext context)
        {
            _context = context;
        }

        // GET: TblServicios
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblServicio.ToListAsync());
        }

        // GET: TblServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblServicio == null)
            {
                return NotFound();
            }

            var tblServicio = await _context.TblServicio
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (tblServicio == null)
            {
                return NotFound();
            }

            return View(tblServicio);
        }

        // GET: TblServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicio,CodigoInterno,CodigoExterno,IdTipoServicio,DescServicio,Cantidad,ServicioPrecioUno,PorcentajePrecioUno,SubCosto,Costo,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblServicio tblServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblServicio);
        }

        // GET: TblServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblServicio == null)
            {
                return NotFound();
            }

            var tblServicio = await _context.TblServicio.FindAsync(id);
            if (tblServicio == null)
            {
                return NotFound();
            }
            return View(tblServicio);
        }

        // POST: TblServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicio,CodigoInterno,CodigoExterno,IdTipoServicio,DescServicio,Cantidad,ServicioPrecioUno,PorcentajePrecioUno,SubCosto,Costo,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblServicio tblServicio)
        {
            if (id != tblServicio.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblServicioExists(tblServicio.IdServicio))
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
            return View(tblServicio);
        }

        // GET: TblServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblServicio == null)
            {
                return NotFound();
            }

            var tblServicio = await _context.TblServicio
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (tblServicio == null)
            {
                return NotFound();
            }

            return View(tblServicio);
        }

        // POST: TblServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblServicio == null)
            {
                return Problem("Entity set 'nDbContext.TblServicio'  is null.");
            }
            var tblServicio = await _context.TblServicio.FindAsync(id);
            if (tblServicio != null)
            {
                _context.TblServicio.Remove(tblServicio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblServicioExists(int id)
        {
          return _context.TblServicio.Any(e => e.IdServicio == id);
        }
    }
}
