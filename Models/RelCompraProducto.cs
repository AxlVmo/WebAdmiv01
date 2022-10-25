using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class RelCompraProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Compras Productos")]
        [Key]
        public int IdRelCompraProducto { get; set; }
        
        [Display(Name = "Articulo Descripción")]
        [DataType(DataType.Text)]

        public string ProdServDesc { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio")]
        public double Precio { get; set; }

        [Display(Name = "Total Costo Producto")]
        public double TotalPrecio { get; set; }

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

        public Guid IdCompra { get; set; }
    }
}