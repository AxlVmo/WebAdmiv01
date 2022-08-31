using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblVenta
    {
        [Display(Name = "ID Venta")]
        [Key]
        public Guid IdVenta { get; set; }
        [Display(Name = "Tipo de Venta")]
        public int IdTipoVenta { get; set; }

        [NotMapped]
        [Display(Name = "Tipo de Venta")]

        public string TipoVentaDesc { get; set; }


        [Display(Name = "Numero Venta")]
        public int NumeroVenta { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioVenta { get; set; }

        [Display(Name = "Centro")]
        public Guid IdCentro { get; set; }

        [Display(Name = "Alumno")]

        public Guid IdCliente { get; set; }
        [Display(Name = "Nombre Alumno")]
        [NotMapped]
        public string NombreCompletoAlumno { get; set; }

        [Display(Name = "Tipo de Pago")]

        public int IdTipoPago { get; set; }

        [Display(Name = "Codigo / Referencia")]
        public string CodigoPago { get; set; }

        [Display(Name = "Fecha Alterna")]
        [DataType(DataType.Date)]
        public DateTime FechaAlterna { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]

        public Guid IdUCorporativoCentro { get; set; }
        [Display(Name = "Centro")]
        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]

        public int IdEstatusRegistro { get; set; }

        [Display(Name = "Total")]
        public double Total { get; set; }

        public virtual List<RelVentaProducto> RelVentaProductos { get; set; }
    }
}