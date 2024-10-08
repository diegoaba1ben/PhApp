using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    public class UsuarioBuilder
    {
        /// <summary>
        /// Clase que permite crear objetos Usuario de manera flexible
        /// </summary> Objeto Usuario
        /// <returns></returns>
        private Usuario _usuario;

        public UsuarioBuilder()
        {
            ///  <summary>
            ///  Inicializa una nueva instancia del objeto Usuario.
            /// </summary>

            _usuario = new Usuario();
        }

        public UsuarioBuilder ConId(int id)
        {
            /// <summary>
            /// Establece el ID del usuario.
            /// </summary>
            /// <param name="Id">El ID del usuario.</param>
            /// <returns>la instancia actual de UsuarioBuilder</returns>
                        if (id <= 0)
                throw new ArgumentException("El ID no tiene un valor real.");
            _usuario.Id = id;
            return this;
        }

        public UsuarioBuilder ConPrimerNombre(string primerNombre)
        {
            /// <summary>
            /// Establece le primer nombre del usuario
            /// </summary>
            /// <param  name="primerNombre">El primer nombre del usuario</param>
            if (string.IsNullOrWhiteSpace(primerNombre))
                throw new ArgumentException("El primer nombre no puede estar vacío.");
            _usuario.PrimerNombre = primerNombre;
            return this;
        }

        public UsuarioBuilder ConSegundoNombre(string? segundoNombre)
        {
            /// <summary>
            /// Establece el segundo nombre del usuario, si aplica.
            /// </summary>
            _usuario.SegundoNombre = segundoNombre;
            return this;
        }

        public UsuarioBuilder ConPrimerApellido(string primerApellido)
        {
            /// <summary>
            /// Establece el primer apellido del usuario
            /// </summary>
            if (string.IsNullOrWhiteSpace(primerApellido))
                throw new ArgumentException("El primer apellido no puede estar vacío.");
            _usuario.PrimerApellido = primerApellido;
            return this;
        }

        public UsuarioBuilder ConSegundoApellido(string? segundoApellido)
        {
            /// <summary>
            /// Establece el segundo apellido del usuario, si aplica.
            /// </summary>
            _usuario.SegundoApellido = segundoApellido;
            return this;
        }

        public UsuarioBuilder ConTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
        {
            /// <summary>
            /// Establece el tipo de identificación de un usuario
            /// </summary>
            _usuario.TipoIdentificacion = tipoIdentificacion;
            return this;
        }

        public UsuarioBuilder ConIdentificacionPersonal(string identificacionPersonal)
        {
            /// <summary>
            /// Establece el número de identificación de un usuario.
            /// </summary>
            if (string.IsNullOrWhiteSpace(identificacionPersonal))
                throw new ArgumentException("La identificación es obligatoria.");
            _usuario.IdentificacionPersonal = identificacionPersonal;
            return this;
        }

        public UsuarioBuilder ConTipoIdenTrib(TipoIdenTrib tipoIdenTrib)
        {
            /// <summary>
            /// Establece el tipo de identidad tributario de un usuario.
            /// </summary>
            _usuario.TipoIdenTrib = tipoIdenTrib;

            // Si el tipi es "NoAplica", el valor de IdenTrib se establece como vacío
            if (tipoIdenTrib == TipoIdenTrib.NoAplica)
            {
                _usuario.IdenTrib = string.Empty;
            }
            return this;
        }

        public UsuarioBuilder ConIdenTrib(string  idenTrib)
        {
            /// <summary>
            /// Establece el número de la identificación tributaria del usuario
            /// </summary>
             
            // Si el tipo de identificación es "NoAplica", no se debería permitir asignar un valor
            if (_usuario.TipoIdenTrib == TipoIdenTrib.NoAplica)
                throw new InvalidOperationException("No se puede asignar un valor a la Identificación Tributaria cuando su tipo es No Aplica.");
            // Valida si el tipo de IdentTrib es nulo o vacio para NIT o RUT
            if(string.IsNullOrWhiteSpace(idenTrib))
                throw new  ArgumentException("La identificación tributaria es obligatoria.");

            _usuario.IdenTrib = idenTrib;
            return this;
        }

        public UsuarioBuilder ConTipoSegSoc(TipoSegSoc tipoSegSoc)
        {
            _usuario.TipoSegSoc =  tipoSegSoc;
            return this;

        }

        public UsuarioBuilder ConEntidadPrestadora(string entidadPrestadora)
        {
            /// <summary>
            /// Representa el nombre de la entidad prestadora de seguridad social
            /// OJO DEBEMOS CORREGIR Y QUE PERMITA QUE CUANDO SELECCIONE 1 PUEDA LLENAR EL FORMULARIO
            /// DE ENTSALUD Y CUANDO SELECCIONE 2 PUEDA LLENAR EL FORMULARIO DE PENSION
            /// </summary>
            if (string.IsNullOrWhiteSpace(entidadPrestadora))
            {
                throw new ArgumentException("El campo debe contener el nombre de la entidad");
            }
             return this;
        }

        public UsuarioBuilder ConEsContador(bool esContador)
        {
            ///  <summary>
            ///  Representa la calidad o no de un usuario de ser contador
            /// </summary>
            _usuario.EsContador = esContador;
            return this;
        }

        public UsuarioBuilder ConTarProf(string? tarProf)
        {
            /// <summary>
            /// Representa el número de número de la tarjeta profesional de un usuario contador. 
            /// </summary>
            if(string.IsNullOrWhiteSpace(tarProf))
            {
                throw new ArgumentException("El campo debe contener un valor numérico");
                _usuario.TarProf = tarProf;
                return this;
            }
        }

        public UsuarioBuilder ConCiudad(string ciudad)
        {
            /// <summary>
            /// Establece la ciudad de domicilio  del usuario.
            /// </summary>
            _usuario.Ciudad = ciudad;
            return this;
        }

        public UsuarioBuilder ConDireccion(string direccion)
        {
            /// <summary>
            /// Establece la dirección de domicilio de un usuario
            /// </summary>
            _usuario.Direccion = direccion;
            return this;
        }

        public UsuarioBuilder ConTelefono(string telefono)
        {
            /// <summary>
            /// Establece el teléfono de contacto de un usuario
            /// </summary>
            if (telefono.Length < 7)
                throw new ArgumentException("El número telefónico debe ser mayor a 7 dígitos.");
            _usuario.Telefono = telefono;
            return this;
        }

        public UsuarioBuilder ConCorreo(string correo)
        {
            /// <summary>
            /// Establece el correo electrónico de contacto del usuario
            /// </summary>

            if (!new EmailAddressAttribute().IsValid(correo))
                throw new ArgumentException("Correo inválido.");
            _usuario.Correo = correo;
            return this;
        }

        public UsuarioBuilder ConClave(string clave)
        {
            /// <summary>
            /// Establece la clave o contraseña de acceso al sistema de  un usuario.
            /// </summary>
            if (clave.Length < 6)
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            _usuario.Clave = clave;
            return this;
        }

        public Usuario Build() => _usuario;
    }
}
