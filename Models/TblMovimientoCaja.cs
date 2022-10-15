using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAdmin.Models
{
    public class TblMovimientoCaja
    {
        [Key]
        public Guid IdMovimientoCaja { get; set; }
        [Display(Name = "Tipo de Movimiento Caja")]
        public int IdTipoMovimientoCaja { get; set; }
        [Display(Name = "SubTipo de Movimiento Caja")]
        public int IdSubTipoMovimientoCaja { get; set; }
        [Display(Name = "Caracteristica de Movimiento Caja")]
        public int IdCaracteristicaMovimientoCaja { get; set; }
        [Display(Name = "Tipo de Recurso")]
        public int IdTipoRecurso { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoMovimientoCajaDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string SubTipoMovimientoCajaDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoRecursoDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string CaracteristicaMovimientoCajaDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]

        public string MovimientoCajaDesc { get; set; }

        [Display(Name = "Monto Movimiento Caja")]

        public double MontoMovimientoCaja { get; set; }
        [Display(Name = "ID Referencia de Movimiento Caja")]
        public Guid IdRefereciaMovimientoCaja { get; set; }

        [Display(Name = "Referencia de Movimiento Caja")]

        public double RefereciaMovimientoCaja { get; set; }

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
    }
}