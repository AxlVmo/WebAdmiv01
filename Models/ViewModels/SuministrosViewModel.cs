using System.Collections.Generic;
using WebAdmin.Models;

namespace WebAdmin.ViewModels
{
    public class SuministrosViewModel
    {
        public TblSuministro TblSuministros { get; set; }
        public List<RelSuministroPago> RelSuministroPagos { get; set; }
    }
}