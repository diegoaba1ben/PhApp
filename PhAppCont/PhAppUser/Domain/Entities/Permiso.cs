using System;
using System.ComponentModel.DataAnnotations;


namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa los permisos que definen las funcionalidades accesibles para un usuario.
    /// </summary>
    public class Permiso
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Creador { get; private set; }
        public string Categoria { get; private set; }
        public bool Estado { get; private set; }

        // Constructor privado para uso exclusivo del builder.
        private Permiso() { }

        /// <summary>
        /// Builder estático para crear un nuevo permiso.
        /// </summary>
        public static PermisoBuilder Builder() => new PermisoBuilder();

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
}
