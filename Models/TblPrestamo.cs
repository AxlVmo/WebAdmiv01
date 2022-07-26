using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblPrestamo
    {
        [Key]
        public Guid IdPrestamo { get; set; }
        [Display(Name = "Tipo Prestamo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoPrestamo { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PrestamoDesc { get; set; }
        [Display(Name = "Cantidad de Deposito")]
        public double CantidadPrestamo { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioPrestamo { get; set; }
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]

        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Correo de Acceso")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}
