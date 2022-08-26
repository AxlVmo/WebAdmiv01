﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAdmin.Models
{
    public class TblBanco
    {
        [Key]
        [Display(Name = "Id Banco")]
        public Guid IdBanco { get; set; }

        [Display(Name = "Cantidad de Deposito")]
        public double CantidadDeposito { get; set; }

        [Display(Name = "Corporativo / Centro")]
        public int IdCorpCent { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Display(Name = "Corporativo / Centro")]
        
        public Guid IdUCorporativoCentro { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        
        public int IdEstatusRegistro { get; set; }
    }
}