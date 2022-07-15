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

        [Display(Name = "Codigo Referencia")]
        public string CodigoReferencia { get; set; }

        [Display(Name = "Descuento")]
        public int CantidadPago { get; set; }

        [Display(Name = "ID Cotización")]
        public Guid IdCompra { get; set; }

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