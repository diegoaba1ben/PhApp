using PhAppUser.Domain.Entities;
using System.Collections.Generic;

namespace PhAppUser.Domain.Builders
{
    /// <summary>
    /// Builder para construir instancias de PerfilUsuario usando un patrón fluido.
    /// </summary>
    public class PerfilUsuarioBuilder : IPerfilUsuarioBuilder
    {
        private int _perfilUsuarioId;
        private int _usuarioId;
        private Usuario _usuario;
        private int _cargoId;
        private Cargo _cargo;
        private ICollection<Categoria> _categorias;

        /// <summary>
        /// Constructor inicializa las propiedades por defecto.
        /// </summary>
        public PerfilUsuarioBuilder()
        {
            _categorias = new HashSet<Categoria>();  // Inicialización de la colección de categorías.
        }

        /// <summary>
        /// Asigna el identificador del perfil del usuario.
        /// </summary>
        /// <param name="perfilUsuarioId">Id del perfil del usuario.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithPerfilUsuarioId(int perfilUsuarioId)
        {
            _perfilUsuarioId = perfilUsuarioId;
            return this;
        }

        /// <summary>
        /// Asigna el identificador del usuario.
        /// </summary>
        /// <param name="usuarioId">Id del usuario asociado.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithUsuarioId(int usuarioId)
        {
            _usuarioId = usuarioId;
            return this;
        }

        /// <summary>
        /// Asigna el usuario asociado al perfil.
        /// </summary>
        /// <param name="usuario">Objeto Usuario asociado.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithUsuario(Usuario usuario)
        {
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
            return this;
        }

        /// <summary>
        /// Asigna el identificador del cargo asociado al perfil.
        /// </summary>
        /// <param name="cargoId">Id del cargo asociado.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithCargoId(int cargoId)
        {
            _cargoId = cargoId;
            return this;
        }

        /// <summary>
        /// Asigna el cargo asociado al perfil.
        /// </summary>
        /// <param name="cargo">Objeto Cargo asociado.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithCargo(Cargo cargo)
        {
            _cargo = cargo ?? throw new ArgumentNullException(nameof(cargo), "El cargo no puede ser nulo.");
            return this;
        }

        /// <summary>
        /// Asigna una colección de categorías al perfil.
        /// </summary>
        /// <param name="categorias">Colección de categorías.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder WithCategorias(ICollection<Categoria> categorias)
        {
            _categorias = categorias ?? throw new ArgumentNullException(nameof(categorias), "Las categorías no pueden ser nulas.");
            return this;
        }

        /// <summary>
        /// Agrega una categoría individual a la colección de categorías del perfil.
        /// </summary>
        /// <param name="categoria">Objeto Categoria a agregar.</param>
        /// <returns>El mismo builder para encadenamiento.</returns>
        public PerfilUsuarioBuilder AddCategoria(Categoria categoria)
        {
            _categorias.Add(categoria);
            return this;
        }

        /// <summary>
        /// Crea una instancia de PerfilUsuario con las propiedades configuradas.
        /// </summary>
        /// <returns>Una instancia de PerfilUsuario.</returns>
        public PerfilUsuario Build()
        {
            return new PerfilUsuario
            {
                PerfilUsuarioId = _perfilUsuarioId,
                UsuarioId = _usuarioId,
                Usuario = _usuario,
                CargoId = _cargoId,
                Cargo = _cargo,
                Categorias = _categorias
            };
        }
    }

    /// <summary>
    /// Interfaz para el Builder de PerfilUsuario.
    /// </summary>
    public interface IPerfilUsuarioBuilder
    {
        PerfilUsuarioBuilder WithPerfilUsuarioId(int perfilUsuarioId);
        PerfilUsuarioBuilder WithUsuarioId(int usuarioId);
        PerfilUsuarioBuilder WithUsuario(Usuario usuario);
        PerfilUsuarioBuilder WithCargoId(int cargoId);
        PerfilUsuarioBuilder WithCargo(Cargo cargo);
        PerfilUsuarioBuilder WithCategorias(ICollection<Categoria> categorias);
        PerfilUsuarioBuilder AddCategoria(Categoria categoria);
        PerfilUsuario Build();
    }
}
