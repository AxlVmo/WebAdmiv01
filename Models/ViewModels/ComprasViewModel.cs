using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class ComprasViewModel
    {
        public TblCompra TblCompras { get; set; }
        public List<RelCompraProducto> RelCompraProductos { get; set; }
    }
}