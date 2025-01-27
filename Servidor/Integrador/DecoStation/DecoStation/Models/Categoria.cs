using System.ComponentModel.DataAnnotations;

namespace DecoStation.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Display(Name = "Descripción")]
        public string? Description { get; set; }

        public ICollection<Producto>? Products { get; set; }
    }
}
