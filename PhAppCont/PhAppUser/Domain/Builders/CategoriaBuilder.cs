using System;
using System.Collections.Generic;
using PhAppUser.Domain.Builders

namespace PhAppUser.Domain.Builders
{
    /// <summary>
    /// Clase Builder para construir instancias de la entidad Categoria (Patrón Fluent Builder)
    /// </summary>
    public class CategoriaBuilder
    {
        private Categoria _categoria;

        /// <summary>
        /// Constructor para inicializar una nueva instancia del Builder
        /// </summary>
        public CategoriaBuilder()
        {
            _categoria = new Categoria();
        }
        /// <summary>
        /// Asigna el nombre a la categoría.
        /// </summary>
        /// <param name="nombre">Nombre de la categoría</param>
        /// <returns>Una instancia actualizada del builder</returns>
        public CategoriaBuilder ConNombre(string categoria)
        {
            _categoria.Nombre = nombre;
            return this;
        }

        ///  <summary>
        ///  Asigna una descripción a la categoría.
        /// </summary>
        /// <param name="descripcion">Descripción de la categoría</param>
        /// <returns>Una instancia actualizada del builder</returns>
        public CategoriaBuilder ConDescripcion(string descripcion)
        {
            _categoria.Descripcion = descripcion;
            return this;
        }
        /// <summary>
        /// Añade una categoría padre a los objetos Categoria
        /// </summary>
        /// <param name="categoriaPadre">Instancia de la categoría padre, si aplica</param>
        /// <returns>Una instancia actualizada del builder</returns>
        public CategoriaBuilder ConCategoriaPadre(Categoria categoriaPadre)
        {
            _categoria.CategoriaPadre = categoriaPadre;
            return this;
        }
        /// <summary>
        /// Añade un elemento a la lista de subcategorías de una categoría padre, si aplica.
        /// </summary>
        /// <param name="subCategoria">Instancia de la categoría hija, si aplica.</param>
        /// <returns>Una instancia actualizada de builder</returns>
        public  CategoriaBuilder AgregarSubCategoria(Categoria subCategoria)
        {
            if(_categoria.SubCategorias == null)
            {
                _categoria.SubCategoria = new List<Categoria>();
            }
            _categoria.SubCategorias.Add(subCategoria);
            return this;
        }
        ///  <summary>
        ///  Construye y retorna la instancia a la categorúa configurada.
        /// </summary>
        /// <returns>Una instancia final de la categoría configurada</returns>
        public CategoriaBuilder Build()
        {
            //Validación antes de construir la categoría final
            ValidarCategoria(_categoria);
            return _categoria;
        }
        ///  <summary>
        ///  Valida la categoría antes de construirla
        /// </summary>
        /// <param  name="categoria">Instancia de la categoría a validar</param>
        private void ValidarCategoria(Categoria categoria)
        {
            if (string.IsNullWhiteSpace(categoria.Nombre))
                throw new InvalidOperationException("La categoría debe tener un nombre.");
            if (string.IsNullWhiteSpace(categoria.Descripcion))
                throw new InvalidOperationException("La categoría debe tener una descripción");
        }
    }
}