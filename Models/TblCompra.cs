using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblCompra
    {
        [Display(Name = "ID Cotización")]
        [Key]
        public Guid IdCompra { get; set; }
        [Display(Name = "Nombre Proveedor")]
        public Guid IdProveedorCompra { get; set; }

        [Display(Name = "Nombre Proveedor")]
        [NotMapped]

        public string NombreProveedorCompra { get; set; }

        [Display(Name = "Tipo de Compra")]
        public int IdTipoCompra { get; set; }

        [Display(Name = "Tipo de Compra")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoCompraDesc { get; set; }
        [Display(Name = "Fecha Compra")]
        [DataType(DataType.Date)]
        public DateTime FechaCompra { get; set; }
        [Display(Name = "Descripcion")]
        public int CompraDesc { get; set; }
        [Display(Name = "Folio Compra")]
        public int FolioCompra { get; set; }

        [Display(Name = "Proveedor Compra")]
        public int ProveedorCompra { get; set; }

        [Display(Name = "Tipo de Pago")]

        public int IdTipoPago { get; set; }

        [Display(Name = "Codigo / Referencia")]
        public string CodigoPago { get; set; }
        [Display(Name = "Codigo / Referencia")]
        public double MontoPago { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }
        [Display(Name = "Proveedor Compra")]
        public int NombreUsuarioCompra { get; set; }

        [Display(Name = "Corporativo / Centro")]

        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]

        public int IdEstatusRegistro { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        public virtual List<RelCompraProducto> RelCompraProductos { get; set; }
    }
}