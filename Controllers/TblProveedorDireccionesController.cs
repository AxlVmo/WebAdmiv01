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
    public class TblProveedorDireccionesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public TblProveedorDireccionesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        // GET: TblProveedorDirecciones
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
                    var ValidaProveedor = _context.TblProveedores.ToList();

                    if (ValidaProveedor.Count >= 1)
                    {
                        ViewBag.ProveedorFlag = 1;
                        var ValidaTipoDireccion = _context.CatTipoDirecciones.ToList();

                        if (ValidaTipoDireccion.Count > 1)
                        {
                            ViewBag.TipoDireccionFlag = 1;
                        }
                        else
                        {
                            ViewBag.TipoDireccionFlag = 0;
                            _notyf.Information("Favor de registrar los datos de la Tipo Dirección para la Aplicación", 5);
                        }
                    }
                    else
                    {
                        ViewBag.ProveedorFlag = 0;
                        _notyf.Information("Favor de registrar los datos de la Proveedor para la Aplicación", 5);
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
            var fTblProveedorDireccion = from a in _context.TblProveedorDirecciones
                                         join b in _context.CatTipoDirecciones on a.IdTipoDireccion equals b.IdTipoDireccion
                                         join c in _context.TblProveedores on a.IdProveedor equals c.IdProveedor
                                         select new TblProveedorDireccion
                                         {
                                             IdProveedorDirecciones = a.IdProveedorDirecciones,
                                             NombreProveedor = c.NombreProveedor,
                                             TipoDireccionDesc = b.TipoDireccionDesc,
                                             CorreoElectronico = a.CorreoElectronico,
                                             Telefono = a.Telefono,
                                             FechaRegistro = a.FechaRegistro,
                                             IdEstatusRegistro = a.IdEstatusRegistro
                                         };

            return View(await fTblProveedorDireccion.ToListAsync());
        }

        // GET: TblProveedorDirecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones
                .FirstOrDefaultAsync(m => m.IdProveedorDirecciones == id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }

            return View(tblProveedorDirecciones);
        }

        // GET: TblProveedorDirecciones/Create
        public IActionResult Create()
        {
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedores select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            return View();
        }

        // POST: TblProveedorDirecciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProveedorDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdProveedor")] TblProveedorDireccion tblProveedorDirecciones)
        {
            if (ModelState.IsValid)
            {
                var vDuplicado = _context.TblProveedorDirecciones
                       .Where(s => s.Calle == tblProveedorDirecciones.Calle && s.CodigoPostal == tblProveedorDirecciones.CodigoPostal)
                       .ToList();

                if (vDuplicado.Count == 0)
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblProveedorDirecciones.IdUsuarioModifico = Guid.Parse(f_user);

                    var fProveedor = (from c in _context.TblProveedores where c.IdProveedor == tblProveedorDirecciones.IdProveedor select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblProveedorDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblProveedorDirecciones.FechaRegistro = DateTime.Now;
                    tblProveedorDirecciones.IdEstatusRegistro = 1;

                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblProveedorDirecciones.Colonia).FirstOrDefault();
                    tblProveedorDirecciones.IdColonia = !string.IsNullOrEmpty(tblProveedorDirecciones.Colonia) ? tblProveedorDirecciones.Colonia : tblProveedorDirecciones.Colonia;
                    tblProveedorDirecciones.Colonia = !string.IsNullOrEmpty(tblProveedorDirecciones.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblProveedorDirecciones.Colonia;
                    tblProveedorDirecciones.Calle = !string.IsNullOrEmpty(tblProveedorDirecciones.Calle) ? tblProveedorDirecciones.Calle.ToUpper().Trim() : tblProveedorDirecciones.Calle;
                    tblProveedorDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblProveedorDirecciones.LocalidadMunicipio) ? tblProveedorDirecciones.LocalidadMunicipio.ToUpper().Trim() : tblProveedorDirecciones.LocalidadMunicipio;
                    tblProveedorDirecciones.Ciudad = !string.IsNullOrEmpty(tblProveedorDirecciones.Ciudad) ? tblProveedorDirecciones.Ciudad.ToUpper().Trim() : tblProveedorDirecciones.Ciudad;
                    tblProveedorDirecciones.Estado = !string.IsNullOrEmpty(tblProveedorDirecciones.Estado) ? tblProveedorDirecciones.Estado.ToUpper().Trim() : tblProveedorDirecciones.Estado;

                    _context.SaveChanges();
                    _context.Add(tblProveedorDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Success("Registro creado con éxito", 5);
                }
                else
                {
                    //_notifyService.Custom("Custom Notification - closes in 5 seconds.", 5, "whitesmoke", "fa fa-gear");
                    _notyf.Warning("Favor de validar, existe una Direccion con el mismo nombre", 5);
                }
            }
            else
            {
                _notyf.Error("Error en la validacion de campos", 5);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: TblProveedorDirecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<TblProveedor> ListaProveedor = new List<TblProveedor>();
            ListaProveedor = (from c in _context.TblProveedores select c).Distinct().ToList();
            ViewBag.ListaProveedor = ListaProveedor;

            List<CatTipoDireccion> ListaTipoDireccion = new List<CatTipoDireccion>();
            ListaTipoDireccion = (from c in _context.CatTipoDirecciones select c).Distinct().ToList();
            ViewBag.ListaTipoDireccion = ListaTipoDireccion;

            List<CatEstatus> ListaCatEstatus = new List<CatEstatus>();
            ListaCatEstatus = (from c in _context.CatEstatus select c).Distinct().ToList();
            ViewBag.ListaCatEstatus = ListaCatEstatus;
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones.FindAsync(id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }
            return View(tblProveedorDirecciones);
        }

        // POST: TblProveedorDirecciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProveedorDirecciones,IdTipoDireccion,Calle,CodigoPostal,IdColonia,Colonia,LocalidadMunicipio,Ciudad,Estado,CorreoElectronico,Telefono,IdProveedor,IdEstatusRegistro")] TblProveedorDireccion tblProveedorDirecciones)
        {
            if (id != tblProveedorDirecciones.IdProveedorDirecciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var f_user = _userService.GetUserId();
                    var isLoggedIn = _userService.IsAuthenticated();
                    tblProveedorDirecciones.IdUsuarioModifico = Guid.Parse(f_user);
                    var fProveedor = (from c in _context.TblProveedores where c.IdProveedor == tblProveedorDirecciones.IdProveedor select c).Distinct().ToList();
                    var fTipoDireccion = (from c in _context.CatTipoDirecciones where c.IdTipoDireccion == tblProveedorDirecciones.IdTipoDireccion select c).Distinct().ToList();
                    tblProveedorDirecciones.FechaRegistro = DateTime.Now;
                    tblProveedorDirecciones.IdEstatusRegistro = 1;

                    var strColonia = _context.CatCodigosPostales.Where(s => s.IdAsentaCpcons == tblProveedorDirecciones.Colonia).FirstOrDefault();
                    tblProveedorDirecciones.IdColonia = !string.IsNullOrEmpty(tblProveedorDirecciones.Colonia) ? tblProveedorDirecciones.Colonia : tblProveedorDirecciones.Colonia;
                    tblProveedorDirecciones.Colonia = !string.IsNullOrEmpty(tblProveedorDirecciones.Colonia) ? strColonia.Dasenta.ToUpper().Trim() : tblProveedorDirecciones.Colonia;
                    tblProveedorDirecciones.Calle = !string.IsNullOrEmpty(tblProveedorDirecciones.Calle) ? tblProveedorDirecciones.Calle.ToUpper().Trim() : tblProveedorDirecciones.Calle;
                    tblProveedorDirecciones.LocalidadMunicipio = !string.IsNullOrEmpty(tblProveedorDirecciones.LocalidadMunicipio) ? tblProveedorDirecciones.LocalidadMunicipio.ToUpper().Trim() : tblProveedorDirecciones.LocalidadMunicipio;
                    tblProveedorDirecciones.Ciudad = !string.IsNullOrEmpty(tblProveedorDirecciones.Ciudad) ? tblProveedorDirecciones.Ciudad.ToUpper().Trim() : tblProveedorDirecciones.Ciudad;
                    tblProveedorDirecciones.Estado = !string.IsNullOrEmpty(tblProveedorDirecciones.Estado) ? tblProveedorDirecciones.Estado.ToUpper().Trim() : tblProveedorDirecciones.Estado;

                    _context.SaveChanges();
                    _context.Update(tblProveedorDirecciones);
                    await _context.SaveChangesAsync();
                    _notyf.Warning("Registro actualizado con éxito", 5);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProveedorDireccionesExists(tblProveedorDirecciones.IdProveedorDirecciones))
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
            return View(tblProveedorDirecciones);
        }

        // GET: TblProveedorDirecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProveedorDirecciones = await _context.TblProveedorDirecciones
                .FirstOrDefaultAsync(m => m.IdProveedorDirecciones == id);
            if (tblProveedorDirecciones == null)
            {
                return NotFound();
            }

            return View(tblProveedorDirecciones);
        }

        // POST: TblProveedorDirecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProveedorDirecciones = await _context.TblProveedorDirecciones.FindAsync(id);
            tblProveedorDirecciones.IdEstatusRegistro = 2;
            _context.SaveChanges();
            await _context.SaveChangesAsync();
            _notyf.Error("Registro desactivado con éxito", 5);
            return RedirectToAction(nameof(Index));
        }

        private bool TblProveedorDireccionesExists(int id)
        {
            return _context.TblProveedorDirecciones.Any(e => e.IdProveedorDirecciones == id);
        }
    }
}