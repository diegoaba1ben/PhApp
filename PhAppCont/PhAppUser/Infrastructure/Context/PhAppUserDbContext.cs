using Microsoft.EntityFrameworkCore;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Infrastructure.Context
{
    public class PhAppUserDbContext : DbContext
    {
        public PhAppUserDbContext(DbContextOptions<PhAppUserDbContext> options) : base(options) { }

        // Definición de DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<RepLegal> RepLegales { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<EntSalud> EntidadesSalud { get; set; }
        public DbSet<EntPension> EntidadesPension { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo de tablas con nombres específicos
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Cargo>().ToTable("Cargos");
            modelBuilder.Entity<RepLegal>().ToTable("RepLegales");
            modelBuilder.Entity<Permiso>().ToTable("Permisos");
            modelBuilder.Entity<Area>().ToTable("Areas");
            modelBuilder.Entity<Perfil>().ToTable("Perfiles");
            modelBuilder.Entity<EntSalud>().ToTable("EntidadesSalud");
            modelBuilder.Entity<EntPension>().ToTable("EntidadesPension");

            // Configuraciones de relaciones personalizadas
            ConfigureRelationships(modelBuilder);
        }

        private void ConfigureRelationships(ModelBuilder modelBuilder)
        {
            // Relación muchos a uno entre Perfil y Usuario
            modelBuilder.Entity<Perfil>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Perfiles)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a uno entre Perfil y Cargo
            modelBuilder.Entity<Perfil>()
                .HasOne(p => p.Cargo)
                .WithMany(c => c.Perfiles)
                .HasForeignKey(p => p.CargoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos entre Perfil y Area (usando una tabla de unión)
            modelBuilder.Entity<Perfil>()
                .HasMany(p => p.Areas)
                .WithMany(a => a.Perfiles)
                .UsingEntity<Dictionary<string, object>>(
                    "PerfilArea",
                    j => j.HasOne<Area>().WithMany().HasForeignKey("AreaId"),
                    j => j.HasOne<Perfil>().WithMany().HasForeignKey("PerfilId")
                );
        }

        // Métodos adicionales
        public async Task AsignarRepLegalAsync(int cargoId, RepLegal repLegal)
        {
            var cargoActual = await Cargos.FindAsync(cargoId);
            if (cargoActual != null)
            {
                await CambiarEstadoRepLegalAsync(cargoActual, false);
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

        private async Task CambiarEstadoRepLegalAsync(Cargo cargoActual, bool esRepresentanteLegal)
        {
            cargoActual.EsRepresentanteLegal = esRepresentanteLegal;
            Cargos.Update(cargoActual);
            await SaveChangesAsync();
        }
    }
}

