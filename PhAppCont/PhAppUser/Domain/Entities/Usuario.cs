using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa una entidad de Representante Legal.
    /// </summary>
    public class RepLegal
    {
        /// <summary>
        /// Obtiene o establece el identificador único del Representante Legal.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el primer nombre del Representante Legal.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Nombre1 solo puede contener letras y caracteres válidos.")]
        public string Nombre1 { get; set; }

        /// <summary>
        /// Obtiene o establece el segundo nombre del Representante Legal.
        /// Puede ser opcional y solo puede contener letras y caracteres válidos.
        /// </summary>
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Nombre2 solo puede contener letras y caracteres válidos.")]
        public string Nombre2 { get; set; }

        /// <summary>
        /// Obtiene o establece el primer apellido del Representante Legal.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [Required]
        [StringLength(80, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Apellido1 solo puede contener letras y caracteres válidos.")]
        public string Apellido1 { get; set; }

        /// <summary>
        /// Obtiene o establece el segundo apellido del Representante Legal.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [StringLength(80, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Apellido2 solo puede contener letras y caracteres válidos.")]
        public string Apellido2 { get; set; }

        /// <summary>
        /// Obtiene o establece la identificación del Representante Legal.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [StringLength(15, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Identificación solo puede contener números.")]
        public string Identificacion { get; set; }

        /// <summary>
        /// Obtiene o establece la identificación tributaria del Representante Legal.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Identificación Tributaria solo puede contener números.")]
        public string IdenTributaria { get; set; }

        /// <summary>
        /// Obtiene o establece la tarjeta profesional de la persona que lleva la contaduría.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Tarjeta profesional solo puede contener números.")]
        public string TarjProf { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del Representante Legal.
        /// Debe contener entre 8 y 15 caracteres, incluyendo al menos una letra mayúscula, 
        /// una minúscula, un número, y un caracter especial.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(15, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,15}$", 
            ErrorMessage = "Correo debe tener al menos una letra mayúscula, una letra minúscula, un número y un caracter especial.")]
        public string Correo { get; set; }

        /// <summary>
        /// Obtiene o establece el número de teléfono del Representante Legal.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [Phone]
        [StringLength(15)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Teléfono solo puede contener números.")]
        public string Telefono { get; set; }

        /// <summary>
        /// Obtiene o establece la dirección del Representante Legal.
        /// Puede contener cualquier combinación de letras, números y caracteres especiales.
        /// </summary>
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_])")]
        public string Direccion { get; set; }

        /// <summary>
        /// Obtiene o establece la ciudad de residencia del Representante Legal.
        /// Solo puede contener letras y espacios.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Ciudad solo puede contener letras y espacios.")]
        public string Ciudad { get; set; }

        /// <summary>
        /// Obtiene o establece el departamento de residencia del Representante Legal.
        /// Solo puede contener letras y espacios.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Departamento solo puede contener letras y espacios.")]
        public string Departamento { get; set; }
    }
}
