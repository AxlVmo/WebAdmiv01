using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebAdmin.Models
{
    public partial class CatCodigosPostal

    {
        [Key]
        [Column("IdCodigosPostales")]
        [Display(Name = "ID IdCodigosPostales")]
        public int IdCodigosPostales { get; set; }

        [DataType(DataType.Text)]
        public string Dcodigo { get; set; }

        [DataType(DataType.Text)]
        public string Dasenta { get; set; }

        [DataType(DataType.Text)]
        public string DtipoAsenta { get; set; }

        [DataType(DataType.Text)]
        public string Dmnpio { get; set; }

        [DataType(DataType.Text)]
        public string Destado { get; set; }

        [DataType(DataType.Text)]
        public string Dciudad { get; set; }

        [DataType(DataType.Text)]
        public string Dcp { get; set; }

        [DataType(DataType.Text)]
        public string Cestado { get; set; }

        [DataType(DataType.Text)]
        public string Coficina { get; set; }

        [DataType(DataType.Text)]
        public string Ccp { get; set; }

        [DataType(DataType.Text)]
        public string CtipoAsenta { get; set; }

        [DataType(DataType.Text)]
        public string Cmnpio { get; set; }

        [DataType(DataType.Text)]
        public string IdAsentaCpcons { get; set; }

        [DataType(DataType.Text)]
        public string Dzona { get; set; }

        [DataType(DataType.Text)]
        public string CcveCiudad { get; set; }
    }
}