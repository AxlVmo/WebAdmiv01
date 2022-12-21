using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class RelCompraPago
    {
        [Display(Name = "ID Compras Pagos")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRelComprasPago { get; set; }

       [Display(Name = "Tipo de Pago")]

        public int IdTipoPago { get; set; }

        [Display(Name = "Codigo / Referencia")]
        public string FolioPago { get; set; }

        [Display(Name = "Descuento")]
        public double CantidadPago { get; set; }

      [Display(Name = "Descuento %")]
        public double Diferencia { get; set; }

        [Display(Name = "Total Precio Producto")]
        public double Total { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        
        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }

        public Guid IdCompra { get; set; }
    }
}