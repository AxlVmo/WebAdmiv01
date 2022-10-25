using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public partial class TblPresupuestoMovimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdPresupuestoMovimiento { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo PresupuestoMovimiento")]
        
        public int IdTipoPresupuesto { get; set; }

        [Display(Name = "Tipo PresupuestoMovimiento")]
        [NotMapped]
        public string TipoPresupuestoDesc { get; set; }

        [Display(Name = "PresupuestoMovimiento")]
        [DataType(DataType.Text)]
        
        public string PresupuestoMovimientoDesc { get; set; }

        [Display(Name = "Numero de Referencia")]
        
        public string NumeroReferencia { get; set; }

        [Display(Name = "Dia de Corte")]
        
        public int DiaCorte { get; set; }
        [Display(Name = "Periodo de Facturacion")]
        
        public int IdPeriodo { get; set; }
        [Display(Name = "Periodo de Facturacion")]
        [NotMapped]
        public string PeriodoDesc { get; set; }

        [Display(Name = "Monto PresupuestoMovimiento")]
        
        public double MontoPresupuestoMovimiento { get; set; }
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

        public virtual List<RelPresupuestoMovimientoPago> RelPresupuestoMovimientoPagos { get; set; }
    }
}