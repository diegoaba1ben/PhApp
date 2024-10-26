using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IRepLegalRepository : IGenericRepository<RepLegal>
    {
        // Definición de los métodos específicos de RepLegal
        Task<RepLegal> ObtRepLegalPorIdentificacionAsync(string Identificacion);
        Task<IEnumerable<RepLegal>> ObtRepLegalesActivosAsync();
        Task<RepLegal> ObtRepLegalPorFechaFinalASync(DateTime FechaFinal)
    }
}