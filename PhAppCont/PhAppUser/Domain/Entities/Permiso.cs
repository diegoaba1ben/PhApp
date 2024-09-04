using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un permiso dentro del sistema.
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Identificador único del permiso.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del permiso, debe ser único y contener letras y números.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El nombre solo puede contener letras y números.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción completa del permiso.
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "La descripción solo puede contener letras y números.")]
        public string Descripcion { get; set; }

        /// <summary>
        /// Identificador de la categoría a la que pertenece el permiso.
        /// </summary>
        [Required]
        public int CategoriaId { get; set; }

        /// <summary>
        /// Muestra el estado de activo o inactivo del permiso.
        /// </summary>
        public bool EstadoActivo { get; set; }

        /// <summary>
        /// Propiedad navegacional entre permisos y la clase perfil con relación muchos a muchos.
        /// </summary>
        public ICollection<PerfilUsuario> Perfiles { get; set; } = new HashSet<PerfilUsuario>();

        /// <summary>
        /// Categoría a la que pertenece el permiso.
        /// </summary>
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        // Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Permiso() { }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        public Permiso(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
