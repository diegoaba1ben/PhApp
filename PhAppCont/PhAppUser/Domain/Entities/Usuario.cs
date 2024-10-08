using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Clase que representa a un usuario dentro del sistema.
    /// </summary>
    public class Usuario
    {
        #region Propiedades Básicas de Identificación

        [Key]
        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public int Id { get; private set; }

        [Required(ErrorMessage = "El primer nombre es obligatorio.")]
        [StringLength(30, ErrorMessage = "El nombre no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "El nombre solo acepta letras.")]
        public string PrimerNombre { get; private set; }

        [StringLength(30, ErrorMessage = "El segundo nombre no puede tener más de 30 caracteres.")]
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "El segundo nombre solo acepta letras.")]
        public string? SegundoNombre { get; private set; }

        [Required(ErrorMessage = "El primer apellido es obligatorio.")]
        [StringLength(40, ErrorMessage = "El apellido no puede tener más de 40 caracteres.")]
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "El apellido solo acepta letras.")]
        public string PrimerApellido { get; private set; }

        [StringLength(40, ErrorMessage = "El segundo apellido no puede tener más de 40 caracteres.")]
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "El segundo apellido solo acepta letras.")]
        public string? SegundoApellido { get; private set; }

        public TipoIdentificacion TipoIdentificacion { get; private set; }

        [Required(ErrorMessage = "El número de identificación personal es obligatorio.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "El número de identificación debe tener entre 5 y 20 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo identificación solo acepta números.")]
        public string IdentificacionPersonal { get; private set; }

        public TipoIdentTrib TipoIdenTrib { get; private set; }

        [StringLength(20, ErrorMessage = "El nombre de la entidad prestadora no debe esceder los  20 caracteres.")]
        [RegularExpression(@"^\d+$"), ErrorMessage = "El campo número de identidad tributaria solo acepta números."]
        public string? IdenTrib { get; private set; }

        public TipoSegSoc TipoSegSoc { get; private set; }
        public string EntidadPrestadora { get; private set; }
        public bool EsContador { get; private set; }
        public string? TarProf { get; private set; }

        #endregion

        #region Propiedades de Ubicación

        [Required(ErrorMessage = "La ciudad es obligatoria.")]
        [StringLength(50, ErrorMessage = "La ciudad no puede tener más de 50 caracteres.")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "La ciudad debe contener solo letras.")]
        public string Ciudad { get; private set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(100, ErrorMessage = "La dirección no puede tener más de 100 caracteres.")]
        [RegularExpression(@"^[\p{L}0-9\s]+$", ErrorMessage = "La dirección puede contener números y letras.")]
        public string Direccion { get; private set; }

        #endregion

        #region Propiedades de Contacto

        [Required(ErrorMessage = "El número telefónico es obligatorio.")]
        [StringLength(20, ErrorMessage = "El número telefónico no puede tener más de 20 caracteres.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "El número telefónico solo puede contener números.")]
        public string Telefono { get; private set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        public string Correo { get; private set; }

        #endregion

        #region Seguridad

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "La contraseña debe contener entre 6 y 15 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])", ErrorMessage = "La contraseña debe contener al menos un número, una letra mayúscula, una letra minúscula y un carácter especial.")]
        public string Clave { get; private set; }

        #endregion

        // Constructor privado para restringir la creación de instancias.
        private Usuario() { }

        //Propiedades claculadas
        public string NombreCompleto => $"{PrimerNombre} {(SegundoNombre ?? string.Empty)} {PrimerApellido} {(SegundoApellido ?? string.Empty)}".Trim();
        public string DireccionCompleta => $"{Direccion}  {Ciudad}";


        #region Inicialización del Builder

        /// <summary>
        /// Método estático para inicializar el Builder.
        /// </summary>
        public static UsuarioBuilder CrearBuilder() => new UsuarioBuilder();

        /// <summary>
        /// Clase interna de UsuarioBuilder para facilitar la construcción del objeto Usuario.
        /// </summary>
        public class UsuarioBuilder
        {
            private Usuario _usuario;

            public UsuarioBuilder()
            {
                _usuario = new Usuario();
            }

            // Métodos de construcción encadenados con validaciones.
            public UsuarioBuilder ConId(int id) => AsignarValor(u => u.Id = id, id > 0, "El ID debe ser un número positivo.");
            public UsuarioBuilder ConPrimerNombre(string primerNombre) => AsignarValor(u => u.PrimerNombre = primerNombre, !string.IsNullOrWhiteSpace(primerNombre), "El primer nombre no puede estar vacío.");
            public UsuarioBuilder ConSegundoNombre(string? segundoNombre) => AsignarValor(u => u.SegundoNombre = segundoNombre);
            public UsuarioBuilder ConPrimerApellido(string primerApellido) => AsignarValor(u => u.PrimerApellido = primerApellido, !string.IsNullOrWhiteSpace(primerApellido), "El primer apellido no puede estar vacío.");
            public UsuarioBuilder ConSegundoApellido(string? segundoApellido) => AsignarValor(u => u.SegundoApellido = segundoApellido);
            public UsuarioBuilder ConTipoIdentificacion(TipoIdentificacion tipoIdentificacion) => AsignarValor(u => u.TipoIdentificacion = tipoIdentificacion);
            public UsuarioBuilder ConIdentificacionPersonal(string identificacionPersonal) => AsignarValor(u => u.IdentificacionPersonal = identificacionPersonal, !string.IsNullOrWhiteSpace(identificacionPersonal), "La identificación es obligatoria.");
            public UsuarioBuilder ConTipoIdenTrib(bool TipoIdenTrib) => AsignarValor(u => u.IdenTrib = idenTrib);
            public UsuarioBuilder ConIdenTrib(string? idenTrib) => AsignarValor(u =>  u.IdenTrib = idenTrib);
            public UsuarioBuilder ConTipoSegSoc(TipoSegSoc tipoSegSoc) =>AsignarValor(u => u.TipoSegSoc = tipoSegSoc);
            public UsuarioBuilder ConEntidadPrestadora(string  entidadPrestadora) => AsignarValor(u => u.EntidadPrestadora = entidadPrestadora);
            public UsuarioBuilder ConEsContador(bool esContador) => AsignarValor(u => u.EsContador = esContador);
            public Usuarioibuilder ConTarProf(string? tarProf) => AsignarValor(u => u.TarProf = tarProf);

            public UsuarioBuilder ConCiudad(string ciudad) => AsignarValor(u => u.Ciudad = ciudad);
            public UsuarioBuilder ConDireccion(string direccion) => AsignarValor(u => u.Direccion = direccion);
            public UsuarioBuilder ConTelefono(string telefono) => AsignarValor(u => u.Telefono = telefono, telefono.Length >= 7, "El número telefónico debe ser mayor a 7 dígitos.");
            public UsuarioBuilder ConCorreo(string correo) => AsignarValor(u => u.Correo = correo, new EmailAddressAttribute().IsValid(correo), "Correo inválido.");
            public UsuarioBuilder ConClave(string clave) => AsignarValor(u => u.Clave = clave, clave.Length >= 6, "La contraseña debe tener al menos 6 caracteres.");
                              
            // Método privado para asignar valores con validación.
            private UsuarioBuilder AsignarValor(Action<Usuario> setter, bool condicion = true, string mensajeError = "")
            {
                if (!condicion && !string.IsNullOrEmpty(mensajeError))
                    throw new ArgumentException(mensajeError);
                setter(_usuario);
                return this;
            }

            /// <summary>
            /// Construye el objeto Usuario.
            /// </summary>
            public Usuario Build() => _usuario;
        }

        #endregion
    }
}


