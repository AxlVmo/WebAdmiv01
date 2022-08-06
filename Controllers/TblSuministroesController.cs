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
    public class TblSuministroesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblSuministroesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblSuministros
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
                        var ValidaTipoSuministro = _context.CatTipoSuministros.ToList();

                        if (ValidaTipoSuministro.Count >= 1)
                        {
                            ViewBag.TipoSuministroFlag = 1;
                        }
                        else
                        {
                            ViewBag.TipoSuministroFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Tipo Suministro para la Aplicación", 5);
                        }
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

            var fCent = from a in _context.TblCentros
                        where a.IdEstatusRegistro == 1
                        select new
                        {
                            IdCentro = a.IdCentro,
                            CentroDesc = a.NombreCentro
                        };
            var fCorp = from a in _context.TblCorporativos
                        where a.IdEstatusRegistro == 1
                        select new
                        {
                            IdCentro = a.IdCorporativo,
                            CentroDesc = a.NombreCorporativo
                        };
            var sCorpCent = fCorp.Union(fCent);
            TempData["fTS"] = sCorpCent.ToList();
            ViewBag.ListaCorpCent = TempData["fTS"];

            var fuser = _userService.GetUserId();
            var tblUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));

            if (tblUsuario.IdArea == 2 && tblUsuario.IdPerfil == 3 && tblUsuario.IdRol == 2)
            {
                var fSuministroCntro = from a in _context.TblSuministros
                                       join b in _context.CatTipoSuministros on a.IdTipoSuministro equals b.IdTipoSuministro
                                       where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                       select new TblSuministro
                                       {
                                           TipoSuministroDesc = b.TipoSuministroDesc,
                                           IdSuministro = a.IdSuministro,
                                           SuministroDesc = a.SuministroDesc,
                                           NumeroReferencia = a.NumeroReferencia,
                                           FechaFacturacion = a.FechaFacturacion,
                                           MontoSuministro = a.MontoSuministro,
                                           IdUCorporativoCentro = a.IdUCorporativoCentro,
                                           FechaRegistro = a.FechaRegistro,
                                           IdEstatusRegistro = a.IdEstatusRegistro
                                       };
                return View(await fSuministroCntro.ToListAsync());
            }


            var fSuministro = from a in _context.TblSuministros
                              join b in _context.CatTipoSuministros on a.IdTipoSuministro equals b.IdTipoSuministro

                              select new TblSuministro
                              {

                                  TipoSuministroDesc = b.TipoSuministroDesc,
                                  IdSuministro = a.IdSuministro,
                                  SuministroDesc = a.SuministroDesc,
                                  NumeroReferencia = a.NumeroReferencia,
                                  FechaFacturacion = a.FechaFacturacion,
                                  MontoSuministro = a.MontoSuministro,
                                  IdUCorporativoCentro = a.IdUCorporativoCentro,
                                  FechaRegistro = a.FechaRegistro,
                                  IdEstatusRegistro = a.IdEstatusRegistro
                              };


            return View(await fSuministro.ToListAsync());
        }

        // GET: TblSuministros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (TblSuministro == null)
            {
                return NotFound();
            }

            return View(TblSuministro);
        }

        // GET: TblSuministros/Create
        public IActionResult Create()
        {
            var fTipoSuministro = from a in _context.CatTipoSuministros
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoSuministro
                                  {
                                      IdTipoSuministro = a.IdTipoSuministro,
                                      TipoSuministroDesc = a.TipoSuministroDesc
                                  };
            TempData["fTS"] = fTipoSuministro.ToList();
            ViewBag.ListaTipoSuministro = TempData["fTS"];
            return View();
        }

        // POST: TblSuministros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSuministro,IdTipoSuministro,SuministroDesc,NumeroReferencia,FechaFacturacion,MontoSuministro")] TblSuministro tblSuministro)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblSuministros
               .Where(s => s.SuministroDesc == tblSuministro.SuministroDesc)
               .ToList();

                if (DuplicadosEstatus.Count == 0)
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;
                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    tblSuministro.IdCorpCent = fCorpCent;
                    tblSuministro.IdUCorporativoCentro = fCentroCorporativo;
                    tblSuministro.IdUsuarioModifico = Guid.Parse(fuser);
                    tblSuministro.SuministroDesc = tblSuministro.SuministroDesc.ToString().ToUpper();
                    tblSuministro.FechaRegistro = DateTime.Now;
                    tblSuministro.IdEstatusRegistro = 1;
                    _context.Add(tblSuministro);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoSuministro con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoSuministro"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblSuministro.IdTipoSuministro);
            return View(tblSuministro);
        }

        // GET: TblSuministros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

             var fTipoSuministro = from a in _context.CatTipoSuministros
                                  where a.IdEstatusRegistro == 1
                                  select new CatTipoSuministro
                                  {
                                      IdTipoSuministro = a.IdTipoSuministro,
                                      TipoSuministroDesc = a.TipoSuministroDesc
                                  };
            TempData["fTS"] = fTipoSuministro.ToList();
            ViewBag.ListaTipoSuministro = TempData["fTS"];

            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros.FindAsync(id);
            if (TblSuministro == null)
            {
                return NotFound();
            }
            return View(TblSuministro);
        }

        // POST: TblSuministros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSuministro,IdTipoSuministro,SuministroDesc,NumeroReferencia,FechaFacturacion,MontoSuministro,IdEstatusRegistro")] TblSuministro tblSuministro)
        {
            if (id != tblSuministro.IdSuministro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Guid fCentroCorporativo = Guid.Empty;
                    int fCorpCent = 0;
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == Guid.Parse(fuser));

                    if (fIdUsuario.IdArea == 2 && fIdUsuario.IdPerfil == 3 && fIdUsuario.IdRol == 2)
                    {
                        var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
                        fCentroCorporativo = fIdCentro.IdCentro;
                        fCorpCent = 2;
                    }
                    fCentroCorporativo = fIdUsuario.IdCorporativo;
                    fCorpCent = 1;

                    tblSuministro.IdCorpCent = fCorpCent;
                    tblSuministro.IdUCorporativoCentro = fCentroCorporativo;
                    tblSuministro.SuministroDesc = tblSuministro.SuministroDesc.ToString().ToUpper();
                    tblSuministro.FechaRegistro = DateTime.Now;
                    tblSuministro.IdEstatusRegistro = tblSuministro.IdEstatusRegistro;
                    _context.Add(tblSuministro);
                    _context.Update(tblSuministro);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
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

        // GET: TblSuministros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblSuministro = await _context.TblSuministros
                .FirstOrDefaultAsync(m => m.IdSuministro == id);
            if (TblSuministro == null)
            {
                return NotFound();
            }

            return View(TblSuministro);
        }

        // POST: TblSuministros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblSuministro = await _context.TblSuministros.FindAsync(id);
            TblSuministro.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblSuministroExists(int id)
        {
            return _context.TblSuministros.Any(e => e.IdSuministro == id);
        }
    }
}
