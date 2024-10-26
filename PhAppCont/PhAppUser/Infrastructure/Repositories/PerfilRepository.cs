using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        private readonly PhAppUserDbContext _context;

        public PerfilRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Perfil> ObtenerPerfilPorUsuarioIdAsync(int usuarioId)
        {
            return await _context.Set<Perfil>()
                .Include(p => p.Usuario)
                .Include(p => p.Area)
                .Include(p => p.Cargo)
                .ThenInclude(c => c.Permisos) // Incluir los permisos asociados al cargo
                .FirstOrDefaultAsync(p => p.Usuario.Id == usuarioId);
        }

        public async Task<IEnumerable<Perfil>> ObtenerPerfilesActivosAsync()
        {
            return await _context.Set<Perfil>()
                .Where(p => p.EsActivo)
                .Include(p => p.Usuario)
                .Include(p => p.Area)
                .Include(p => p.Cargo)
                .ThenInclude(c => c.Permisos) // Incluir los permisos
                .ToListAsync();
        }

        public async Task<bool> ExisteOtroRepLegalEnAreaAsync(int areaId)
        {
            return await _context.Set<Perfil>()
                .AnyAsync(p => p.Cargo.Nombre == "RepLegal" && p.Area.Id == areaId);
        }
    }
}
