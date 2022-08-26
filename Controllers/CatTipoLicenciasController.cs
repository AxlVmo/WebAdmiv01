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
    public class CatTipoLicenciasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatTipoLicenciasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CaTipotLicencias
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
            var fCatLicencia = from a in _context.CaTipotLicencias

                               select new CaTipotLicencia
                               {
                                   IdTipoLicencia = a.IdTipoLicencia,
                                   LicenciaDesc = a.LicenciaDesc,

                                   FechaRegistro = a.FechaRegistro,
                                   IdEstatusRegistro = a.IdEstatusRegistro
                               };

            return View(await fCatLicencia.ToListAsync());
        }

        // GET: CaTipotLicencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CaTipotLicencia = await _context.CaTipotLicencias
                .FirstOrDefaultAsync(m => m.IdTipoLicencia == id);
            if (CaTipotLicencia == null)
            {
                return NotFound();
            }

            return View(CaTipotLicencia);
        }

        // GET: CaTipotLicencias/Create
        public IActionResult Create()
        {
            List<CaTipotLicencia> ListaLicencia = new List<CaTipotLicencia>();
            ListaLicencia = (from c in _context.CaTipotLicencias select c).Distinct().ToList();
            ViewBag.ListaLicencia = ListaLicencia;

            return View();
        }

        // POST: CaTipotLicencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoLicencia,LicenciaDesc")] CaTipotLicencia CaTipotLicencia)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CaTipotLicencias
               .Where(s => s.LicenciaDesc == CaTipotLicencia.LicenciaDesc)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CaTipotLicencia.IdUsuarioModifico = Guid.Parse(fuser);
                    CaTipotLicencia.FechaRegistro = DateTime.Now;
                    CaTipotLicencia.LicenciaDesc = CaTipotLicencia.LicenciaDesc.ToUpper().Trim();
                    CaTipotLicencia.IdEstatusRegistro = 1;
                    _context.Add(CaTipotLicencia);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Categoria con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoLicencia"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", CaTipotLicencia.IdTipoLicencia);
            return View(CaTipotLicencia);
        }

        // GET: CaTipotLicencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var CaTipotLicencia = await _context.CaTipotLicencias.FindAsync(id);
            if (CaTipotLicencia == null)
            {
                return NotFound();
            }
            return View(CaTipotLicencia);
        }

        // POST: CaTipotLicencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoLicencia,LicenciaDesc,IdEstatusRegistro")] CaTipotLicencia CaTipotLicencia)
        {
            if (id != CaTipotLicencia.IdTipoLicencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    CaTipotLicencia.IdUsuarioModifico = Guid.Parse(fuser);
                    CaTipotLicencia.FechaRegistro = DateTime.Now;
                    CaTipotLicencia.LicenciaDesc = CaTipotLicencia.LicenciaDesc.ToUpper().Trim();
                    CaTipotLicencia.IdEstatusRegistro = CaTipotLicencia.IdEstatusRegistro;
                    _context.Update(CaTipotLicencia);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatLicenciaExists(CaTipotLicencia.IdTipoLicencia))
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
            return View(CaTipotLicencia);
        }

        // GET: CaTipotLicencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CaTipotLicencia = await _context.CaTipotLicencias
                .FirstOrDefaultAsync(m => m.IdTipoLicencia == id);
            if (CaTipotLicencia == null)
            {
                return NotFound();
            }

            return View(CaTipotLicencia);
        }

        // POST: CaTipotLicencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CaTipotLicencia = await _context.CaTipotLicencias.FindAsync(id);
            CaTipotLicencia.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatLicenciaExists(int id)
        {
            return _context.CaTipotLicencias.Any(e => e.IdTipoLicencia == id);
        }
    }
}