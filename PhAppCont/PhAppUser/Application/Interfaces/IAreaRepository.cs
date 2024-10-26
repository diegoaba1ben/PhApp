using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area>
    {
        // Métodos específicos para Área
        Task<Area> ObtenerAreaPorNombreAsync(string nombre);
        Task<IEnumerable<Area>> ObtenerAreasActivasAsync();
        Task<IEnumerable<Cargo>> ObtenerCargosPorAreaAsync(int areaId);
    }
}
