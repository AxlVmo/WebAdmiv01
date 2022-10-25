using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class RelVentaPagos
    {
        [Display(Name = "ID Ventas Pagos")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRelVentasPago { get; set; }

        [Display(Name = "Tipo de Pago")]

        public int IdTipoPago { get; set; }

        [Display(Name = "Fecha Alterna")]
        [DataType(DataType.Date)]
        public DateTime FechaAlternaPago { get; set; }

        [Display(Name = "Codigo Referencia")]
        public string CodigoReferencia { get; set; }

         [Display(Name = "Descuento")]
        public double CantidadPago { get; set; }

        [Display(Name = "Descuento %")]
        public int Descuento { get; set; }

        [Display(Name = "Total Precio Producto")]
        public double Total { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        
        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }

        public Guid IdVenta { get; set; }
    }
}