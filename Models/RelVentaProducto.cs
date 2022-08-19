using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class RelVentaProducto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Ventas Productos")]
        [Key]
        public int IdRelVentaProducto { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Tipo Servicio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Categoria { get; set; }

        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string Producto { get; set; }

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
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }

        public Guid IdVenta { get; set; }
    }
}