using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface ICargoRepository : IGenericRepository<Cargo>
    {
        // Métodos específicos para Cargo
        Task<Cargo> ObtenerCargoPorNombreAsync(string nombre);
        Task<IEnumerable<Cargo>> ObtenerCargosActivosAsync();
        Task<IEnumerable<Permiso>> ObtenerPermisosPorCargoAsync(int cargoId);
    }
}
