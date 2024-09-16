using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Clase que agrupa los permisos de forma lógica para facilitar la gestión, la jerarquía y la seguridad.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre de la categoría dentro del sistema.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "El nombre solo puede contener letras, números y espacios.")]
        public string Nombre { get; set; } = string.Empty;
        
        /// <summary>
        /// Descripción completa de la categoría en el sistema.
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "La descripción solo puede contener letras, números y espacios.")]
        public string Descripcion { get; set; } = string.Empty;
        
        /// <summary>
        /// Lista de permisos asociados con esta categoría.
        /// </summary>
        public ICollection<Permiso> Permisos { get; set; } = new List<Permiso>();

        /// <summary>
        /// Constructor vacío requerido por EF Core.
        /// </summary>
        public Categoria()
        {
            // Se inicializa la colección para evitar nulos.
            Permisos = new List<Permiso>();
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nombre">Nombre de la categoría.</param>
        /// <param name="descripcion">Descripción de la categoría.</param>
        public Categoria(string nombre, string descripcion)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo.");
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion), "La descripción no puede ser nula.");
            Permisos = new List<Permiso>(); 
        }

        
    }
}

