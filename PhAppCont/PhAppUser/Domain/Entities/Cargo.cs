using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int Id { get; set; }

        /// <summary>
        /// Nombre del cargo.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 30 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "El nombre solo puede contener letras, números y espacios.")]
        public string Nombre { get; private set; }

        /// <summary>
        /// Descripción detallada del cargo.
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 50 caracteres.")]
        [RegularExpression(@"^[\p{L}\d\s\-]+$", ErrorMessage = "La descripción solo puede contener letras, números y espacios.")]
        public string Descripcion { get; private set; }

        /// <summary>
        /// Indica si el usuario está activo como representante legal.
        /// </summary>
        public bool EsRepresentanteLegal { get; private set; }

        /// <summary>
        /// Lista de documentos de representación legal asociados a este cargo.
        /// </summary>
        public ICollection<RepLegal> RepresentantesLegales { get; private set; } = new List<RepLegal>();

        /// <summary>
        /// Lista de perfiles asociados a este cargo.
        /// </summary>
        public ICollection<PerfilUsuario> PerfilesUsuarios { get; private set; } = new List<PerfilUsuario>();

        // Constructor privado para el builder
        private Cargo() { }

        /// <summary>
        /// Constructor para inicializar un nuevo cargo a través del builder.
        /// </summary>
        /// <param name="builder">El builder que crea la instancia de Cargo.</param>
        private Cargo(CargoBuilder builder)
        {
            Nombre = builder.Nombre;
            Descripcion = builder.Descripcion;
            EsRepresentanteLegal = builder.EsRepresentanteLegal;
            RepresentantesLegales = builder.RepresentantesLegales;
            PerfilesUsuarios = builder.PerfilesUsuarios;
        }

        /// <summary>
        /// Builder para crear instancias de Cargo.
        /// </summary>
        public class CargoBuilder
        {
            public string Nombre { get; private set; }
            public string Descripcion { get; private set; }
            public bool EsRepresentanteLegal { get; private set; }
            public ICollection<RepLegal> RepresentantesLegales { get; private set; } = new List<RepLegal>();
            public ICollection<PerfilUsuario> PerfilesUsuarios { get; private set; } = new List<PerfilUsuario>();

            /// <summary>
            /// Establece el nombre del cargo.
            /// </summary>
            /// <param name="nombre">Nombre del cargo.</param>
            /// <returns>El builder actual.</returns>
            public CargoBuilder WithNombre(string nombre)
            {
                Nombre = nombre;
                return this;
            }

            /// <summary>
            /// Establece la descripción del cargo.
            /// </summary>
            /// <param name="descripcion">Descripción del cargo.</param>
            /// <returns>El builder actual.</returns>
            public CargoBuilder WithDescripcion(string descripcion)
            {
                Descripcion = descripcion;
                return this;
            }

            /// <summary>
            /// Establece si el cargo es de representante legal.
            /// </summary>
            /// <param name="esRepresentanteLegal">Indica si es representante legal.</param>
            /// <returns>El builder actual.</returns>
            public CargoBuilder WithEsRepresentanteLegal(bool esRepresentanteLegal)
            {
                EsRepresentanteLegal = esRepresentanteLegal;
                return this;
            }

            /// <summary>
            /// Establece los representantes legales asociados al cargo.
            /// </summary>
            /// <param name="representantesLegales">Lista de representantes legales.</param>
            /// <returns>El builder actual.</returns>
            public CargoBuilder WithRepresentantesLegales(ICollection<RepLegal> representantesLegales)
            {
                RepresentantesLegales = representantesLegales;
                return this;
            }

            /// <summary>
            /// Establece los perfiles de usuario asociados al cargo.
            /// </summary>
            /// <param name="perfilesUsuarios">Lista de perfiles de usuario.</param>
            /// <returns>El builder actual.</returns>
            public CargoBuilder WithPerfilesUsuarios(ICollection<PerfilUsuario> perfilesUsuarios)
            {
                PerfilesUsuarios = perfilesUsuarios;
                return this;
            }

            /// <summary>
            /// Crea una nueva instancia de Cargo.
            /// </summary>
            /// <returns>La nueva instancia de Cargo.</returns>
            public Cargo Build()
            {
                return new Cargo(this);
            }
        }
    }
}




