using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblAlumno
    {
        [Key]
        public Guid IdAlumno { get; set; }

        [Display(Name = "Tipo Alumno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdTipoAlumno { get; set; }

        [Display(Name = "Nombre Alumno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreAlumno { get; set; }

        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "ApellidoMaterno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPerfil { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdRol { get; set; }

        [Display(Name = "Correo Electronico")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Clave Acceso")]
        public string ClaveAcceso { get; set; }

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

        [Column("FechaAcceso")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Acceso")]
        public DateTime FechaAcceso { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto
        {
            get
            {
                return NombreAlumno + ", " + ApellidoMaterno + " " + ApellidoMaterno;
            }
        }
    }
}