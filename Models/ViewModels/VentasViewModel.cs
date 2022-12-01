using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class VentasViewModel
    {
        public TblVenta TblVentas { get; set; }
        public List<RelVentaServicio> RelVentaServicios { get; set; }
        public List<RelServicioPago> RelServicioPagos { get; set; }
    }
}