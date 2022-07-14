using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using WebAdmin.Data;
using WebAdmin.Models;
using WebAdmin.Services;

namespace WebAdmin.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly INotyfService _notyf;
        private readonly nDbContext _context;


        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            nDbContext context,
            IEmailSender emailSender, INotyfService notyf)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _notyf = notyf;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Campo Requerido")]
            [Display(Name = "Nombres")]
            public string Nombres { get; set; }
            [Required(ErrorMessage = "Campo Requerido")]
            [Display(Name = "Apellido Paterno")]
            public string ApellidoPaterno { get; set; }
            [Required(ErrorMessage = "Campo Requerido")]
            [Display(Name = "Apellido Materno")]
            public string ApellidoMaterno { get; set; }
            [Required(ErrorMessage = "Campo Requerido")]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Campo Requerido")]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Clave")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coincide.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Fecha Registro")]
            [DataType(DataType.Date)]
            public DateTime FechaRegistro { get; set; }
            [Display(Name = "Estatus")]
            public int IdEstatusRegistro { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                MailAddress address = new MailAddress(Input.Email);
                string userName = address.User;
                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = Input.Email,
                    Nombres = Input.Nombres.ToUpper(),
                    ApellidoPaterno = Input.ApellidoPaterno.ToUpper(),
                    ApellidoMaterno = Input.ApellidoMaterno.ToUpper(),
                    FechaRegistro = DateTime.Now,
                    IdEstatusRegistro = 1
                };
                var result = await _userManager.CreateAsync(user, Input.Password);


                var addUsuarios = new TblUsuario
                {
                    IdUsuario = Guid.Parse(user.Id),
                    Nombres = Input.Nombres.ToUpper(),
                    ApellidoPaterno = Input.ApellidoPaterno.ToUpper(),
                    ApellidoMaterno = Input.ApellidoMaterno.ToUpper(),
                    NombreUsuario = "Null",
                    FechaNacimiento = DateTime.Now,
                    IdUsuarioModifico = Guid.Empty,
                    CorreoAcceso = user.Email,
                    FechaRegistro = DateTime.Now,
                    IdEstatusRegistro = 1
                };
                _context.Add(addUsuarios);
                await _context.SaveChangesAsync();

                if (result.Succeeded)
                {
                    _notyf.Success("Registro creado con éxito", 5);
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
