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
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            nDbContext context,
            IEmailSender emailSender, INotyfService notyf, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
            _notyf = notyf;
            _userService = userService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Display(Name = "Nombre (s)")]
            public string Nombres { get; set; }

            [Display(Name = "Apellido Paterno")]
            public string ApellidoPaterno { get; set; }

            [Display(Name = "Apellido Materno")]
            public string ApellidoMaterno { get; set; }

            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Display(Name = "Confirmar contraseña")]

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

            if (Input.Password.Length < 2 || Input.Password.Length >= 8)
            {
                if (Input.Password == Input.ConfirmPassword)
                {
                    MailAddress address = new MailAddress(Input.Email);
                    string userName = address.User;
                    var user = new ApplicationUser
                    {
                        UserName = userName,
                        Email = Input.Email,
                        Nombres = Input.Nombres.ToUpper().Trim(),
                        ApellidoPaterno = Input.ApellidoPaterno.ToUpper().Trim(),
                        ApellidoMaterno = Input.ApellidoMaterno.ToUpper().Trim(),
                        FechaRegistro = DateTime.Now,
                        IdEstatusRegistro = 1
                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        var nIdUsuario = Guid.Parse(user.Id);
                        var tblUsuario = _context.TblUsuarios.ToList();
                        if (tblUsuario.Count == 0)
                        {
                            var addUsuariosU = new TblUsuario
                            {
                                IdUsuario = nIdUsuario,
                                Nombres = Input.Nombres.ToUpper().Trim(),
                                ApellidoPaterno = Input.ApellidoPaterno.ToUpper().Trim(),
                                ApellidoMaterno = Input.ApellidoMaterno.ToUpper().Trim(),
                                FechaNacimiento = DateTime.Now,
                                IdUsuarioModifico = Guid.Empty,
                                IdCorpCent = 1,
                                IdArea = 1,
                                IdPerfil = 1,
                                IdRol = 2,
                                CorreoAcceso = user.Email,
                                FechaRegistro = DateTime.Now,
                                IdEstatusRegistro = 1
                            };
                            _context.Add(addUsuariosU);
                        }
                        else
                        {
                            var addUsuarios = new TblUsuario
                            {
                                IdUsuario = nIdUsuario,
                                Nombres = Input.Nombres.ToUpper().Trim(),
                                ApellidoPaterno = Input.ApellidoPaterno.ToUpper().Trim(),
                                ApellidoMaterno = Input.ApellidoMaterno.ToUpper().Trim(),
                                FechaNacimiento = DateTime.Now,
                                IdUsuarioModifico = Guid.Empty,
                                IdCorpCent = 1,
                                CorreoAcceso = user.Email,
                                FechaRegistro = DateTime.Now,
                                IdEstatusRegistro = 1
                            };
                            _context.Add(addUsuarios);
                        }

                        await _context.SaveChangesAsync();
                        var isLoggedIn = _userService.IsAuthenticated();
                        if (isLoggedIn)
                        {
                            var f_user = _userService.GetUserId();
                            var vUsuarios = _context.TblUsuarios
                                    .Where(s => s.IdUsuario == Guid.Parse(f_user) && s.IdPerfil == 3 && s.IdRol == 2 && s.IdCorpCent == 2)
                                    .ToList();
                            if (vUsuarios.Count == 1)
                            {
                                var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == nIdUsuario);
                                fIdUsuario.IdCorpCent = 2;
                                fIdUsuario.IdCorporativo = vUsuarios[0].IdCorporativo;
                                _context.Update(fIdUsuario);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                var fIdUsuario = await _context.TblUsuarios.FirstOrDefaultAsync(m => m.IdUsuario == nIdUsuario);
                                var f_corporativo = await _context.TblCorporativos.FirstOrDefaultAsync();
                                fIdUsuario.IdCorpCent = 1;
                                fIdUsuario.IdCorporativo = f_corporativo.IdCorporativo;
                                _context.Update(fIdUsuario);
                                await _context.SaveChangesAsync();
                            }
                        }
                        _notyf.Success("Registro creado con éxito", 5);
                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page("/TblUsuarios/Index", pageHandler: null,
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
                        if (error.Description == "Passwords must have at least one non alphanumeric character.")
                        {
                            _notyf.Warning("Las contraseñas deben tener al menos un carácter no alfanumérico", 5);
                        }
                        if (error.Description == "")
                        {
                            _notyf.Warning("Err", 5);
                        }
                    }
                }
                else
                {
                    _notyf.Warning("Las contraseñas no coinciden, favor de revisar", 5);
                }
            }
            else
            {
                _notyf.Warning("La Contraseña debe de contenr entre 2 a 8 caracteres, favor de revisar.", 5);
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
