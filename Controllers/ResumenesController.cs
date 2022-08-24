using AspNetCoreHero.ToastNotification.Abstractions;
// using FastReport;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{

    public class ResumenesController : Controller
    {
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public ResumenesController(nDbContext context, INotyfService notyf, IUserService userService)
        {
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }


        public IActionResult Index()
        {

            // var fNominaTotales = from a in _context.TblSuministros
            //                      where a.IdEstatusRegistro == 1
            //                      select new
            //                      {
            //                          fRegistros = _context.TblNominas.Where(a => a.IdEstatusRegistro == 1).Count(),
            //                          fMontos = _context.TblNominas.Where(p => p.IdUCorporativoCentro == fIdCentro.IdCentro).Select(i => Convert.ToDouble(i.UsuarioRemuneracion)).Sum()
            //                      };
            // var sResumen = fSuministrosTotales.Union(fNominaTotales);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }


    }
}