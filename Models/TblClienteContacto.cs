﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class TblClienteContacto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdClienteContacto { get; set; }
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdPerfil { get; set; }
        [NotMapped]
        [Display(Name = "Perfil")]
        public string PerfilDesc { get; set; }
        [Display(Name = "Nombre Contacto")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string NombreClienteContacto { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "Campo Requerido")]

        public string CorreoElectronico { get; set; }
        [Display(Name = "Telefono")]

        public string Telefono { get; set; }
        [Display(Name = "Telefono Movil")]
        public string TelefonoMovil { get; set; }
        [ForeignKey("TblCliente")]
        public Guid IdCliente { get; set; }
        [NotMapped]
        [Display(Name = "Nombre Cliente")]
        public string NombreCliente { get; set; }
        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]

        public int IdEstatusRegistro { get; set; }

    }
}
