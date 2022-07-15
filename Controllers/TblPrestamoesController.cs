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
    public class TblPrestamoesController : Controller
    {
        private readonly nDbContext _context;

        public TblPrestamoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: TblPrestamoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblPrestamos.ToListAsync());
        }

        // GET: TblPrestamoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblPrestamos == null)
            {
                return NotFound();
            }

            var tblPrestamo = await _context.TblPrestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (tblPrestamo == null)
            {
                return NotFound();
            }

            return View(tblPrestamo);
        }

        // GET: TblPrestamoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblPrestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdTipoPrestamo,PrestamoDesc,IdCorpCent,CantidadPrestamo,IdUsuarioPrestamo,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso,Telefono,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblPrestamo tblPrestamo)
        {
            if (ModelState.IsValid)
            {
                tblPrestamo.IdPrestamo = Guid.NewGuid();
                _context.Add(tblPrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblPrestamo);
        }

        // GET: TblPrestamoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TblPrestamos == null)
            {
                return NotFound();
            }

            var tblPrestamo = await _context.TblPrestamos.FindAsync(id);
            if (tblPrestamo == null)
            {
                return NotFound();
            }
            return View(tblPrestamo);
        }

        // POST: TblPrestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPrestamo,IdTipoPrestamo,PrestamoDesc,IdCorpCent,CantidadPrestamo,IdUsuarioPrestamo,Nombres,ApellidoPaterno,ApellidoMaterno,CorreoAcceso,Telefono,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblPrestamo tblPrestamo)
        {
            if (id != tblPrestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPrestamoExists(tblPrestamo.IdPrestamo))
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
            return View(tblPrestamo);
        }

        // GET: TblPrestamoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblPrestamos == null)
            {
                return NotFound();
            }

            var tblPrestamo = await _context.TblPrestamos
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (tblPrestamo == null)
            {
                return NotFound();
            }

            return View(tblPrestamo);
        }

        // POST: TblPrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblPrestamos == null)
            {
                return Problem("Entity set 'nDbContext.TblPrestamos'  is null.");
            }
            var tblPrestamo = await _context.TblPrestamos.FindAsync(id);
            if (tblPrestamo != null)
            {
                _context.TblPrestamos.Remove(tblPrestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPrestamoExists(Guid id)
        {
          return _context.TblPrestamos.Any(e => e.IdPrestamo == id);
        }
    }
}
