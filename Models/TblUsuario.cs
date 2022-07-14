using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblUsuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]

        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }
        
        [Display(Name = "Nombre Usuario")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Corporativo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdCorporativo { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdArea { get; set; }

        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdGenero { get; set; }

        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPerfil { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdRol { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Correo de Acceso")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[] ImagenPErfil { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioModifico { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}