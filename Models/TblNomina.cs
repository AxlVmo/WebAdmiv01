using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblNomina
    {
        [Key]

        public int IdNomina { get; set; }
        [Display(Name = "Usuario")]
        public Guid IdUsuario { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NominaDesc { get; set; }

        [Display(Name = "Remuneracion")]
        public double UsuarioRemuneracion { get; set; }

        [Display(Name = "Tipo Contratacion")]
        [NotMapped]
        public int IdTipoContratacion { get; set; }

        [Display(Name = "Tipo Pago")]
        [NotMapped]
        public int IdTipoPago { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}