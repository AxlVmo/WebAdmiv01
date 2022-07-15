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
    public class TblBancoesController : Controller
    {
        private readonly nDbContext _context;

        public TblBancoesController(nDbContext context)
        {
            _context = context;
        }

        // GET: TblBancoes
        public async Task<IActionResult> Index()
        {
              return View(await _context.TblBancos.ToListAsync());
        }

        // GET: TblBancoes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TblBancos == null)
            {
                return NotFound();
            }

            var tblBanco = await _context.TblBancos
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (tblBanco == null)
            {
                return NotFound();
            }

            return View(tblBanco);
        }

        // GET: TblBancoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblBancoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBanco,IdCorpCent,CantidadDeposito,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblBanco tblBanco)
        {
            if (ModelState.IsValid)
            {
                tblBanco.IdBanco = Guid.NewGuid();
                _context.Add(tblBanco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBanco);
        }

        // GET: TblBancoes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TblBancos == null)
            {
                return NotFound();
            }

            var tblBanco = await _context.TblBancos.FindAsync(id);
            if (tblBanco == null)
            {
                return NotFound();
            }
            return View(tblBanco);
        }

        // POST: TblBancoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdBanco,IdCorpCent,CantidadDeposito,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblBanco tblBanco)
        {
            if (id != tblBanco.IdBanco)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBanco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBancoExists(tblBanco.IdBanco))
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
            return View(tblBanco);
        }

        // GET: TblBancoes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TblBancos == null)
            {
                return NotFound();
            }

            var tblBanco = await _context.TblBancos
                .FirstOrDefaultAsync(m => m.IdBanco == id);
            if (tblBanco == null)
            {
                return NotFound();
            }

            return View(tblBanco);
        }

        // POST: TblBancoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TblBancos == null)
            {
                return Problem("Entity set 'nDbContext.TblBancos'  is null.");
            }
            var tblBanco = await _context.TblBancos.FindAsync(id);
            if (tblBanco != null)
            {
                _context.TblBancos.Remove(tblBanco);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBancoExists(Guid id)
        {
          return _context.TblBancos.Any(e => e.IdBanco == id);
        }
    }
}
