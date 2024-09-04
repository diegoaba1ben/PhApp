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
        [Key, Column(Order = 0)]
        [Required]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Identificador del cargo asociado al perfil
        /// </summary>
        [Key, Column(Order = 1)]
        [Required]
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Colección de permisos asociados al perfil
        /// </summary>
        [Required]
        public ICollection<Permiso> Permisos { get; set; }  

        /// <summary>
        /// Constructor vacío necesario para Entity Framework
        /// </summary>
        public PerfilUsuario()
        {
            Permisos = new HashSet<Permiso>();
        }
    }
}