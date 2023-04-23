using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tarea3_JasonTrejos.Models
{
    public class Productos
    {
        [Key]
        public int id_Producto { get; set; }

        [Required]
        [Display(Name = "Lote del Producto")]
        public string lote_Producto { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Fecha de Fabricación")]
        public DateTime fechaFabricacion_Producto { get; set; }

        [Required]
        [Display(Name ="Nombre del producto")]
        public string nombre_Producto { get; set; }

        [Required]
        [Display(Name ="Nombre del Proveedor")]
        public string nombre_Proveedor { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Fecha de caducidad")]
        public DateTime fechaCaducidad_Producto { get; set; }

    }
}
