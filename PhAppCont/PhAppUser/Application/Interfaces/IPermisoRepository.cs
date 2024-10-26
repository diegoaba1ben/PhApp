using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IPermisoRepository : IGenericRepository<Permiso>
    {
        // Métodos específicos para Permiso, si los necesitas
        Task<Permiso> ObtenerPermisoPorNombreAsync(string nombre);
        Task<IEnumerable<Permiso>> ObtenerPermisosActivosAsync();
    }
}
