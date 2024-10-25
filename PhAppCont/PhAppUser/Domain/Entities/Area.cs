using  System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa una categoría o rol en el sistema.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } // Ejemplo: "Financiera", "Administrativa", etc.

        /// <summary>
        /// Descripción de la categoría.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Define si la categoría tiene responsabilidades de representación legal.
        /// </summary>
        public bool EsRepLegal { get; set; } = false;

        ///  <summary>
        ///  Constructor privado para forzar el uso del Builder
        /// </summary>
        private Categoria(){ }

        public static CategoriaBuilder Builder() => new CategoriaBuilder();

        public class CategoriaBuilder
        {
            private Categoria _categoria;

            public CategoriaBuilder()
            {
                _categoria = new Categoria();
            }
            public CategoriaBuilder ConNombre(string nombre)
            {
                _categoria.Nombre = nombre;
                return this;
            }
            public CategoriaBuilder ConDescripcion(string descripcion)
            {
                _categoria.Descripcion = descripcion;
                return this;
            }
            public CategoriaBuilder ConEsRepLegal(bool esRepLegal)
            {
                _categoria.EsRepLegal = esRepLegal;
                return this;
            }
            public Categoria Build()
            {
                return _categoria;
            }
        }
    }
}



