using Microsoft.EntityFrameworkCore;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Infrastructure.Context
{
    public class PhAppUserDbContext : DbContext  // Cambié el nombre para ser consistente con el microservicio
    {
        public PhAppUserDbContext(DbContextOptions<PhAppUserDbContext> options) : base(options) { }

        // Definición de DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<RepLegal> RepLegales { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<PerfilUsuario> PerfilesUsuarios { get; set; }
        public DbSet<EntidadPrestadora> EntidadesPrestadoras { get; set; }
        public DbSet<EntSalud> EntsSalud { get; set; }
        public DbSet<Pension> Pensiones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de tablas con nombres específicos
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
            modelBuilder.Entity<RepLegal>().ToTable("RepLegales");
            modelBuilder.Entity<Permiso>().ToTable("Permisos");
            modelBuilder.Entity<Categoria>().ToTable("Categorias");
            modelBuilder.Entity<PerfilUsuario>().ToTable("PerfilUsuarios");
            modelBuilder.Entity<EntSalud>().ToTable("EntsSalud");
            modelBuilder.Entity<Pension>().ToTable("Pensiones");
            modelBuilder.Entity<EntidadPrestadora>().ToTable("EntidadesPrestadoras");

            // Configuraciones de relaciones personalizadas
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Relación uno a uno entre Usuario y EntidadPrestadora
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.EntidadPrestadora)
                .WithOne(e => e.Usuario)
                .HasForeignKey<EntidadPrestadora>(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno entre PerfilUsuario y Usuario
            modelBuilder.Entity<PerfilUsuario>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.PerfilesUsuarios)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno entre PerfilUsuario y Cargo
            modelBuilder.Entity<PerfilUsuario>()
                .HasOne(p => p.Cargo)
                .WithMany(c => c.PerfilesUsuarios)
                .HasForeignKey(p => p.CargoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos entre PerfilUsuario y Categoria (usando una tabla de unión)
            modelBuilder.Entity<PerfilUsuario>()
                .HasMany(p => p.Categorias)
                .WithMany(c => c.PerfilesUsuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "PerfilUsuarioCategoria",
                    j => j.HasOne<Categoria>().WithMany().HasForeignKey("CategoriaId"),
                    j => j.HasOne<PerfilUsuario>().WithMany().HasForeignKey("PerfilUsuarioId")
                );
        }

        // Métodos adicionales
        public async Task AsigRepLegalAsync(int cargoId, RepLegal repLegal)
        {
            var cargoActual = await Cargos.FindAsync(cargoId);
            if (cargoActual != null)
            {
                await CambiarEstadoRepLegal(cargoActual, false);
                cargoActual.EsRepresentanteLegal = true;
                repLegal.CargoId = cargoId;
                repLegal.Cargo = cargoActual;
            }
            else
            {
                throw new ArgumentException("El cargo especificado no existe");
            }

            await RepLegales.AddAsync(repLegal);
            await SaveChangesAsync();
        }

        private async Task CambiarEstadoRepLegal(Cargo cargoActual, bool esRepresentanteLegal)
        {
            cargoActual.EsRepresentanteLegal = esRepresentanteLegal;
            Cargos.Update(cargoActual);
            await SaveChangesAsync();
        }
    }
}
