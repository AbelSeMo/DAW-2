using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }

        [Display(Name = "Precio")]
        [RegularExpression(@"^[-0123456789]+[0-9.,]*$",
        ErrorMessage = "El valor introducido debe ser de tipo monetario.")]
        [Required(ErrorMessage = "El precio es un campo requerido")]
        public string PriceChain
        {
            get
            {
                return Convert.ToString(Price).Replace(',', '.');
            }
        }

        public bool? Escaparate { get; set; }

        [Display(Name = "Imagen del Producto")]
        public string? Imagen { get; set; }

        [Display(Name = "Categoría")]
        public int CategoriaID { get; set; }

        [Display(Name = "Categoría")]
        public Categoria? Category { get; set; }
        public ICollection<Detalle>? Detalles { get; set; }
    }
}
