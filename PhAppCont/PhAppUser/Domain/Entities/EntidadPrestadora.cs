using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Enumeración para definir el tipo de entidad prestadora.
    /// </summary>
    public enum TipoEntPrestadora
    {
        Salud,
        Pension
    }

    /// <summary>
    /// Clase base para entidades prestadoras como fondos de pensión y entidades de salud.
    /// </summary>
    public class EntidadPrestadora
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Tipo de entidad prestadora (Pensión o Salud).
        /// </summary>
        [Required]
        public TipoEntPrestadora Tipo { get; set; }

        /// <summary>
        /// Nombre de la entidad prestadora.
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public required string Nombre { get; set; }

        /// <summary>
        /// Número de Identificación Tributaria (NIT).
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public required string Nit { get; set; }

        /// <summary>
        /// Dirección de la entidad prestadora.
        /// </summary>
        [Required]
        [StringLength(50)]
        public required string Direccion { get; set; }

        /// <summary>
        /// Teléfono de la entidad prestadora.
        /// </summary>
        [Required]
        [StringLength(20)]
        public required string Telefono { get; set; }

        /// <summary>
        /// Correo electrónico de contacto.
        /// </summary>
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public required string Correo { get; set; }

        /// <summary>
        /// Número de afiliación del usuario a esta entidad.
        /// </summary>
        [Required]
        [StringLength(30)]
        public required string NroAfiliacion { get; set; }

        /// <summary>
        /// Identificador del usuario que está asociado a la entidad prestadora.
        /// </summary>
        [Required]
        public int UsuarioId { get; set; }

        /// <summary>
        /// Relación con la entidad Usuario.
        /// </summary>
        [Required]
        [ForeignKey("UsuarioId")]
        public virtual Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor que asegura la relación de agregación.
        /// </summary>
        private EntidadPrestadora() { }

        /// <summary>
        /// Crea un nuevo builder para construir un objeto EntidadPrestadora.
        /// </summary>
        /// <returns>Una instancia del builder.</returns>
        public static Builder CreateBuilder() => new Builder();

        /// <summary>
        /// Clase interna Builder para construir objetos EntidadPrestadora.
        /// </summary>
        public class Builder
        {
            private readonly EntidadPrestadora _entidadPrestadora = new EntidadPrestadora();

            /// <summary>
            /// Establece el tipo de entidad prestadora.
            /// </summary>
            public Builder SetTipo(TipoEntPrestadora tipo)
            {
                _entidadPrestadora.Tipo = tipo;
                return this;
            }

            /// <summary>
            /// Establece el nombre de la entidad prestadora.
            /// </summary>
            public Builder SetNombre(string nombre)
            {
                _entidadPrestadora.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
                return this;
            }

            /// <summary>
            /// Establece el número de identificación tributaria (NIT).
            /// </summary>
            public Builder SetNit(string nit)
            {
                _entidadPrestadora.Nit = nit ?? throw new ArgumentNullException(nameof(nit));
                return this;
            }

            /// <summary>
            /// Establece la dirección de la entidad prestadora.
            /// </summary>
            public Builder SetDireccion(string direccion)
            {
                _entidadPrestadora.Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
                return this;
            }

            /// <summary>
            /// Establece el teléfono de la entidad prestadora.
            /// </summary>
            public Builder SetTelefono(string telefono)
            {
                _entidadPrestadora.Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
                return this;
            }

            /// <summary>
            /// Establece el correo electrónico de contacto.
            /// </summary>
            public Builder SetCorreo(string correo)
            {
                _entidadPrestadora.Correo = correo ?? throw new ArgumentNullException(nameof(correo));
                return this;
            }

            /// <summary>
            /// Establece el número de afiliación del usuario a esta entidad.
            /// </summary>
            public Builder SetNroAfiliacion(string nroAfiliacion)
            {
                _entidadPrestadora.NroAfiliacion = nroAfiliacion ?? throw new ArgumentNullException(nameof(nroAfiliacion));
                return this;
            }

            /// <summary>
            /// Establece el identificador del usuario asociado a la entidad prestadora.
            /// </summary>
            public Builder SetUsuarioId(int usuarioId)
            {
                _entidadPrestadora.UsuarioId = usuarioId;
                return this;
            }

            /// <summary>
            /// Establece la relación con la entidad Usuario.
            /// </summary>
            public Builder SetUsuario(Usuario usuario)
            {
                _entidadPrestadora.Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
                return this;
            }

            /// <summary>
            /// Construye y devuelve la instancia de EntidadPrestadora.
            /// </summary>
            /// <returns>Una instancia de EntidadPrestadora.</returns>
            public EntidadPrestadora Build() => _entidadPrestadora;
        }
    }
}
