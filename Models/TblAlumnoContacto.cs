using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblAlumnoContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlumnoContacto { get; set; }

        [Display(Name = "Perfil")]
        
        public int IdPerfil { get; set; }

        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }

        [Display(Name = "Nombre Contacto")]
        
        public string NombreAlumnoContacto { get; set; }

        [Display(Name = "Correo Electrónico")]
        
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Telefono Movil")]
        public string TelefonoMovil { get; set; }

        [ForeignKey("TblAlumno")]
        public Guid IdAlumno { get; set; }

        [NotMapped]
        [Display(Name = "Nombre Alumno")]
        public string NombreAlumno { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}