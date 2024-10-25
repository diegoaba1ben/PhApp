using System;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Builders
{
    /// <summary>
    /// Builder para la clase Perfil, permitiendo la creación de un perfil combinando información de Usuario y Area.
    /// </summary>
    public class PerfilBuilder
    {
        private readonly Perfil.PerfilBuilder _builder;

        public PerfilBuilder()
        {
            _builder = Perfil.Builder();
        }

        public PerfilBuilder ConId(int id)
        {
            _builder.ConId(id);
            return this;
        }

        public PerfilBuilder ConUsuario(Usuario usuario)
        {
            _builder.ConUsuario(usuario);
            return this;
        }

        public PerfilBuilder ConArea(Area area)
        {
            _builder.ConArea(area);
            return this;
        }

        public PerfilBuilder ConCargo(Cargo cargo)
        {
            _builder.ConCargo(cargo);
            return this;
        }

        public PerfilBuilder ConFechaCreacion(DateTime fechaCreacion)
        {
            _builder.ConFechaCreacion(fechaCreacion);
            return this;
        }

        public Perfil Build()
        {
            return _builder.Build();
        }
    }
}
