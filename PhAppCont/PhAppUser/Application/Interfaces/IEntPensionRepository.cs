using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IEntPensionRepository : IGenericRepository<EntPension>
    {
        // Métodos específicos para EntPension, si son necesarios
        Task<EntPension> ObtenerEntPensionPorNombreAsync(string nombre);
        Task<IEnumerable<EntPension>> ObtenerEntPensionActivasAsync();
    }
}
