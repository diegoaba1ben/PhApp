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
        public DbSet<EntSalud> EntsSalud { get; set; }
        public DbSet<Pension> Pensiones { get; set; }

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
            modelBuilder.Entity<EntSalud>().ToTable("EntsSalud");
            modelBuilder.Entity<Pension>().ToTable("Pensiones");

            //Configuración para la relación uno a uno  entre Usuario y EntSalud
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.EntSalud)
                .WithOne()
                .HasForeignKey<Usuario>(u => u.EntSaludId)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuración de la relación uno a uno entre Usuario Y Pensión
            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Pension)
            .WithOne()
            .HasForeignKey<Usuario>(u => u.PensionId)
            .OnDelete(DeleteBehavior.Restrict);


            // Agregar más configuraciones según sea necesario
        }
    }
}

