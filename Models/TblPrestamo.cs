using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblPrestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo Prestamo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoPrestamo { get; set; }
        [NotMapped]
        public string TipoPrestamoDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PrestamoDesc { get; set; }

        [Display(Name = "Cantidad de Deposito")]
        public double CantidadPrestamo { get; set; }

        [Display(Name = "Periodo Amortizacion")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPeriodoAmortiza { get; set; }

        [NotMapped]
        public string PeriodoAmortizaDesc { get; set; }

        [Display(Name = "Forma Pago")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoFormaPago { get; set; }

        [NotMapped]
        public string TipoFormaPagoDesc { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioPrestamo { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Campo Requerido")]
        [NotMapped]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Apellido Paterno")]
        [NotMapped]
        public string ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "ApellidoMaterno")]
        [NotMapped]
        public string ApellidoMaterno { get; set; }

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