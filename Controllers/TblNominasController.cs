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
    public class TblNominasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblNominasController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblNominas
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
                        var ValidaCentro = _context.TblCentros.ToList();

                        if (ValidaCentro.Count >= 1)
                        {
                            ViewBag.CentrosFlag = 1;
                            var ValidaUsuarios = _context.TblUsuarios.ToList();

                            if (ValidaUsuarios.Count >= 1)
                            {
                                ViewBag.UsuariosFlag = 1;
                            }
                            else
                            {
                                ViewBag.UsuariosFlag = 0;
                                _notyf.Information("Favor de registrar los datos de Usuarios para la Aplicación", 5);
                            }
                        }
                        else
                        {
                            ViewBag.CentrosFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Centros para la Aplicación", 5);
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
                var fNominaCntro = from a in _context.TblNominas
                                   join b in _context.TblUsuarios on a.IdUsuarioRemuneracion equals b.IdUsuario
                                   join c in _context.CatTipoPagos on a.IdTipoPago equals c.IdTipoPago
                                   join d in _context.CatTipoContrataciones on a.IdTipoContratacion equals d.IdTipoContratacion
                                   where a.IdUCorporativoCentro == fIdCentro.IdCentro && a.IdCorpCent == 2
                                   select new TblNomina
                                   {
                                       IdNomina = a.IdNomina,
                                       NominaDesc = a.NominaDesc,
                                       UsuarioRemuneracion = a.UsuarioRemuneracion,
                                       TipoContratacionDesc = d.TipoContratacionDesc,
                                       TipoPagoDesc = c.TipoPagoDesc,
                                       IdUCorporativoCentro = a.IdUCorporativoCentro,
                                       FechaRegistro = a.FechaRegistro,
                                       IdEstatusRegistro = a.IdEstatusRegistro
                                   };
                return View(await fNominaCntro.ToListAsync());
            }

            var fNomina = from a in _context.TblNominas
                          join b in _context.TblUsuarios on a.IdUsuarioRemuneracion equals b.IdUsuario
                          join c in _context.CatTipoPagos on a.IdTipoPago equals c.IdTipoPago
                          join d in _context.CatTipoContrataciones on a.IdTipoContratacion equals d.IdTipoContratacion
                          select new TblNomina
                          {
                              IdNomina = a.IdNomina,
                              NominaDesc = a.NominaDesc,
                              UsuarioRemuneracion = a.UsuarioRemuneracion,
                              TipoContratacionDesc = d.TipoContratacionDesc,
                              TipoPagoDesc = c.TipoPagoDesc,
                              IdUCorporativoCentro = a.IdUCorporativoCentro,
                              FechaRegistro = a.FechaRegistro,
                              IdEstatusRegistro = a.IdEstatusRegistro
                          };

            return View(await fNomina.ToListAsync());
        }

        // GET: TblNominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas
                .FirstOrDefaultAsync(m => m.IdNomina == id);
            if (TblNomina == null)
            {
                return NotFound();
            }

            return View(TblNomina);
        }

        // GET: TblNominas/Create
        public IActionResult Create()
        {
            var fuser = _userService.GetUserId();
            var fIdUsuario = (from a in _context.TblUsuarios
                              where a.IdPerfil == 3 && a.IdRol == 2 && a.IdArea == 2 && a.IdUsuario == Guid.Parse(fuser)
                              select new TblUsuario
                              {
                                  IdUsuario = a.IdUsuario,
                                  IdArea = a.IdArea,
                                  IdPerfil = a.IdPerfil,
                                  IdRol = a.IdRol
                              }).ToList();

            if (fIdUsuario.Count == 1)
            {
                var fIdCentroCorp = _context.TblCentros
                                      .Where(s => s.IdUsuarioControl == Guid.Parse(fuser))
                                      .FirstOrDefault();

                var fUsuariosCentrosCorp = from a in _context.TblUsuarios
                                       where a.IdCorporativo == fIdCentroCorp.IdCentro
                                       select new
                                       {
                                           IdUsuario = a.IdUsuario,
                                           NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                       };
                TempData["Mpps"] = fUsuariosCentrosCorp.ToList();
                ViewBag.ListaUsuariosCentros = TempData["Mpps"];
            }

            var fUsuariosCentros = from a in _context.TblUsuarios
                                   select new
                                   {
                                       IdUsuario = a.IdUsuario,
                                       NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];
            return View();
        }

        // POST: TblNominas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoNomina,NominaDesc,NumeroReferencia,FechaFacturacion,MontoNomina")] TblNomina TblNomina)
        {
            if (ModelState.IsValid)
            {
                var DuplicadosEstatus = _context.TblNominas
               .Where(s => s.NominaDesc == TblNomina.NominaDesc)
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
                    TblNomina.IdCorpCent = fCorpCent;
                    TblNomina.IdUCorporativoCentro = fCentroCorporativo;
                    TblNomina.IdUsuarioModifico = Guid.Parse(fuser);
                    TblNomina.NominaDesc = TblNomina.NominaDesc.ToString().ToUpper();
                    TblNomina.FechaRegistro = DateTime.Now;
                    TblNomina.IdEstatusRegistro = 1;
                    _context.Add(TblNomina);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una TipoNomina con el mismo nombre", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdTipoNomina"] = new SelectList(_context.CatMarcas, "IdMarca", "MarcaDesc", TblNomina.IdTipoNomina);
            return View(TblNomina);
        }

        // GET: TblNominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            var fuser = _userService.GetUserId();
            var fIdCentro = await _context.TblCentros.FirstOrDefaultAsync(m => m.IdUsuarioControl == Guid.Parse(fuser));
            var fUsuariosCentros = from a in _context.TblUsuarios
                                   where a.IdCorporativo == fIdCentro.IdCentro
                                   select new
                                   {
                                       IdUsuario = a.IdUsuario,
                                       NombreUsuario = a.Nombres + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,
                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];

            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas.FindAsync(id);
            if (TblNomina == null)
            {
                return NotFound();
            }
            return View(TblNomina);
        }

        // POST: TblNominas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoNomina,NominaDesc,NumeroReferencia,FechaFacturacion,MontoNomina,IdEstatusRegistro")] TblNomina TblNomina)
        {
            if (id != TblNomina.IdNomina)
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

                    TblNomina.IdCorpCent = fCorpCent;
                    TblNomina.IdUCorporativoCentro = fCentroCorporativo;
                    TblNomina.NominaDesc = TblNomina.NominaDesc.ToString().ToUpper();
                    TblNomina.FechaRegistro = DateTime.Now;
                    TblNomina.IdEstatusRegistro = TblNomina.IdEstatusRegistro;
                    _context.Add(TblNomina);
                    _context.Update(TblNomina);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblNominaExists(TblNomina.IdNomina))
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
            return View(TblNomina);
        }

        // GET: TblNominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var TblNomina = await _context.TblNominas
                .FirstOrDefaultAsync(m => m.IdNomina == id);
            if (TblNomina == null)
            {
                return NotFound();
            }

            return View(TblNomina);
        }

        // POST: TblNominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var TblNomina = await _context.TblNominas.FindAsync(id);
            TblNomina.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblNominaExists(int id)
        {
            return _context.TblNominas.Any(e => e.IdNomina == id);
        }
    }
}