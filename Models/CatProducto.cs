using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class CatProducto
    {
        [Key]
        public int IdProducto { get; set; }

        [Display(Name = "Codigo Interno")]
        public string CodigoInterno { get; set; }

        [Display(Name = "Codigo Externo")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string CodigoExterno { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdCategoria { get; set; }

        [Display(Name = "Categoria")]
        [NotMapped]
        public string CategoriaDesc { get; set; }

        [Display(Name = "Descripcion Producto")]
        public string DescProducto { get; set; }

        [Display(Name = "Minima")]
        public int CantidadMinima { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal ProductoPrecioUno { get; set; }

        [Display(Name = "Porcentaje")]
        public decimal PorcentajePrecioUno { get; set; }

        public decimal SubCosto { get; set; }
        public decimal Costo { get; set; }

        [Display(Name = "Usuario Modifico")]
        public Guid IdUsuarioModifico { get; set; }

        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int IdEstatusRegistro { get; set; }
    }
}