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
        
        public int IdTipoAlumno { get; set; }
        [Display(Name = "Tipo Alumno")]
        [NotMapped]
        public string TipoAlumnoDesc { get; set; }
        [Display(Name = "Genero")]
        
        public int IdGenero { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Nivel Escolar")]
        
        public int IdNivelEscolar { get; set; }
        [NotMapped]
        public string NivelEscolarDesc { get; set; }

         [Display(Name = "Nombre Tutor")]
        
        public string NombreTutor { get; set; }

        [Display(Name = "Apellido Paterno Tutor")]
        
        public string ApellidoPaternoTutor { get; set; }

        [Display(Name = "Apellido Materno Tutor")]
        
        public string ApellidoMaternoTutor { get; set; }

        [Display(Name = "Nombre Alumno")]
        
        public string NombreAlumno { get; set; }

        [Display(Name = "Apellido Paterno")]
        
        public string ApellidoPaterno { get; set; }

        [Display(Name = "ApellidoMaterno")]
        
        public string ApellidoMaterno { get; set; }
        [Display(Name = "Corporativo / Centro")]
        
        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Correo Electrónico")]
        public string CorreoAcceso { get; set; }

        [Display(Name = "Teléfono")]
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

        [Display(Name = "Código Postal")]
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