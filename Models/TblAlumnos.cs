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
        [Display(Name = "Genero")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdGenero { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Nivel Escolar")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdNivelEscolar { get; set; }
        [NotMapped]
        public string NivelEscolarDesc { get; set; }

         [Display(Name = "Nombre Tutor")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreTutor { get; set; }

        [Display(Name = "Apellido Paterno Tutor")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoPaternoTutor { get; set; }

        [Display(Name = "Apellido Materno Tutor")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoMaternoTutor { get; set; }

        [Display(Name = "Nombre Alumno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreAlumno { get; set; }

        [Display(Name = "Apellido Paterno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "ApellidoMaterno")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Corporativo / Centro")]
        [Required(ErrorMessage = "Campo Requerido")]
        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Correo Electronico")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }
        [Display(Name = "Telefono Tutor")]
        public string TelefonoTutor { get; set; }

        [Display(Name = "CURP")]
        public string AlumnoCurp { get; set; }

        [Display(Name = "Grupo Sanguineo")]
        public string AlumnoGrupoSanguineo { get; set; }

        [Display(Name = "Clave Acceso")]
        public string ClaveAcceso { get; set; }
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Display(Name = "Codigo Postal")]
        public string CodigoPostal { get; set; }

        public string IdColonia { get; set; }

        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Display(Name = "Localidad / Municipio")]
        public string LocalidadMunicipio { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

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