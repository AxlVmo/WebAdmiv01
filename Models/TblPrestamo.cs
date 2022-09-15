using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblPrestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        [Display(Name = "Folio Prestamo")]
        public string FolioPrestamo { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo Prestamo")]
        
        public int IdTipoPrestamo { get; set; }
        [NotMapped]
        public string TipoPrestamoDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        
        public string PrestamoDesc { get; set; }

        [Display(Name = "Cantidad de Deposito")]
        
        public double CantidadPrestamo { get; set; }

        [Display(Name = "Periodo Amortizacion")]
        
        public int IdPeriodoAmortiza { get; set; }

        [NotMapped]
        public string PeriodoAmortizaDesc { get; set; }

        [Display(Name = "Forma Pago")]
        
        public int IdTipoFormaPago { get; set; }

        [NotMapped]
        public string TipoFormaPagoDesc { get; set; }

        [Display(Name = "Centro")]
        
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public Guid IdCentroPrestamo { get; set; }

        [Display(Name = "Nombres")]
        
        
        public string Nombres { get; set; }

        
        [Display(Name = "Apellido Paterno")]
        
        public string ApellidoPaterno { get; set; }

        
        [Display(Name = "Apellido Materno")]
        
        public string ApellidoMaterno { get; set; }

        
        [Display(Name = "CURP")]
        
        public string curp { get; set; }

        
        [Display(Name = "INE")]
        
        public string ine { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]
        
        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}