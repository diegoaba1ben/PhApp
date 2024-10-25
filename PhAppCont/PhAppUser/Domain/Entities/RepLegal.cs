using System;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Entidad que representa los datos de un usuario de tipo Representante Legal (RepLegal).
    /// </summary>
    public class RepLegal : Usuario
    {
        public string CertLegal { get; set; } // Certificación legal para el representante
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        // Constructor privado para restringir la creación directa
        private RepLegal() 
        {
            TipoUsuario = TipoUsuario.RepLegal; // Establecer tipo de usuario como RepLegal de forma rígida
        }

        // Constructor para el uso del Builder
        public RepLegal(string certLegal, DateTime fechaInicio, DateTime fechaFinal) : this()
        {
            CertLegal = certLegal;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
        }

        // Método estático para iniciar el proceso de creación de un RepLegal usando el Builder
        public static RepLegalBuilder CrearRepLegal()
        {
            return new RepLegalBuilder();
        }

        // Clase interna RepLegalBuilder para la creación fluida de instancias de RepLegal
        public class RepLegalBuilder
        {
            private readonly RepLegal _repLegal;

            public RepLegalBuilder()
            {
                _repLegal = new RepLegal(); // Instanciación estricta de RepLegal
            }

            // Métodos concatenados para atributos base (heredados de Usuario)
            public RepLegalBuilder ConNombresCompletos(string nombresCompletos)
            {
                _repLegal.NombresCompletos = nombresCompletos;
                return this;
            }

            public RepLegalBuilder ConApellidosCompletos(string apellidosCompletos)
            {
                _repLegal.ApellidosCompletos = apellidosCompletos;
                return this;
            }

            public RepLegalBuilder ConTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
            {
                _repLegal.TipoIdentificacion = tipoIdentificacion;
                return this;
            }

            public RepLegalBuilder ConIdentificacion(string identificacion)
            {
                _repLegal.Identificacion = identificacion;
                return this;
            }

            public RepLegalBuilder ConDireccion(string direccion)
            {
                _repLegal.Direccion = direccion;
                return this;
            }

            public RepLegalBuilder ConCiudad(string ciudad)
            {
                _repLegal.Ciudad = ciudad;
                return this;
            }

            public RepLegalBuilder ConTelefono(string telefono)
            {
                _repLegal.Telefono = telefono;
                return this;
            }

            public RepLegalBuilder ConEmail(string email)
            {
                _repLegal.Email = email;
                return this;
            }

            public RepLegalBuilder ConNombreUsuario(string nombreUsuario)
            {
                _repLegal.NombreUsuario = nombreUsuario;
                return this;
            }

            public RepLegalBuilder ConPassword(string password)
            {
                _repLegal.Password = password;
                return this;
            }

            // Métodos concatenados para atributos específicos de RepLegal
            public RepLegalBuilder ConCertLegal(string certLegal)
            {
                _repLegal.CertLegal = certLegal;
                return this;
            }

            public RepLegalBuilder ConFechaInicio(DateTime fechaInicio)
            {
                _repLegal.FechaInicio = fechaInicio;
                return this;
            }

            public RepLegalBuilder ConFechaFinal(DateTime fechaFinal)
            {
                _repLegal.FechaFinal = fechaFinal;
                return this;
            }

            // Método para devolver el RepLegal creado
            public RepLegal Build()
            {
                return _repLegal;
            }
        }
    }
}
