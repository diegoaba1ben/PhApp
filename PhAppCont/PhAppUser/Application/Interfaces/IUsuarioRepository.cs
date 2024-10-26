using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        // Métodos específicos para Usuario
        Task<Usuario> ObtenerUsuarioPorIdentificacionAsync(string identificacion);
        Task<Usuario> ObtenerUsuarioPorEmailAsync(string email);
        Task<IEnumerable<Usuario>> ObtenerUsuariosPorEstadoAsync(bool estado);
    }
}
