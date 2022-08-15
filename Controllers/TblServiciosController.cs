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

namespace WebAdminHecsa.Controllers
{
    public class TblServiciosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblServiciosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatServicios
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
                        var ValidaTipoServicio = _context.CatTipoServicios.ToList();

                        if (ValidaTipoServicio.Count >= 1)
                        {
                            ViewBag.TipoServicioFlag = 1;
                        }
                        else
                        {
                            ViewBag.TipoServicioFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Tipo Servicio para la Aplicación", 5);
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
            var fServicios = from a in _context.TblServicio
                             join b in _context.CatTipoServicios on a.IdTipoServicio equals b.IdTipoServicio

                             select new TblServicio
                             {
                                 IdServicio = a.IdServicio,
                                 CodigoInterno = a.CodigoInterno,
                                 CodigoExterno = a.CodigoExterno,
                                 DescServicio = a.DescServicio,
                                 TipoServicioDesc = b.TipoServicioDesc,
                                 FechaRegistro = a.FechaRegistro,
                                 IdEstatusRegistro = a.IdEstatusRegistro
                             };

            return View(await fServicios.ToListAsync());
        }

        // GET: CatServicios/Details/5

        [HttpGet]
        public ActionResult FiltroServicios(int id)
        {
            var fServicios = from a in _context.TblServicio
                             join b in _context.CatTipoServicios on a.IdTipoServicio equals b.IdTipoServicio
                             where b.IdTipoServicio == id
                             select new TblServicio
                             {
                                 IdServicio = a.IdServicio,
                                 DescServicio = a.DescServicio + " - $ " + a.ServicioPrecioUno
                             };
                             _notyf.Success("Carga de servicios correcta", 5);
            return Json(fServicios);
        }

        [HttpGet]
        public ActionResult fFiltroServicio(int idA)
        {
            var fServicios = from a in _context.TblServicio
                              join b in _context.CatTipoServicios on a.IdTipoServicio equals b.IdTipoServicio
                             where a.IdServicio == idA
                             select new
                             {
                                 TipoServicioDesc = b.TipoServicioDesc,
                                 DescServicio = a.DescServicio,
                                 TotalPrecioServicio = a.ServicioPrecioUno,
                                 IdServicio = a.IdServicio,
                             };
                             _notyf.Success("Seleccion de servicios correcta", 5);
            return Json(fServicios);
        }

        [HttpPost]
        public ActionResult FiltroServicio(int idA)
        {
            var fServicios = from a in _context.TblServicio
                             join b in _context.CatTipoServicios on a.IdTipoServicio equals b.IdTipoServicio
                             where b.IdTipoServicio == idA
                             select new
                             {
                                 IdServicio = a.IdServicio,
                                 DescServicio = a.DescServicio,
                                 TipoServicioDesc = b.TipoServicioDesc,
                                 Costo = a.ServicioPrecioUno,
                             };
            return Json(fServicios);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catServicios = await _context.TblServicio
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (catServicios == null)
            {
                return NotFound();
            }

            return View(catServicios);
        }

        // GET: CatServicios/Create
        public IActionResult Create()
        {
            List<CatTipoServicio> ListaTipoServicio = new List<CatTipoServicio>();
            ListaTipoServicio = (from c in _context.CatTipoServicios select c).Distinct().ToList();
            ViewBag.ListaTipoServicio = ListaTipoServicio;

            return View();
        }

        // POST: CatServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdServicio,CodigoExterno,IdTipoServicio,DescServicio,ServicioPrecioUno,Periodo")] TblServicio catServicios)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblServicio
               .Where(s => s.IdServicio == catServicios.IdServicio && s.DescServicio == catServicios.DescServicio)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catServicios.IdUsuarioModifico = Guid.Parse(fuser);
                    catServicios.FechaRegistro = DateTime.Now;
                    catServicios.IdEstatusRegistro = 1;
                    catServicios.DescServicio = !string.IsNullOrEmpty(catServicios.DescServicio) ? catServicios.DescServicio.ToUpper() : catServicios.DescServicio;
                    catServicios.CodigoInterno = GeneraCodigoInterno();
                    _context.Add(catServicios);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Servicio con la misma marca y misma categoria", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catServicios);
        }

        // GET: CatServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
             List<CatTipoServicio> ListaTipoServicio = new List<CatTipoServicio>();
            ListaTipoServicio = (from c in _context.CatTipoServicios select c).Distinct().ToList();
            ViewBag.ListaTipoServicio = ListaTipoServicio;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catServicios = await _context.TblServicio.FindAsync(id);
            if (catServicios == null)
            {
                return NotFound();
            }
            return View(catServicios);
        }

        // POST: CatServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdServicio,CodigoExterno,IdTipoServicio,DescServicio,ServicioPrecioUno,Periodo,IdEstatusRegistro")] TblServicio catServicios)
        {
            if (id != catServicios.IdServicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catServicios.IdUsuarioModifico = Guid.Parse(fuser);
                    var fCategoria = (from c in _context.CatTipoServicios where c.IdTipoServicio == catServicios.IdTipoServicio select c).Distinct().ToList();
                    catServicios.FechaRegistro = DateTime.Now;
                    catServicios.IdEstatusRegistro = catServicios.IdEstatusRegistro;
                    catServicios.DescServicio = !string.IsNullOrEmpty(catServicios.DescServicio) ? catServicios.DescServicio.ToUpper() : catServicios.DescServicio;
                    catServicios.SubCosto = catServicios.ServicioPrecioUno;
                    _context.Update(catServicios);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatServiciosExists(catServicios.IdServicio))
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
            return View(catServicios);
        }

        // GET: CatServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catServicios = await _context.TblServicio
                .FirstOrDefaultAsync(m => m.IdServicio == id);
            if (catServicios == null)
            {
                return NotFound();
            }

            return View(catServicios);
        }

        // POST: CatServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catServicios = await _context.TblServicio.FindAsync(id);
            catServicios.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatServiciosExists(int id)
        {
            return _context.TblServicio.Any(e => e.IdServicio == id);
        }

        private string GeneraCodigoInterno()
        {
            string fmt = "0000.##";
            int Cuenta = 0;
            string strCodigoInterno = string.Empty;
            int lServicios = _context.TblServicio.Count();

            if (lServicios == 0)
            {
                Cuenta = 1;
                strCodigoInterno = "IM-S" + Cuenta.ToString(fmt);
            }
            else
            {
                Cuenta = lServicios + 1;
                strCodigoInterno = "IM-S" + Cuenta.ToString(fmt);
            }

            return strCodigoInterno;
        }
    }
}