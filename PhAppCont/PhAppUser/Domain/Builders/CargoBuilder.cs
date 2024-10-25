namespace PhAppUser.Domain.Builders
{
    public class CargoBuilder
    {
        private Cargo _cargo;

        public CargoBuilder()
        {
            _cargo = new Cargo();
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

        public CargoBuilder EsContador(bool esContador)
        {
            _cargo.EsContador = esContador;
            return this;
        }

        public Cargo Build()
        {
            return _cargo;
        }
    }
}
