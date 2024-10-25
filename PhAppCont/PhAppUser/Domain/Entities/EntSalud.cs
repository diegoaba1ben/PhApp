using System;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los atributos específicos de EntSalud.
    /// </summary>
    public class EntSalud
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

            public EntSaludBuilder ConTipoIdenTrib(TipoIdenTrib tipoIdenTrib)
            {
                _entSalud.TipoIdenTrib = tipoIdenTrib;
                return this;
            }

            public EntSaludBuilder ConRazonSocial(string razonSocial)
            {
                _entSalud.RazonSocial = razonSocial;
                return this;
            }

            public EntSaludBuilder ConNumero(string numero)
            {
                _entSalud.Numero = numero;
                return this;
            }

            public EntSalud Build()
            {
                return _entSalud;
            }
        }
    }
}

