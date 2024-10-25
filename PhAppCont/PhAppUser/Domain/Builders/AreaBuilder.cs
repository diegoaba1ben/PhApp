using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Builders
{
    /// <summary>
    /// Builder para la clase Area, permitiendo la creación de una instancia de Area de manera externa.
    /// </summary>
    public class AreaBuilder
    {
        private readonly Area.AreaBuilder _builder;

        public AreaBuilder()
        {
            _builder = Area.Builder();
        }

        public AreaBuilder ConId(int id)
        {
            _builder.ConId(id);
            return this;
        }

        public AreaBuilder ConNombre(string nombre)
        {
            _builder.ConNombre(nombre);
            return this;
        }

        public AreaBuilder ConDescripcion(string descripcion)
        {
            _builder.ConDescripcion(descripcion);
            return this;
        }

        public AreaBuilder ConEsRepLegal(bool esRepLegal)
        {
            _builder.ConEsRepLegal(esRepLegal);
            return this;
        }

        public AreaBuilder ConCargo(Cargo cargo)
        {
            _builder.ConCargo(cargo);
            return this;
        }

        public Area Build()
        {
            return _builder.Build();
        }
    }
}
