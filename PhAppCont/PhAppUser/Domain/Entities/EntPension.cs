using System;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los atributos específicos de EntPension.
    /// </summary>
    public class EntPension
    {
        /// <summary>
        /// Tipo de identificación tributaria
        /// </summary>
        public TipoIdenTrib TipoIdenTrib { get; set; }

        /// <summary>
        /// Número de la identificación tributaria
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Nombre de la entidad prestadora
        /// </summary>
        public string RazonSocial { get; set; }

        /// <summary>
        /// Constructor privado para uso del Builder.
        /// </summary>
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

            public EntPensionBuilder ConTipoIdenTrib(TipoIdenTrib tipoIdenTrib)
            {
                _entPension.TipoIdenTrib = tipoIdenTrib;
                return this;
            }

            public EntPensionBuilder ConRazonSocial(string razonSocial)
            {
                _entPension.RazonSocial = razonSocial;
                return this;
            }

            public EntPensionBuilder ConNumero(string numero)
            {
                _entPension.Numero = numero;
                return this;
            }

            public EntPension Build()
            {
                return _entPension;
            }
        }
    }
}

