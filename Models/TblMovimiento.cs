using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAdmin.Models
{
    public class TblMovimiento
    {
        [Key]
        public Guid IdMovimiento { get; set; }
        [Display(Name = "Tipo de Movimiento")]
        public int IdTipoMovimiento { get; set; }
        [Display(Name = "SubTipo de Movimiento")]
        public int IdSubTipoMovimiento { get; set; }
         [Display(Name = "Caracteristica de Movimiento")]
        public int IdCaracteristicaMovimiento { get; set; }
         [Display(Name = "Tipo de Recurso")]
        public int IdTipoRecurso { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoMovimientoDesc { get; set; }
         [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string SubTipoMovimientoDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoRecursoDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
         [NotMapped]
        public string CaracteristicaMovimientoDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]

        public string MovimientoDesc { get; set; }

        [Display(Name = "Monto Movimiento")]
        
        public double MontoMovimiento { get; set; }
        [Display(Name = "ID Referencia de Movimiento")]
        public Guid IdRefereciaMovimiento { get; set; }

        [Display(Name = "Referencia de Movimiento")]
        
        public double RefereciaMovimiento { get; set; }

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