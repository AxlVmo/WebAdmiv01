using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class ComprasViewModel
    {
        public TblCompra TblComprras { get; set; }
        public List<RelCompraProducto> RelCompraProductos { get; set; }
    }
}