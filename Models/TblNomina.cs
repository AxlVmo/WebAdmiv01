using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class TblNomina
    {
        [Key]
        public int IdNomina { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioRemuneracion { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NominaDesc { get; set; }

        [Display(Name = "Remuneracion")]
        public double UsuarioRemuneracion { get; set; }

        [Display(Name = "Tipo Contratacion")]
        public int IdTipoContratacion { get; set; }
        [NotMapped]
        public string TipoContratacionDesc { get; set; }
        [Display(Name = "Tipo Pago")]
        public int IdTipoPago { get; set; }
        [NotMapped]
        public string TipoPagoDesc { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdUCorporativoCentro { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}