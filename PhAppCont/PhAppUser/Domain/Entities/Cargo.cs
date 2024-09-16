using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un cargo dentro de la copropiedad, donde pueden existir varios cargos en el organigrama
    /// de la copropiedad. El cargo correspondiente al Representante Legal debe ser tratado de manera
    /// única y especial.
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// Identificador único del cargo.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        /// <summary>
        /// Nombre del cargo.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "El nombre solo puede contener letras, números y espacios.")]
        public required string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del cargo.
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "La descripción solo puede contener letras, números y espacios.")]
        public required string Descripcion { get; set; }

        /// <summary>
        /// Indica si el usuario está activo como representante legal.
        /// </summary>
        public bool EsRepresentanteLegal { get; set; }

        /// <summary>
        /// Lista de documentos de representación legal asociados a este cargo.
        /// </summary>
        public ICollection<RepLegal> RepresentantesLegales { get; set; } = new List<RepLegal>();

        /// <summary>
        /// Lista de perfiles asociados a este cargo.
        /// </summary>
        public ICollection<PerfilUsuario> Perfiles { get; set; } = new List<PerfilUsuario>();

        // Constructores
        /// <summary>
        /// Constructor con parámetros para inicializar nombre y descripción.
        /// </summary>
        public Cargo(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
        
        /// <summary>
        /// Constructor vacío requerido por EF Core
        /// </summary>
        public Cargo()
        {
            
        }

    }
}



