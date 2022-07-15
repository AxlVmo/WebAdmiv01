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
    public class TblSuministroesController : Controller
    {
        private readonly nDbContext _context;

        public TblSuministroesController(nDbContext context)
        {
            _context = context;
        }

        // GET: TblSuministroes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblSuministros.ToListAsync());
        }

        // GET: TblSuministroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblSuministros == null)
            {
                return NotFound();
            }

            var tblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (tblSuministro == null)
            {
                return NotFound();
            }

            return View(tblSuministro);
        }

        // GET: TblSuministroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblSuministroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,IdTipoSuministro,SuministroDesc,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblSuministro tblSuministro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSuministro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSuministro);
        }

        // GET: TblSuministroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblSuministros == null)
            {
                return NotFound();
            }

            var tblSuministro = await _context.TblSuministros.FindAsync(id);
            if (tblSuministro == null)
            {
                return NotFound();
            }
            return View(tblSuministro);
        }

        // POST: TblSuministroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuministro,IdTipoSuministro,SuministroDesc,IdCorpCent,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblSuministro tblSuministro)
        {
            if (id != tblSuministro.IdSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSuministro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSuministroExists(tblSuministro.IdSuministro))
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
            return View(tblSuministro);
        }

        // GET: TblSuministroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblSuministros == null)
            {
                return NotFound();
            }

            var tblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (tblSuministro == null)
            {
                return NotFound();
            }

            return View(tblSuministro);
        }

        // POST: TblSuministroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblSuministros == null)
            {
                return Problem("Entity set 'nDbContext.TblSuministros'  is null.");
            }
            var tblSuministro = await _context.TblSuministros.FindAsync(id);
            if (tblSuministro != null)
            {
                _context.TblSuministros.Remove(tblSuministro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSuministroExists(int id)
        {
          return _context.TblSuministros.Any(e => e.IdSuministro == id);
        }
    }
}
