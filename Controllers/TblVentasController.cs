using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;
using AspNetCoreHero.ToastNotification.Abstractions;
using WebAdmin.ViewModels;
using System.IO;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace WebAdmin.Controllers
{
    public class TblVentasController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;
        private IConverter _converter;

        public TblVentasController(nDbContext context, INotyfService notyf, IUserService userService, IConverter iconverte)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
            _converter = iconverte;
        }

        // GET: TblVentas
        public async Task<IActionResult> Index()
        {
            var fVentas = _context.TblVenta.Include(u => u.RelVentaProductos);
            return View(await fVentas.ToListAsync());
        }
        public FileResult CreatePdf()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                //Page = "https://iides.tech"
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }

            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            return File(file, contentType: "application/pdf");
        }
        [HttpPost]
        public IActionResult Index([FromBody] VentasViewModel oVentaVM)
        {
            var fuser = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            var idCorporativos = _context.TblCorporativos.FirstOrDefault();
            var nVenta = Guid.NewGuid();
            bool respuesta = false;

            if (oVentaVM != null)
            {
                try
                {
                    foreach (var item in oVentaVM.RelVentaProductos)
                    {
                        //item.IdRelVentaProducto = Guid.NewGuid();
                        item.Cantidad = 1;
                        item.Precio = 0;
                        item.Total = 0;
                        item.IdUsuarioModifico = Guid.Parse(fuser);
                        item.FechaRegistro = DateTime.Now;
                        item.IdEstatusRegistro = 1;
                        item.IdVenta = nVenta;
                        _context.RelVentaProducto.Add(item);
                    }

                    TblVenta oVenta = oVentaVM.TblVentas;

                    oVenta.FechaRegistro = DateTime.Now;
                    oVenta.IdEstatusRegistro = 1;
                    oVenta.IdVenta = nVenta;
                    oVenta.NumeroVenta = _context.TblVenta.Count();
                    oVenta.IdUsuarioVenta = Guid.Parse(fuser);
                    oVenta.IdCentro = idCorporativos.IdCorporativo;
                    oVenta.IdUsuarioModifico = Guid.Parse(fuser);
                    oVenta.FechaRegistro = DateTime.Now;
                    oVenta.IdEstatusRegistro = 1;
                    oVenta.CodigoPago = "Generar";
                    _context.TblVenta.Add(oVenta);
                    _context.SaveChanges();

                    respuesta = true;
                    _notyf.Success("Venta creada con éxito", 5);

                }
                catch (Exception)
                {
                    respuesta = false;
                    _notyf.Success("Err.", 5);

                }
            }



            return Json(new { respuesta });
        }
        // GET: TblVentas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta.Include(u => u.RelVentaProductos)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (tblVenta == null)
            {
                return NotFound();
            }

            return View(tblVenta);
        }

        // GET: TblVentas/Create
        public IActionResult Create()
        {
            List<CatCategoria> ListaCategoria = new List<CatCategoria>();
            ListaCategoria = (from c in _context.CatCategorias select c).Distinct().ToList();
            ViewBag.ListaCategoria = ListaCategoria;
            // ViewData["IdProfile"] = new SelectList(_context.Profiles, "IdProfile", "IdProfile", userEntityTwo.IdProfile);
            List<CatTipoPago> ListaTipoPago = new List<CatTipoPago>();
            ListaTipoPago = (from c in _context.CatTipoPagos select c).Distinct().ToList();
            ViewBag.ListaTipoPago = ListaTipoPago;
            var fUsuariosCentros = from a in _context.TblAlumnos
                                       //    where a.IdPerfil == 3 && a.IdRol == 2
                                   select new 
                                   {
                                       IdUsuario = a.IdAlumno,
                                       NombreUsuario = a.NombreAlumno + " " + a.ApellidoPaterno + " " + a.ApellidoMaterno,

                                   };
            TempData["Mpps"] = fUsuariosCentros.ToList();
            ViewBag.ListaUsuariosCentros = TempData["Mpps"];
            // ViewData["CatProductos"] = _context.CatProductos;
            return View();
        }

        // POST: TblVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdUsuarioVenta,IdAlumno,Descuento,IdTipoPago,FechaAlterna")] TblVenta tblVenta, RelVentaProducto[] VentaProductos)
        {
            if (ModelState.IsValid)
            {
                return View(tblVenta);
            }
            else
            {

                var fuser = _userService.GetUserId();
                var isLoggedIn = _userService.IsAuthenticated();
                var idCorporativos = _context.TblCorporativos.FirstOrDefault();

                tblVenta.FechaRegistro = DateTime.Now;
                tblVenta.IdEstatusRegistro = 1;
                tblVenta.IdVenta = Guid.NewGuid();
                tblVenta.NumeroVenta = _context.TblVenta.Count();
                tblVenta.IdUsuarioVenta = Guid.Parse(fuser);
                tblVenta.IdCentro = idCorporativos.IdCorporativo;
                tblVenta.IdUsuarioModifico = Guid.Parse(fuser);
                tblVenta.FechaRegistro = DateTime.Now;
                tblVenta.IdEstatusRegistro = 1;
                _context.Add(tblVenta);

                var relVentaProductos = VentaProductos;
                var VentaProduct = _context.RelVentaProducto;

                // VentaProduct.IdUsuarioModifico = Guid.Parse(fuser);
                // VentaProduct.IdRelVentaProducto = Guid.NewGuid();
                // VentaProduct.FechaRegistro = DateTime.Now;
                // VentaProduct.IdEstatusRegistro = 1;
                _context.Add(VentaProductos);

                await _context.SaveChangesAsync();
                _notyf.Success("Registro creado con éxito", 5);
            }
            return RedirectToAction(nameof(Index));

        }


        // GET: TblVentas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta.FindAsync(id);
            if (tblVenta == null)
            {
                return NotFound();
            }
            return View(tblVenta);
        }

        // POST: TblVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdVenta,NumeroVenta,IdUsuarioVenta,IdCentro,IdAlumno,Descuento,IdTipoPago,FechaAlterna,IdUsuarioModifico,FechaRegistro,IdEstatusRegistro")] TblVenta tblVenta)
        {
            if (id != tblVenta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblVentaExists(tblVenta.IdVenta))
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
            return View(tblVenta);
        }

        // GET: TblVentas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVenta = await _context.TblVenta
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (tblVenta == null)
            {
                return NotFound();
            }

            return View(tblVenta);
        }

        // POST: TblVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblVenta = await _context.TblVenta.FindAsync(id);
            _context.TblVenta.Remove(tblVenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblVentaExists(Guid id)
        {
            return _context.TblVenta.Any(e => e.IdVenta == id);
        }
    }
}
