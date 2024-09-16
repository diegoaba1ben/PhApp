using System;
using System.ComponentModel.DataAnnotations;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un permiso dentro del sistema que puede estar asociado a una categoría.
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// Identificador único del permiso.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del permiso que describe su función dentro del sistema.
        /// </summary>
        [Required(ErrorMessage = "El nombre del permiso es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Descripción completa del permiso, explicando su funcionalidad.
        /// </summary>
        [Required(ErrorMessage = "La descripción no puede exceder los 100 caracteres.")]
        [StringLength(100)]
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del permiso.
        /// </summary>
        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Identificación del usuario que creó el permiso
        /// </summary>
        public int CreadorId { get; set; }

        /// <summary>
        /// Categoría a la cual pertenece este permiso.
        /// </summary>
        public Categoria Categoria { get; set; } = new Categoria();

        /// <summary>
        /// Constructor vacío requerido por EF Core.
        /// </summary>
        public Permiso()
        {
        }

        /// <summary>
        /// Constructor que permite crear un permiso con nombre y descripción.
        /// </summary>
        public Permiso(string nombre, string descripcion,Categoria categoria)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Categoria = Categoria ?? throw new ArgumentNullException(nameof(Categoria));
        }
    }
}


