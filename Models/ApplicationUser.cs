using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Nombre Empresa")]
        public string NombreEmpresa { get; set; }

        [Display(Name = "Area")]
        public int IdArea { get; set; }

        [Display(Name = "Genero")]
        public int IdGenero { get; set; }

        [Display(Name = "Perfil")]
        public int IdPerfil { get; set; }

        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Correo de Acceso")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Rol")]
        public byte[] ProfilePicture { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}