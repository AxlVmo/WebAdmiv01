using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAdmin.Models
{
    public class TblGasto
    {
        [Key]
        public Guid IdGasto { get; set; }
        [Display(Name = "Tipo de Gasto")]
        public int IdTipoGasto { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]
        public string TipoGastoDesc { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]

        public string GastoDesc { get; set; }

        [Display(Name = "Monto Suministro")]
        
        public double MontoGasto { get; set; }
        [Display(Name = "ID Referencia de Gasto")]
        public Guid IdRefereciaGasto { get; set; }

        [Display(Name = "Referencia de Gasto")]
        
        public double RefereciaGasto { get; set; }

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