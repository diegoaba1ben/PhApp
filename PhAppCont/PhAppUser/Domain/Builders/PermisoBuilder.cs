using System;

namespace PhAppUser.Domain.Builders
{
    /// <summary>
    /// Builder para la clase Permiso, permitiendo la creación paso a paso.
    /// </summary>
    public class PermisoBuilder
    {
        private readonly Permiso _permiso;

        public PermisoBuilder()
        {
            _permiso = new Permiso();
        }

        public PermisoBuilder ConId(int id)
        {
            _permiso.Id = id;
            return this;
        }

        public PermisoBuilder ConNombre(string nombre)
        {
            _permiso.Nombre = nombre;
            return this;
        }

        public PermisoBuilder ConDescripcion(string descripcion)
        {
            _permiso.Descripcion = descripcion;
            return this;
        }

        public PermisoBuilder ConFechaCreacion(DateTime fechaCreacion)
        {
            _permiso.FechaCreacion = fechaCreacion;
            return this;
        }

        public PermisoBuilder ConCreador(string creador)
        {
            _permiso.Creador = creador;
            return this;
        }

        public PermisoBuilder ConCategoria(string categoria)
        {
            _permiso.Categoria = categoria;
            return this;
        }

        public PermisoBuilder ConEstado(bool estado)
        {
            _permiso.Estado = estado;
            return this;
        }

        public Permiso Build()
        {
            return _permiso;
        }
    }
}
