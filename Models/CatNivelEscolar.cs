﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAdmin.Models
{
    public class CatNivelEscolar
    {
        public CatNivelEscolar()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        [Key]
        public int IdNivelEscolar { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        
        public string NivelEscolarDesc { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}