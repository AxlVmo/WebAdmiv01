using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class VentasViewModel
    {
        public TblVenta TblVentas { get; set; }
        public List<RelVentaProducto> RelVentaProductos { get; set; }
        public List<RelVentaPagos> RelVentaPagos { get; set; }
    }
}