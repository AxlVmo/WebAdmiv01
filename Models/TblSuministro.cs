using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblSuministro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdSuministro { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo Suministro")]
        
        public int IdTipoSuministro { get; set; }

        [Display(Name = "Tipo Suministro")]
        [NotMapped]
        public string TipoSuministroDesc { get; set; }

        [Display(Name = "Suministro")]
        [DataType(DataType.Text)]
        
        public string SuministroDesc { get; set; }

        [Display(Name = "Numero de Referencia")]
        
        public string NumeroReferencia { get; set; }

        [Display(Name = "Dia de Facturacion")]
        
        public int DiaFacturacion { get; set; }
        [Display(Name = "Periodo de Facturacion")]
        
        public int IdPeriodo { get; set; }
        [Display(Name = "Periodo de Facturacion")]
        [NotMapped]
        public string PeriodoDesc { get; set; }

        [Display(Name = "Monto Suministro")]
        
        public double MontoSuministro { get; set; }
        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public int IdTipoPago { get; set; }
        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public string TipoPagoDesc { get; set; }

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

        public virtual List<RelSuministroPago> RelSuministroPagos { get; set; }
    }
}