using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa una área en el sistema, agrupando cargos bajo una temática específica.
    /// </summary>
    public class Area
    {
        #region Propiedades de Área

        /// <summary>
        /// Identificador único del área.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nombre del área, como "Financiera", "Administrativa", etc.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Descripción del área.
        /// </summary>
        public string Descripcion { get; private set; }

        /// <summary>
        /// Indica si el área tiene responsabilidades de representación legal.
        /// </summary>
        public bool EsRepLegal { get; private set; } = false;

        /// <summary>
        /// Colección de cargos asociados a esta área.
        /// </summary>
        public ICollection<Cargo> Cargos { get; private set; }

        #endregion

        // Constructor privado para asegurar que solo se pueda crear a través del builder.
        private Area()
        {
            Cargos = new List<Cargo>();
        }

        /// <summary>
        /// Inicia el builder para crear una nueva instancia de Area.
        /// </summary>
        public static AreaBuilder Builder() => new AreaBuilder();

        public class AreaBuilder
        {
            private readonly Area _area;

            public AreaBuilder()
            {
                _area = new Area();
            }

            #region Métodos concatenados para asignar propiedades

            public AreaBuilder ConId(int id)
            {
                _area.Id = id;
                return this;
            }

            public AreaBuilder ConNombre(string nombre)
            {
                _area.Nombre = nombre;
                return this;
            }

            public AreaBuilder ConDescripcion(string descripcion)
            {
                _area.Descripcion = descripcion;
                return this;
            }

            public AreaBuilder ConEsRepLegal(bool esRepLegal)
            {
                _area.EsRepLegal = esRepLegal;
                return this;
            }

            public AreaBuilder ConCargo(Cargo cargo)
            {
                _area.Cargos.Add(cargo);
                return this;
            }

            #endregion

            /// <summary>
            /// Construye y retorna la instancia de Area.
            /// </summary>
            public Area Build()
            {
                return _area;
            }
        }
    }
}




