
using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un cargo dentro de una categoría en el sistema.
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// Identificador único del cargo.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del cargo.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // Ejemplo: "Contador", "Analista Contable", etc.

        /// <summary>
        /// Descripción del cargo.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Define si este cargo es de contador.
        /// </summary>
        public bool EsContador { get; set; } = false;

        ///  <summary>
        ///  Constructor privado para forzar el uso del builder interno.
        /// </summary>
        private Cargo(){ }

        public static CargoBuilder() => new cargoBuilder();

        public class CargoBuilder
        {
            private Cargo _cargo;
            public CargoBuilder()
            {
                _cargo = new Cargo();
            }
            public CargoBuilder ConNombre(string nombre)
            {
                _cargo.Nombre = nombre;
                return this;
            }
            public CargoBuilder ConDescripcion(string descripcion)
            {
                _cargo.Descripcion = descripcion;
                return this;
            }
            public  CargoBuilder EsContador(bool esContador)
            {
                _cargo.EsContador = esContador;
                return this;
            }
            public Cargo Build()
            {
                return _cargo;
            }

        }
    }
}





