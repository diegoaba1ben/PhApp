using System;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Entidad que representa los datos de un usuario de tipo Contador.
    /// </summary>
    public class Contador : Usuario
    {
        public string TarjProf { get; set; } // Tarjeta Profesional para Contador

        // Constructor privado para restringir la creación directa
        private Contador() 
        {
            TipoUsuario = TipoUsuario.Contador; // Establecer tipo de usuario como Contador de forma rígida
        }

        // Constructor para el uso del Builder
        public Contador(string tarjProf) : this() // Reutiliza el constructor privado
        {
            TarjProf = tarjProf; // Se asigna la tarjeta profesional
        }

        // Método estático para iniciar el proceso de creación de un Contador usando el Builder
        public static ContadorBuilder CrearContador()
        {
            return new ContadorBuilder();
        }

        // Clase interna ContadorBuilder para la creación fluida de instancias de Contador
        public class ContadorBuilder
        {
            private readonly Contador _contador;

            public ContadorBuilder()
            {
                _contador = new Contador(); // Instanciación estricta de Contador
            }

            // Métodos concatenados para atributos base (heredados de Usuario)
            public ContadorBuilder ConNombresCompletos(string nombresCompletos)
            {
                _contador.NombresCompletos = nombresCompletos;
                return this;
            }

            public ContadorBuilder ConApellidosCompletos(string apellidosCompletos)
            {
                _contador.ApellidosCompletos = apellidosCompletos;
                return this;
            }

            public ContadorBuilder ConTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
            {
                _contador.TipoIdentificacion = tipoIdentificacion;
                return this;
            }

            public ContadorBuilder ConIdentificacion(string identificacion)
            {
                _contador.Identificacion = identificacion;
                return this;
            }

            public ContadorBuilder ConDireccion(string direccion)
            {
                _contador.Direccion = direccion;
                return this;
            }

            public ContadorBuilder ConCiudad(string ciudad)
            {
                _contador.Ciudad = ciudad;
                return this;
            }

            public ContadorBuilder ConTelefono(string telefono)
            {
                _contador.Telefono = telefono;
                return this;
            }

            public ContadorBuilder ConEmail(string email)
            {
                _contador.Email = email;
                return this;
            }

            public ContadorBuilder ConNombreUsuario(string nombreUsuario)
            {
                _contador.NombreUsuario = nombreUsuario;
                return this;
            }

            public ContadorBuilder ConPassword(string password)
            {
                _contador.Password = password;
                return this;
            }

            // Método concatenado para Tarjeta Profesional (atributo específico de Contador)
            public ContadorBuilder ConTarjProf(string tarjProf)
            {
                _contador.TarjProf = tarjProf;
                return this;
            }

            // Método para devolver el Contador creado
            public Contador Build()
            {
                return _contador;
            }
        }
    }
}
