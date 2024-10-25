using System;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los atributos específicos de EntSalud.
    /// </summary>
    public class EntSalud
    {
        public TipoIdenTrib TipoIdenTrib { get; set; }
        public string Numero { get; set; }
        public string RazonSocial { get; set; }

        // Constructor privado para uso exclusivo del Builder.
        private EntSalud() {}

        /// <summary>
        /// Builder estático para crear una nueva EntSalud.
        /// </summary>
        public static EntSaludBuilder Builder() => new EntSaludBuilder();

        public class EntSaludBuilder
        {
            private readonly EntSalud _entSalud;

            public EntSaludBuilder()
            {
                _entSalud = new EntSalud();
            }

            /// <summary>
            /// Configura el tipo de identificación tributaria.
            /// </summary>
            public EntSaludBuilder ConTipoIdenTrib(TipoIdenTrib tipoIdenTrib)
            {
                _entSalud.TipoIdenTrib = tipoIdenTrib;
                return this;
            }

            /// <summary>
            /// Configura el número de identificación tributaria.
            /// </summary>
            public EntSaludBuilder ConNumero(string numero)
            {
                _entSalud.Numero = numero;
                return this;
            }

            /// <summary>
            /// Configura la razón social de la entidad prestadora de salud.
            /// </summary>
            public EntSaludBuilder ConRazonSocial(string razonSocial)
            {
                _entSalud.RazonSocial = razonSocial;
                return this;
            }

            /// <summary>
            /// Construye y devuelve el objeto EntSalud.
            /// </summary>
            public EntSalud Build()
            {
                return _entSalud;
            }
        }
    }
}
