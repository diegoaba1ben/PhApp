using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    public class EntSalud
    {
        /// <summary>
        /// Clase encargada de registrar las  entidades de salud

        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary
        /// Nombre de la entidad de salud
        /// </summary>
        [Required]
        [StringLength(30, MinimumLength =3)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Número de Identificación Tributaria (NIT)
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength =2)]
        public string Nit { get; set;} =string.Empty;

        ///  <summary>
        ///  Dirección de la entidad de salud
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; } = string.Empty;

        ///  <summary>
        ///  Teléfono de la entidad de salud
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;
        
        /// <summary>
        /// Correo electrónico de contacto
        /// </summary>
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; } = string.Empty;

        ///  <summary>
        ///  Número de afiliación del usuario a esta entidad
        /// </summary>
        [Required]
        [StringLength(30)]
        public string  NroAfiliacion { get; set; } = string.Empty;

        ///  <summary>
        ///  Propiedadad navegacional 1 a 1 con Usuario
        /// </summary>
        public int UsuarioId { get; set; }

        ///  <summary>
        ///  Clase navegaciocional con usuario
        /// </summary>
        public Usuario? usuario { get; set; }

        ///  <summary>
        ///  Constructor vacío requerido por EF Core
        /// </summary>
        public EntSalud()
        {

        }

        ///  <summary>
        ///  Constructor con parámetros
        /// </summary>
        public EntSalud(string nombre, string nit, string direccion, string telefono, string correo, string NroAfiliacion)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Nit = nit ?? throw new ArgumentNullException (nameof(nit));
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
            Correo = correo ?? throw new ArgumentNullException(nameof(correo));
            NroAfiliacion = NroAfiliacion ?? throw new ArgumentNullException(nameof(NroAfiliacion));
        }
    }
}