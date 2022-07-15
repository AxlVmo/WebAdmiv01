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
    public class CatProdServsController : Controller
    {
        private readonly nDbContext _context;

        public CatProdServsController(nDbContext context)
        {
            _context = context;
        }

        // GET: CatProdServs
        public async Task<IActionResult> Index()
        {
              return View(await _context.CatProdServs.ToListAsync());
        }

        // GET: CatProdServs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatProdServs == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs
                .FirstOrDefaultAsync(m => m.IdProdServ == id);
            if (catProdServ == null)
            {
                return NotFound();
            }

            return View(catProdServ);
        }

        // GET: CatProdServs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatProdServs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProdServ,ProdServDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatProdServ catProdServ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catProdServ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catProdServ);
        }

        // GET: CatProdServs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatProdServs == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs.FindAsync(id);
            if (catProdServ == null)
            {
                return NotFound();
            }
            return View(catProdServ);
        }

        // POST: CatProdServs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProdServ,ProdServDesc,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] CatProdServ catProdServ)
        {
            if (id != catProdServ.IdProdServ)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catProdServ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProdServExists(catProdServ.IdProdServ))
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
            return View(catProdServ);
        }

        // GET: CatProdServs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatProdServs == null)
            {
                return NotFound();
            }

            var catProdServ = await _context.CatProdServs
                .FirstOrDefaultAsync(m => m.IdProdServ == id);
            if (catProdServ == null)
            {
                return NotFound();
            }

            return View(catProdServ);
        }

        // POST: CatProdServs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatProdServs == null)
            {
                return Problem("Entity set 'nDbContext.CatProdServs'  is null.");
            }
            var catProdServ = await _context.CatProdServs.FindAsync(id);
            if (catProdServ != null)
            {
                _context.CatProdServs.Remove(catProdServ);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatProdServExists(int id)
        {
          return _context.CatProdServs.Any(e => e.IdProdServ == id);
        }
    }
}
