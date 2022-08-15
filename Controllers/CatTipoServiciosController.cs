using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class CatTipoServiciosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoServiciosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatTipoServicios
        public async Task<IActionResult> Index()
        {
            var ValidaEstatus = _context.CatEstatus.ToList();

            if (ValidaEstatus.Count == 2)
            {
                ViewBag.EstatusFlag = 1;
                var ValidaEmpresa = _context.TblEmpresas.ToList();

                if (ValidaEmpresa.Count == 1)
                {
                    ViewBag.EmpresaFlag = 1;
                    var ValidaCorporativo = _context.TblCorporativos.ToList();

                    if (ValidaCorporativo.Count >= 1)
                    {
                        ViewBag.CorporativoFlag = 1;
                    }
                    else
                    {
                        ViewBag.CorporativoFlag = 0;
                        _notyf.Information("Favor de registrar los datos de Corporativo para la Aplicación", 5);
                    }
                }
                else
                {
                    ViewBag.EmpresaFlag = 0;
                    _notyf.Information("Favor de registrar los datos de la Empresa para la Aplicación", 5);
                }
            }
            else
            {
                ViewBag.EstatusFlag = 0;
                _notyf.Information("Favor de registrar los Estatus para la Aplicación", 5);
            }
            return View(await _context.CatTipoServicios.ToListAsync());
        }

        // GET: CatTipoServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoServicio = await _context.CatTipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (catTipoServicio == null)
            {
                return NotFound();
            }

            return View(catTipoServicio);
        }

        // GET: CatTipoServicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CatTipoServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoServicio,TipoServicioDesc")] CatTipoServicio catTipoServicio)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatTipoServicios
                       .Where(s => s.TipoServicioDesc == catTipoServicio.TipoServicioDesc)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoServicio.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoServicio.FechaRegistro = DateTime.Now;
                    catTipoServicio.TipoServicioDesc = catTipoServicio.TipoServicioDesc.ToString().ToUpper();
                    catTipoServicio.IdEstatusRegistro = 1;
                    _context.Add(catTipoServicio);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Information("Favor de validar, existe una Estatus con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catTipoServicio);
        }

        // GET: CatTipoServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var catTipoServicio = await _context.CatTipoServicios.FindAsync(id);
            if (catTipoServicio == null)
            {
                return NotFound();
            }
            return View(catTipoServicio);
        }

        // POST: CatTipoServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoServicio,TipoServicioDesc,FechaRegistro,IdEstatusRegistro")] CatTipoServicio catTipoServicio)
        {
            if (id != catTipoServicio.IdTipoServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catTipoServicio.IdUsuarioModifico = Guid.Parse(fuser);
                    catTipoServicio.FechaRegistro = DateTime.Now;
                    catTipoServicio.TipoServicioDesc = catTipoServicio.TipoServicioDesc.ToString().ToUpper();
                    catTipoServicio.IdEstatusRegistro = catTipoServicio.IdEstatusRegistro;
                    _context.Update(catTipoServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTipoServicioExists(catTipoServicio.IdTipoServicio))
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
            return View(catTipoServicio);
        }

        // GET: CatTipoServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catTipoServicio = await _context.CatTipoServicios
                .FirstOrDefaultAsync(m => m.IdTipoServicio == id);
            if (catTipoServicio == null)
            {
                return NotFound();
            }

            return View(catTipoServicio);
        }

        // POST: CatTipoServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catTipoServicio = await _context.CatTipoServicios.FindAsync(id);
            catTipoServicio.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatTipoServicioExists(int id)
        {
            return _context.CatTipoServicios.Any(e => e.IdTipoServicio == id);
        }
    }
}