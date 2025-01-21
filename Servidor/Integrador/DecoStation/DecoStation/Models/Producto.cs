using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre del producto es un campo requerido.")]
        public string? Name { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency, ErrorMessage = "Formato de precio no válido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        [Required(ErrorMessage = "El precio es un campo requerido.")]
        public decimal? Price { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "El stock del producto es un campo requerido.")]
        public int? Stock { get; set; }

        [Display(Name = "Imagen del Producto")]
        public int ImageId { get; set; }

        [Display(Name = "Categoría")]
        public int CategoryId { get; set; }

        public Imagen? Image { get; set; }

        public Categoria? Category { get; set; }
    }
}
