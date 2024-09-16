using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa el perfil del usuario, incluyendo su cargo y categorías de permisos.
    /// </summary>
    public class PerfilUsuario
    {
        /// <summary>
        /// Identificador único del usuario asociado al perfil, clave compuesta.
        /// </summary>
        [Required]
        public int UsuarioId { get; set; }
        
        /// <summary>
        /// Usuario asociado al perfil.
        /// </summary>
        [Required]
        public required Usuario Usuario { get; set; } 
        
        /// <summary>
        /// Identificador del cargo asociado al perfil.
        /// </summary>
        [Required]
        public int CargoId { get; set; }
        
        /// <summary>
        /// Cargo asociado al perfil.
        /// </summary>
        [Required]
        public required Cargo Cargo { get; set; }
        
        /// <summary>
        /// Colección de categorías asociadas al perfil.
        /// </summary>
        public ICollection<Categoria> Categorias { get; set; }
        
        /// <summary>
        /// Constructor vacío requerido por EF Core.
        /// </summary>
        public PerfilUsuario()
        {
            Categorias = new List<Categoria>();
        }
        
        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        public PerfilUsuario(int usuarioId, Usuario usuario, int cargoId, Cargo cargo, ICollection<Categoria> categorias)
        {
            UsuarioId = usuarioId;
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            CargoId = cargoId;
            Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo), "El cargo no puede ser nulo.");
            Categorias = categorias ?? new List<Categoria>();
        }
    }
}

