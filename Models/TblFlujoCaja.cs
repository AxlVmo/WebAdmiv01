using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAdmin.Models
{
    public class TblFlujoCaja
    {
        [Key]
        public Guid IdFlujoCaja { get; set; }
        [Display(Name = "Tipo de FlujoCaja")]
        public int IdTipoFlujoCaja { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoFlujoCajaDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]

        public string FlujoCajaDesc { get; set; }

        [Display(Name = "Monto Suministro")]
        
        public double MontoFlujoCaja { get; set; }
        [Display(Name = "ID Referencia de FlujoCaja")]
        public Guid IdRefereciaFlujoCaja { get; set; }

        [Display(Name = "Referencia de FlujoCaja")]
        
        public double RefereciaFlujoCaja { get; set; }

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