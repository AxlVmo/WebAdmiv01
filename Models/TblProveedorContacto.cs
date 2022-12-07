using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblProveedorContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProveedorContacto { get; set; }

        [Display(Name = "Perfil")]
        
        public int IdPerfil { get; set; }

        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }

        [Display(Name = "Nombre Contacto")]
        
        public string NombreProveedorContacto { get; set; }

        [Display(Name = "Correo Electrónico")]
        
        public string CorreoElectronico { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Telefono Movil")]
        public string TelefonoMovil { get; set; }

        [ForeignKey("TblProveedor")]
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