using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class RelPresupuestoPago
    {
        [Display(Name = "ID PresupuestoMovimientos Pagos")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRelPresupuestoPago { get; set; }

        [Display(Name = "Tipo de Pago")]
        public int IdTipoPago { get; set; }
         [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoPagoDesc { get; set; }

        [Display(Name = "Fecha Alterna")]
        [DataType(DataType.Date)]
        public DateTime FechaAlternaPago { get; set; }

        [Display(Name = "Folio de Pago")]
        public string FolioPago { get; set; }

        [Display(Name = "Descuento")]
        public double MontoPresupuestoReal { get; set; }

         [Display(Name = "Comentarios")]
        public string Comentarios { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

         [Display(Name = "Corporativo / Centro")]

        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]

        public int IdEstatusRegistro { get; set; }

        public Guid IdPresupuesto { get; set; }
    }
}