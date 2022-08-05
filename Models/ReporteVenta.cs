using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class ReporteVenta
    {
        [Display(Name = "ID Cotización")]
        [Key]
        public Guid IdVenta { get; set; }

        [Display(Name = "Numero Cotización")]
        public int NumeroVenta { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioVenta { get; set; }

        [Display(Name = "Centro")]
        public Guid IdCentro { get; set; }

        [Display(Name = "Alumno")]
        public Guid IdCliente { get; set; }

        [Display(Name = "Tipo de Pago")]
        public int IdTipoPago { get; set; }

        [Display(Name = "Codigo / Referencia")]
        public string CodigoPago { get; set; }

        [Display(Name = "Fecha Altera")]
        [DataType(DataType.Date)]
        public DateTime FechaAlterna { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        public virtual List<RelVentaProducto> RelVentaProductos { get; set; }
    }

    public class ReporteVentaProducto
    {
        [Display(Name = "ID Ventas Productos")]
        [Key]
        public Guid IdRelVentaProducto { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Display(Name = "Producto")]
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
        public int IdEstatusRegistro { get; set; }

        public Guid IdVenta { get; set; }
    }
}