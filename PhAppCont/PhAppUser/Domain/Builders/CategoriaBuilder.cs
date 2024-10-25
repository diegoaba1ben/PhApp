using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Builders
{
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

        public CategoriaBuilder ConRepLegal(bool esRepLegal)
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
