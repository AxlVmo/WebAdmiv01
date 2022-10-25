using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class CatSubTipoPresupuesto
    {
        [Key]
        public int IdSubTipoPresupuesto { get; set; }
        [Display(Name = "Tipo de Presupuesto")]
        public int IdTipoPresupuesto { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [NotMapped]

        public string TipoPresupuestoDesc { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]

        public string SubTipoPresupuestoDesc { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]

        public int IdEstatusRegistro { get; set; }



    }
}