using Microsoft.EntityFrameworkCore;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<RepLegal> RepLegales { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para PerfilUsuario
            modelBuilder.Entity<PerfilUsuario>()
                .HasKey(pu => new { pu.UsuarioId, pu.CargoId });

            // Configuración para la relación entre Cargo y RepLegal
            modelBuilder.Entity<RepLegal>()
               .HasOne(r => r.Cargo)
               .WithMany(c =>c.RepresentantesLegales)
               .HasForeignKey(r => r.CargoId)
               .OnDelete(DeleteBehavior.Restrict); 

            // Configuración adicional para otras entidades
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
            modelBuilder.Entity<RepLegal>().ToTable("RepLegales");
            modelBuilder.Entity<Permiso>().ToTable("Permisos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<PerfilUsuario>().ToTable("PerfilUsuarios");

            // Agregar más configuraciones según sea necesario
        }
    }
}

