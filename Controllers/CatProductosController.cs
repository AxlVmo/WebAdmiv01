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
    public class CatProductosController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public CatProductosController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: CatProductos
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
                        var ValidaCategoria = _context.CatCategorias.ToList();

                        if (ValidaCategoria.Count >= 1)
                        {
                            ViewBag.CategoriaFlag = 1;
                        }
                        else
                        {
                            ViewBag.CategoriaFlag = 0;
                            _notyf.Information("Favor de registrar los datos de Categoria para la Aplicación", 5);
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
            var fProductos = from a in _context.CatProductos
                             join b in _context.CatCategorias on a.IdCategoria equals b.IdCategoria

                             select new CatProducto
                             {
                                 IdProducto = a.IdProducto,
                                 CodigoInterno = a.CodigoInterno,
                                 CodigoExterno = a.CodigoExterno,
                                 CategoriaDesc = b.CategoriaDesc,

                                 DescProducto = a.DescProducto,
                                 FechaRegistro = a.FechaRegistro,
                                 IdEstatusRegistro = a.IdEstatusRegistro
                             };

            return View(await fProductos.ToListAsync());
        }

        // GET: CatProductos/Details/5

        [HttpGet]
        public ActionResult FiltroProductos(int id)
        {
            var fProductos = from a in _context.CatProductos
                             join b in _context.CatCategorias on a.IdCategoria equals b.IdCategoria
                             where b.IdCategoria == id
                             select new CatProducto
                             {
                                 IdProducto = a.IdProducto,
                                 DescProducto = a.DescProducto + " - $ " + a.ProductoPrecioUno
                             };
            return Json(fProductos);
        }

        [HttpGet]
        public ActionResult fFiltroProducto(int idA)
        {
            var fProductos = from a in _context.CatProductos
                             join b in _context.CatCategorias on a.IdCategoria equals b.IdCategoria
                             where a.IdProducto == idA
                             select new
                             {
                                 DescCategoria = b.CategoriaDesc,
                                 DescProducto = a.DescProducto,
                                 TotalPrecioProducto = a.ProductoPrecioUno,
                                 IdProducto = a.IdProducto,
                             };
            return Json(fProductos);
        }

        [HttpPost]
        public ActionResult FiltroProducto(int idA)
        {
            var fProductos = from a in _context.CatProductos
                             join b in _context.CatCategorias on a.IdCategoria equals b.IdCategoria
                             where a.IdProducto == idA
                             select new
                             {
                                 IdProducto = a.IdProducto,
                                 DescProducto = a.DescProducto,
                                 DescCategoria = b.CategoriaDesc,
                                 Costo = a.ProductoPrecioUno,
                             };
            return Json(fProductos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // GET: CatProductos/Create
        public IActionResult Create()
        {
            List<CatCategoria> ListaCategoria = new List<CatCategoria>();
            ListaCategoria = (from c in _context.CatCategorias select c).Distinct().ToList();
            ViewBag.ListaCategoria = ListaCategoria;

            return View();
        }

        // POST: CatProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,CodigoExterno,IdCategoria,DescProducto")] CatProducto catProductos)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.CatProductos
               .Where(s => s.IdCategoria == catProductos.IdCategoria && s.DescProducto == catProductos.DescProducto)
               .ToList();

                if (vDuplicado.Count == 0)
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catProductos.IdUsuarioModifico = Guid.Parse(fuser);
                    var fCategoria = (from c in _context.CatCategorias where c.IdCategoria == catProductos.IdCategoria select c).Distinct().ToList();
                    catProductos.FechaRegistro = DateTime.Now;
                    catProductos.IdEstatusRegistro = 1;
                    catProductos.CategoriaDesc = fCategoria[0].CategoriaDesc;
                    catProductos.DescProducto = !string.IsNullOrEmpty(catProductos.DescProducto) ? catProductos.DescProducto.ToUpper() : catProductos.DescProducto;
                    catProductos.CodigoInterno = GeneraCodigoInterno();
                    catProductos.SubCosto = catProductos.ProductoPrecioUno * (catProductos.PorcentajePrecioUno / 100);
                    _context.Add(catProductos);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    _notyf.Warning("Favor de validar, existe una Producto con la misma marca y misma categoria", 5);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(catProductos);
        }

        // GET: CatProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<CatCategoria> ListaCategoria = new List<CatCategoria>();
            ListaCategoria = (from c in _context.CatCategorias select c).Distinct().ToList();
            ViewBag.ListaCategoria = ListaCategoria;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaEstatus = ListaCatEstatus;

            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos.FindAsync(id);
            if (catProductos == null)
            {
                return NotFound();
            }
            return View(catProductos);
        }

        // POST: CatProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,CodigoInterno,CodigoExterno,IdCategoria,DescProducto,CantidadMinima,Cantidad,ProductoPrecioUno,PorcentajePrecioUno,ProductoPrecioDos,PorcentajePrecioDos,ProductoPrecioTres,PorcentajePrecioTres,ProductoPrecioCuatro,PorcentajePrecioCuatro,SubCosto,Costo,IdEstatusRegistro")] CatProducto catProductos)
        {
            if (id != catProductos.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var fuser = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    catProductos.IdUsuarioModifico = Guid.Parse(fuser);
                    var fCategoria = (from c in _context.CatCategorias where c.IdCategoria == catProductos.IdCategoria select c).Distinct().ToList();
                    catProductos.FechaRegistro = DateTime.Now;
                    catProductos.IdEstatusRegistro = catProductos.IdEstatusRegistro;
                    catProductos.CategoriaDesc = fCategoria[0].CategoriaDesc;
                    catProductos.DescProducto = !string.IsNullOrEmpty(catProductos.DescProducto) ? catProductos.DescProducto.ToUpper() : catProductos.DescProducto;
                    //catProductos.SubCosto = catProductos.ProductoPrecioUno * (1 + (catProductos.PorcentajePrecioUno / 100));
                    catProductos.SubCosto = catProductos.ProductoPrecioUno;
                    _context.Update(catProductos);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatProductosExists(catProductos.IdProducto))
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
            return View(catProductos);
        }

        // GET: CatProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catProductos = await _context.CatProductos
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (catProductos == null)
            {
                return NotFound();
            }

            return View(catProductos);
        }

        // POST: CatProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catProductos = await _context.CatProductos.FindAsync(id);
            catProductos.IdEstatusRegistro = 2;
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool CatProductosExists(int id)
        {
            return _context.CatProductos.Any(e => e.IdProducto == id);
        }

        private string GeneraCodigoInterno()
        {
            string fmt = "0000.##";
            int Cuenta = 0;
            string strCodigoInterno = string.Empty;
            int lProductos = _context.CatProductos.Count();

            if (lProductos == 0)
            {
                Cuenta = 1;
                strCodigoInterno = "IM-P" + Cuenta.ToString(fmt);
            }
            else
            {
                Cuenta = lProductos + 1;
                strCodigoInterno = "IM-P" + Cuenta.ToString(fmt);
            }

            return strCodigoInterno;
        }
    }
}