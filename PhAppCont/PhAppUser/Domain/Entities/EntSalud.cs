using System;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los atributos específicos de EntSalud.
    /// </summary>
    public class EntSalud : EntidadPrestadora
    {
        /// <summary>
        /// Tipo de cobertura de la afiliación.
        /// </summary>
        public string Cobertura { get; set; }

        /// <summary>
        /// Constructor vacío requerido por EF Core.
        /// </summary>
        public EntSalud()
        { 
            Cobertura = string.Empty;
        }

        /// <summary>
        /// Constructor con parámetros.
        /// </summary>
        /// <param name="nombre">Nombre de la entidad prestadora de salud.</param>
        /// <param name="nit">Número de identificación tributaria.</param>
        /// <param name="direccion">Dirección de la entidad.</param>
        /// <param name="telefono">Teléfono de contacto.</param>
        /// <param name="correo">Correo electrónico.</param>
        /// <param name="nroAfiliacion">Número de afiliación.</param>
        /// <param name="fechaInicio">Fecha de inicio de la cobertura.</param>
        /// <param name="fechaFin">Fecha de finalización de la cobertura.</param>
        /// <param name="cobertura">Tipo de cobertura.</param>
        public EntSalud(string nombre, string nit, string direccion, string telefono, string correo, string nroAfiliacion, DateTime fechaInicio, DateTime fechaFin, string cobertura)
            : base(TipoEntPrestadora.Salud, nombre, nit, direccion, telefono, correo, nroAfiliacion)
        {
            Cobertura = cobertura;
        }
    }
}


