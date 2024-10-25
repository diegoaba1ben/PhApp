using System;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los atributos específicos de EntPension.
    /// </summary>
    public class EntPension
    {
        public TipoIdenTrib TipoIdenTrib { get; set; }
        public string Numero { get; set; }
        public string RazonSocial { get; set; }

        // Constructor privado para uso exclusivo del Builder.
        private EntPension() {}

        /// <summary>
        /// Builder estático para crear una nueva EntPension.
        /// </summary>
        public static EntPensionBuilder Builder() => new EntPensionBuilder();

        public class EntPensionBuilder
        {
            private readonly EntPension _entPension;

            public EntPensionBuilder()
            {
                _entPension = new EntPension();
            }

            /// <summary>
            /// Configura el tipo de identificación tributaria.
            /// </summary>
            public EntPensionBuilder ConTipoIdenTrib(TipoIdenTrib tipoIdenTrib)
            {
                _entPension.TipoIdenTrib = tipoIdenTrib;
                return this;
            }

            /// <summary>
            /// Configura el número de identificación tributaria.
            /// </summary>
            public EntPensionBuilder ConNumero(string numero)
            {
                _entPension.Numero = numero;
                return this;
            }

            /// <summary>
            /// Configura la razón social de la entidad prestadora de pensión.
            /// </summary>
            public EntPensionBuilder ConRazonSocial(string razonSocial)
            {
                _entPension.RazonSocial = razonSocial;
                return this;
            }

            /// <summary>
            /// Construye y devuelve el objeto EntPension.
            /// </summary>
            public EntPension Build()
            {
                return _entPension;
            }
        }
    }
}
