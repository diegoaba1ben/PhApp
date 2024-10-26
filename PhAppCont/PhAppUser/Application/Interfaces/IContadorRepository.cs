using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interface
{
    public interface IContadorRepository : IGenericRepository<Contador>
    {
        // Métodos específicos para contador
        Task<Contador> ObtContadorPorIdentificacionAsync(string identificacion);
        Task<IEnumerable<Contador>> ObtContadoresAsync();
    }
}