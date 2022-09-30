
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class CatTipoRecurso
    {
        [Key]
        public int IdTipoRecurso { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        
        public string TipoRecursoDesc { get; set; }

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