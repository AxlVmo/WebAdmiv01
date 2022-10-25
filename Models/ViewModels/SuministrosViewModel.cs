using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class PresupuestoMovimientosViewModel
    {
        public TblPresupuestoMovimiento TblPresupuestoMovimiento { get; set; }
        public List<RelPresupuestoMovimientoPago> RelPresupuestoMovimientoPagos { get; set; }
    }
}