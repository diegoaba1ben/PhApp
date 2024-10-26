using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    public interface IPerfilRepository : IGenericRepository<Perfil>
    {
        // Métodos específicos para Perfil
        Task<Perfil> ObtenerPerfilPorUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<Perfil>> ObtenerPerfilesActivosAsync();
        Task<bool> ExisteOtroRepLegalEnAreaAsync(int areaId);
    }
}
