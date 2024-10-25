
using System;
using System.Collections.Generic;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un cargo en el sistema, que está asociado a varios permisos.
    /// </summary>
    public class Cargo
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string Creador { get; private set; }
        public bool Estado { get; private set; }

        // Relación muchos a muchos con Permiso
        public ICollection<Permiso> Permisos { get; private set; }

        // Constructor privado para uso del Builder
        private Cargo()
        {
            Permisos = new List<Permiso>();
        }

        /// <summary>
        /// Builder estático para crear un nuevo Cargo.
        /// </summary>
        public static CargoBuilder Builder() => new CargoBuilder();

        public class CargoBuilder
        {
            private readonly Cargo _cargo;

            public CargoBuilder()
            {
                _cargo = new Cargo();
            }

            public CargoBuilder ConId(int id)
            {
                _cargo.Id = id;
                return this;
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

            public CargoBuilder ConFechaCreacion(DateTime fechaCreacion)
            {
                _cargo.FechaCreacion = fechaCreacion;
                return this;
            }

            public CargoBuilder ConCreador(string creador)
            {
                _cargo.Creador = creador;
                return this;
            }

            public CargoBuilder ConEstado(bool estado)
            {
                _cargo.Estado = estado;
                return this;
            }

            public CargoBuilder ConPermiso(Permiso permiso)
            {
                _cargo.Permisos.Add(permiso);
                return this;
            }

            public Cargo Build()
            {
                return _cargo;
            }
        }
    }
}






