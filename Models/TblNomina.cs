using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblNomina
    {
        [Key]
        public int IdNomina { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }
        [Display(Name = "Usuario")]
        [NotMapped]
        public string UsuarioAsignado { get; set; }

        [Display(Name = "Usuario")]
        
        public Guid IdUsuarioRemuneracion { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        
        public string NominaDesc { get; set; }

        [Display(Name = "Monto")]
        
        public double UsuarioRemuneracion { get; set; }

        [Display(Name = "Tipo Contratacion")]
        public int IdTipoContratacion { get; set; }
        [NotMapped]
        public string TipoContratacionDesc { get; set; }
        [Display(Name = "Tipo Pago")]
        
        public int IdTipoPago { get; set; }
        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public string TipoPagoDesc { get; set; }
         [Display(Name = "Codigo / Referencia")]
        public string CodigoPago { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]
        
        public Guid IdUCorporativoCentro { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}