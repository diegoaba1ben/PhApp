using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un usuario dentro del sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Obtiene o establece el identificador único del usuario.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el primer nombre del usuario.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Nombre1 solo puede contener letras y caracteres válidos.")]
        public required string Nombre1 { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece el segundo nombre del usuario.
        /// Puede ser opcional y solo puede contener letras y caracteres válidos.
        /// </summary>
        [StringLength(30, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Nombre2 solo puede contener letras y caracteres válidos.")]
        public string? Nombre2 { get; set; } = string.Empty; //Para que empiece con un valor predeterminado

        /// <summary>
        /// Obtiene o establece el primer apellido del usuario.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [Required]
        [StringLength(80, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Apellido1 solo puede contener letras y caracteres válidos.")]
        public string Apellido1 { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece el segundo apellido del usuario.
        /// Solo puede contener letras y caracteres válidos.
        /// </summary>
        [StringLength(80, MinimumLength = 3)]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Apellido2 solo puede contener letras y caracteres válidos.")]
        public string Apellido2 { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece la identificación del usuario.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [StringLength(15, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Identificación solo puede contener números.")]
        public string Identificacion { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece la identificación tributaria del usuario.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Identificación Tributaria solo puede contener números.")]
        public string IdenTributaria { get; set; } = " ";

        /// <summary>
        /// Registra a qué entidad de salud pertenece
        /// </summary>
        [Required]
        [RegularExpression(@"^[\p{L}\p{M}'-]+$", ErrorMessage = "Entidad de Salud solo puede contener letras y caracteres válidos.")]
        public string EntSalud { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece la tarjeta profesional del usuario (en caso de ser aplicable).
        /// Solo puede contener números.
        /// </summary>
        [StringLength(20, MinimumLength = 4)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Tarjeta profesional solo puede contener números.")]
        public string? TarjProf { get; set; } = string.Empty;

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// Debe contener entre 8 y 15 caracteres, incluyendo al menos una letra mayúscula, 
        /// una minúscula, un número, y un caracter especial.
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,50}$",
        ErrorMessage = "Correo debe tener al menos una letra mayúscula, una letra minúscula, un número y un caracter especial.")]
        public string Correo { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece el número de teléfono del usuario.
        /// Solo puede contener números.
        /// </summary>
        [Required]
        [Phone]
        [StringLength(15)]
        [RegularExpression(@"^\d+$", ErrorMessage = "Teléfono solo puede contener números.")]
        public string Telefono { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece la dirección del usuario.
        /// Puede contener cualquier combinación de letras, números y caracteres especiales.
        /// </summary>
        [Required]
        [StringLength(100)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{5,100}$",
            ErrorMessage = "Dirección debe tener una combinación de letras, números y caracteres especiales.")]
        public string Direccion { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece la ciudad de residencia del usuario.
        /// Solo puede contener letras y espacios.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Ciudad solo puede contener letras y espacios.")]
        public string Ciudad { get; set; } = " ";

        /// <summary>
        /// Obtiene o establece el departamento de residencia del usuario.
        /// Solo puede contener letras y espacios.
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "Departamento solo puede contener letras y espacios.")]
        public string Departamento { get; set; } = " ";

        /// <summary>
        /// Relación entre Usuario y Perfiles con cardinalidad muchos a muchos.
        /// </summary>
        public ICollection<PerfilUsuario> PerfileUsuarios { get; set; } = new List<PerfilUsuario>();

        /// <summary>
        /// Constructor vacío requerido por EF Core
        /// </summary>
        public Usuario()
        {

        }

        /// <summary>
        /// Método constructor con parámetros.
        /// </summary>
        public Usuario(string nombre1, string? nombre2, string apellido1, string apellido2,
        string identificacion, string idenTributaria, string entSalud, string? tarjProf,
        string correo, string telefono, string direccion, string ciudad, string departamento)
        {
            Nombre1 = nombre1 ?? throw new ArgumentNullException(nameof(nombre1));
            Nombre2 = nombre2 ?? string.Empty; // Valor predeterminado si es nulo
            Apellido1 = apellido1 ?? throw new ArgumentNullException(nameof(apellido1));
            Apellido2 = apellido2 ?? string.Empty; // Valor predeterminado si es nulo
            Identificacion = identificacion ?? throw new ArgumentNullException(nameof(identificacion));
            IdenTributaria = idenTributaria ?? throw new ArgumentNullException(nameof(idenTributaria));
            EntSalud = entSalud ?? throw new ArgumentNullException(nameof(entSalud));
            TarjProf = tarjProf ?? string.Empty; // Puede ser null, por eso no se lanza excepción
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Ciudad = ciudad ?? throw new ArgumentNullException(nameof(ciudad));
            Departamento = departamento ?? throw new ArgumentNullException(nameof(departamento));
        }
    }
}

