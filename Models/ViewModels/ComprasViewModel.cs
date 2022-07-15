using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAdmin.Models;

namespace WebAdmin.ViewModels 
{
    public class ComprasViewModel
    {
          public TblCompra TblComprras { get; set; }
        public List<RelCompraProducto> RelCompraProductos { get; set; }
    }
}