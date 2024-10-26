using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces;
{
    public interface IEntSaludRepository : IGenericRepository<EntSalud>
    {
        // Define los métodos para EntSalud
        Task<EntSalud> ObtEntSaludPorNombreAsync(string nombre);
        Task<IEnumerable<EntSalud>>ObtEntSaludActivaAsync();
    }
}