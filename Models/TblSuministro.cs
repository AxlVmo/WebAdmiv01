using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblSuministro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSuministro { get; set; }

        [NotMapped]
        public string CentroDesc { get; set; }

        [Display(Name = "Tipo Suministro")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoSuministro { get; set; }

        [Display(Name = "Tipo Suministro")]
        [NotMapped]
        public string TipoSuministroDesc { get; set; }

        [Display(Name = "Suministro")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string SuministroDesc { get; set; }

        [Display(Name = "Numero de Referencia")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NumeroReferencia { get; set; }

        [Display(Name = "Fecha de Facturacion")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FechaFacturacion { get; set; }

        [Display(Name = "Monto Suministro")]
        [Required(ErrorMessage = "Campo Requerido")]
        public double MontoSuministro { get; set; }

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