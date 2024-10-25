using System;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa un perfil en el sistema, combinando información de usuario y área.
    /// </summary>
    public class Perfil
    {
        #region Propiedades del Perfil

        /// <summary>
        /// Identificador único del perfil.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Usuario asignado a este perfil.
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Área asignada a este perfil.
        /// </summary>
        public Area Area { get; private set; }

        /// <summary>
        /// Rol específico dentro del área (ej. Contador, RepLegal).
        /// </summary>
        public Cargo Cargo { get; private set; }

        /// <summary>
        /// Fecha de creación del perfil.
        /// </summary>
        public DateTime FechaCreacion { get; private set; }

        #endregion

        // Constructor privado para uso del builder
        private Perfil() { }

        /// <summary>
        /// Inicia el builder para crear una nueva instancia de Perfil.
        /// </summary>
        public static PerfilBuilder Builder() => new PerfilBuilder();

        public class PerfilBuilder
        {
            private readonly Perfil _perfil;

            public PerfilBuilder()
            {
                _perfil = new Perfil();
            }

            #region Métodos concatenados para asignar propiedades

            public PerfilBuilder ConId(int id)
            {
                _perfil.Id = id;
                return this;
            }

            public PerfilBuilder ConUsuario(Usuario usuario)
            {
                _perfil.Usuario = usuario;
                return this;
            }

            public PerfilBuilder ConArea(Area area)
            {
                _perfil.Area = area;
                return this;
            }

            public PerfilBuilder ConCargo(Cargo cargo)
            {
                // Lógica para garantizar la unicidad del RepLegal
                if (cargo.Nombre == "RepLegal" && ExisteRepLegalEnArea(area))
                {
                    throw new InvalidOperationException("Ya existe un representante legal en esta área.");
                }

                _perfil.Cargo = cargo;
                return this;
            }

            public PerfilBuilder ConFechaCreacion(DateTime fechaCreacion)
            {
                _perfil.FechaCreacion = fechaCreacion;
                return this;
            }

            #endregion

            public Perfil Build()
            {
                return _perfil;
            }

            /// <summary>
            /// Lógica para verificar la unicidad del RepLegal en el área.
            /// </summary>
            private bool ExisteRepLegalEnArea(Area area)
            {
                // Aquí se puede implementar una consulta para verificar si ya existe un RepLegal en la colección de cargos del área
                // Por ejemplo, consultar una base de datos o una lista en memoria
                return area.Cargos.Any(c => c.Nombre == "RepLegal");
            }
        }
    }
}

