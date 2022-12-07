using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblProveedorDireccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedorDirecciones { get; set; }

        [ForeignKey("CatTipoDireccion")]
        [Display(Name = "Tipo Direccion")]
        
        public int IdTipoDireccion { get; set; }

        [Display(Name = "Tipo Direccion")]
        [NotMapped]
        public string TipoDireccionDesc { get; set; }

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

        [Display(Name = "Correo Electrónico")]
        
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [ForeignKey("TblProveedor")]
        [Display(Name = "Proveedor")]
        public Guid IdProveedor { get; set; }

        [NotMapped]
        [Display(Name = "Nombre Proveedor")]
        public string NombreProveedor { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}