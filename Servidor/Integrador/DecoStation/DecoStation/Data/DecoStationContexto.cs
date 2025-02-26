using DecoStation.Models;
using Microsoft.EntityFrameworkCore;

namespace DecoStation.Data
{
    public class DecoStationContexto : DbContext
    {
        internal object Detalles;

        public DecoStationContexto(DbContextOptions<DecoStationContexto> options)
          : base(options)
        {
        }
        public DbSet<Usuario>? Users { get; set; }
        public DbSet<Producto>? Products { get; set; }
        public DbSet<Pedido>? Orders { get; set; }
        public DbSet<Estado>? Conditions { get; set; }
        public DbSet<Detalle>? Details { get; set; }
        public DbSet<Categoria>? Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Poner el nombre de las tablas en singular 
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Producto>().ToTable("Producto");
            modelBuilder.Entity<Pedido>().ToTable("Pedido");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Detalle>().ToTable("Detalle");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");

            // Configuración de propiedades decimales
            modelBuilder.Entity<Detalle>()
                .Property(d => d.Price)
                .HasPrecision(18, 2); // Precisión y escala para 'Summary' en Detalle

            modelBuilder.Entity<Producto>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // Precisión y escala para 'Price' en Producto

            // Deshabilitar la eliminación en cascada en todas las relaciones 
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
                     modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
