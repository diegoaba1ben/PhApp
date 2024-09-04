using Microsoft.EntityFrameworkCore;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Infrastructure.Context
{
    /// <summary>
    /// Representa el contexto de la base de datos para la aplicación PhAppUser.
    /// </summary>
    public class AppDbContext : DbContext 
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppDbContext"/>.
        /// </summary>
        /// <param name="options">Las opciones de configuración para el contexto.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            // Inicialización de la base de datos
        }

        /// <summary>
        /// Conjunto de datos que representa a los usuarios en la base de datos.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Conjunto de datos que representa a los cargos en la base de datos.
        /// </summary>
        public DbSet<Cargo> Cargos { get; set; }

        /// <summary>
        /// Conjunto de datos que representa a los representantes legales en la base de datos.
        /// </summary>
        public DbSet<RepLegal> RepLegales { get; set; }

        /// <summary>
        /// Conjunto de datos que representa a los permisos en la base de datos.
        /// </summary>
        public DbSet<Permiso> Permisos { get; set; }

        /// <summary>
        /// Conjunto de datos que representa a las categorías en la base de datos.
        /// </summary>
        public DbSet<Categoria> Categorias { get; set; }

        /// <summary>
        /// Conjunto de datos que representa a los perfiles en la base de datos.
        /// </summary>
        public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
    }
}
