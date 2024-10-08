using System;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Clase que representa una entidad prestadora de pensiones.
    /// Hereda de la clase EntidadPrestadora.
    /// </summary>
    public class Pension : EntidadPrestadora
    {
        /// <summary>
        /// Constructor de la clase Pension.
        /// </summary>
        /// <param name="tipo">Tipo de entidad prestadora (en este caso, debe ser Pensión).</param>
        /// <param name="nombre">Nombre de la entidad prestadora.</param>
        /// <param name="nit">Número de Identificación Tributaria (NIT).</param>
        /// <param name="direccion">Dirección de la entidad prestadora.</param>
        /// <param name="telefono">Teléfono de la entidad prestadora.</param>
        /// <param name="correo">Correo electrónico de contacto.</param>
        /// <param name="nroAfiliacion">Número de afiliación del usuario a esta entidad.</param>
        /// <param name="usuario">Usuario asociado a la entidad prestadora.</param>
        public Pension(TipoEntPrestadora tipo, string nombre, string nit, string direccion, string telefono, string correo, string nroAfiliacion, Usuario usuario)
            : base(tipo, nombre, nit, direccion, telefono, correo, nroAfiliacion, usuario)
        {
            // No se requieren atributos adicionales por ahora
        }
    }
}
