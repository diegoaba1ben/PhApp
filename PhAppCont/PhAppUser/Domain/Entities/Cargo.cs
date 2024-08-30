using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un cargo dentro de la copropiedad
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// Identificador único del cargo
        /// </summary>
        [Key]
        public int Id { get; set; } 

        /// <summary>
        /// Nombre del cargo
        /// </summary>
        /// <remarks> El nombre del cargo debe ser único dentro de la copropiedad, contener letras y 
        ///  no exceder los 50 caracteres </remarks>

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El nombre solo puede contener letras y números.")]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del cargo
        /// </summary>
        /// <remarks> contiene la descripción del cargo, debe  contener letras y no exceder los 50 caracteres </remarks>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "La descripción solo puede contener letras y números.")]
        public string Descripcion { get; set; }

        // Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        /// <remarks> Crea un objeto cargo con los valores de las propiedades inicializadas en sus valores
        /// predeterminados</remarks>
        public Cargo() { }

        /// <summary>
        /// Constructor con parámetros. 
        /// </summary>
        /// <param name="nombre">El nombre del cargo</param>
        /// <param name="descripcion">La descripción del cargo</param>
        /// <remarks>Crea un objeto cargo con los valores especificados para el nombre y la descripción</remarks>
        public Cargo(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}

