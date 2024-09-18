using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    public class Pension
    {
        /// <summary>
        /// Clase encargada de registrar los fondos de pensión

        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary
        /// Nombre de los fondos de pensión
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
        ///  Dirección del fondo de pensión
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; } = string.Empty;

        ///  <summary>
        ///  Teléfono del fondo de pensión
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico de  contacto
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
        ///  Clase navegacional con usuario
        /// </summary>
        public Usuario? Usuario { get; set; }


        ///  <summary>
        ///  Constructor vacío requerido por EF Core
        /// </summary>
        public Pension()
        {

        }

        ///  <summary>
        ///  Constructor con parámetros
        /// </summary>
        public Pension(string nombre, string nit, string direccion, string telefono, string correo, string NroAfiliacion)
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