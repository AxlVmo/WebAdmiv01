using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class RelVentasPagos
    {
        [Display(Name = "ID Ventas Pagos")]
        [Key]
        public Guid IdRelVentasPago { get; set; }

        [Display(Name = "Codigo Referencia")]
        public string CodigoReferencia { get; set; }

        [Display(Name = "Descuento")]
        public int CantidadPago { get; set; }

        [Display(Name = "ID Cotización")]
        public Guid IdVenta { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}