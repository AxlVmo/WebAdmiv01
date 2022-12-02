using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblPresupuesto
    {
        [Key]

        public Guid IdPresupuesto { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo Presupuesto")]

        public int IdTipoPresupuesto { get; set; }

        [Display(Name = "Tipo Presupuesto")]
        [NotMapped]
        public string TipoPresupuestoDesc { get; set; }

        [Display(Name = "SubTipo Presupuesto")]

        public int IdSubTipoPresupuesto { get; set; }

        [Display(Name = "SubTipo Presupuesto")]
        [NotMapped]
        public string SubTipoPresupuestoDesc { get; set; }

        [Display(Name = "Descripcion")]
        [DataType(DataType.Text)]

        public string PresupuestoDesc { get; set; }

        [Display(Name = "Mes de Perido")]

        public int IdMes { get; set; }
        [Display(Name = "Mes de Periodo")]
        [NotMapped]
        public string MesDesc { get; set; }
        [Display(Name = "Numero de Referencia")]

        public string NumeroReferencia { get; set; }

        [Display(Name = "Dia de Corte")]

        public int DiaCorte { get; set; }
        [Display(Name = "Periodo de Facturacion")]

        public int IdPeriodo { get; set; }
        [Display(Name = "Periodo de Facturacion")]
        [NotMapped]
        public string PeriodoDesc { get; set; }

        [Display(Name = "Monto Presupuesto")]

        public double MontoPresupuesto { get; set; }
        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public int IdTipoPago { get; set; }
        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public string TipoPagoDesc { get; set; }
        [Display(Name = "Folio de Pago")]
        [NotMapped]
        public string FolioPago { get; set; }

        [Display(Name = "Monto de Pago")]
        [NotMapped]
        public double MontoPresupuestoReal { get; set; }

        [Display(Name = "Comentarios")]
        [NotMapped]
        public string Comentarios { get; set; }

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