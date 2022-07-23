using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly nDbContext _context;
        private readonly INotyfService _notyf;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, nDbContext context, INotyfService notyf, IUserService userService)
        {
            _logger = logger;
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }


        public IActionResult Index()
        {
            var isLoggedIn = _userService.IsAuthenticated();
            if (isLoggedIn)
            {
                var fuser = _userService.GetUserId();

                var vUsuarios = _context.TblUsuarios
                        .Where(s => s.IdUsuario == Guid.Parse(fuser) && s.IdPerfil == 3 && s.IdRol == 2)
                        .ToList();
                if (vUsuarios.Count == 1)
                {
                    ViewBag.ActivaRol = 1;
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
