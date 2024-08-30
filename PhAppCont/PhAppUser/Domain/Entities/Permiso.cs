using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un permiso dentro del sistema
    /// </summary>
    public class Permiso
    {
        /// <summary>
        /// identificador único dentro del permiso
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del permiso, debe ser único y contener letras
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El nombre solo puede contener letras y números.")]
        public string Nombre { get; set; }
        
        /// <summary>
        /// Descripción completa del permiso
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "La descripción solo puede contener letras y números.")]
        public string Descripcion { get; set; }

        // Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <remarks>Crea un objeto Descripcion con los valores inicializados predeterminados</remarks>
        public Permiso() { }

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="nombre">Nombre del permiso</param>
        /// <param name="descripcion">Descripción completa del permiso</param>
        ///  <remarks>Crea un objeto Descripcion con los valores especificados para el nombre y la
        ///  descripción<remarks>

        public Permiso(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
