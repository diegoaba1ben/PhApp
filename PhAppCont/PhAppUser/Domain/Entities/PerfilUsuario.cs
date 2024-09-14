using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa el perfil del usuario, incluyendo su cargo y permisos
    /// </summary>
    public class PerfilUsuario
    {
        /// <summary>
        /// Identificador único del usuario asociado al perfil, clave compuesta
        /// </summary>
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Identificador del cargo asociado al perfil
        /// </summary>
        [Required]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Colección de permisos asociados al perfil
        /// </summary>
        [Required]
        public ICollection<Permiso> Permisos { get; set; }  

        /// <summary>
        /// Constructor vacío requerido por EF Core
        /// </summary>
        public PerfilUsuario()
        {
            
        }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        public PerfilUsuario(int usuarioId, Usuario usuario, int cargoId, Cargo cargo, ICollection<Permiso> permisos)
        {
            UsuarioId = usuarioId;
            Usuario = usuario;
            CargoId = cargoId;
            Cargo = cargo;
            Permisos = permisos ?? new HashSet<Permiso>(); 
        }
    }
}