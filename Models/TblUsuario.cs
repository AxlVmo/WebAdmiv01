using System;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblUsuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Display(Name = "Nombre (s)")]
        
        public string Nombres { get; set; }

        
        [Display(Name = "Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        
        [Display(Name = "Apellido Materno")]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Corporativo")]
        
        public Guid IdCorporativo { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Area")]
        
        public int IdArea { get; set; }

        [Display(Name = "Genero")]
        
        public int IdGenero { get; set; }

        [Display(Name = "Perfil")]
        
        public int IdPerfil { get; set; }

        [Display(Name = "Rol")]
        
        public int IdRol { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [Display(Name = "Correo de Acceso")]
        
        public string CorreoAcceso { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "CURP")]
        public string UsuarioCurp { get; set; }

        [Display(Name = "RFC")]
        public string UsuarioRfc { get; set; }

        [Display(Name = "NSS")]
        public string UsuarioNss { get; set; }

        [Display(Name = "Tipo Contratacion")]
        
        public int IdTipoContratacion { get; set; }

        [Display(Name = "Remuneracion")]
        
        public double UsuarioRemuneracion { get; set; }

        [Display(Name = "Tipo Forma Pago")]
        
        public int IdTipoFormaPago { get; set; }

        [Display(Name = "Estudios")]
        
        public int IdPersonalEstudio { get; set; }

        [Display(Name = "Fecha Contratacion")]
        
        [DataType(DataType.Date)]
        public DateTime FechaContratacion { get; set; }

        [Display(Name = "Tipo Direccion")]
        public int IdTipoDireccion { get; set; }

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

        [Display(Name = "Imagen de Perfil")]
        public byte[] ImagenPErfil { get; set; }

        [Display(Name = "Usuario")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}