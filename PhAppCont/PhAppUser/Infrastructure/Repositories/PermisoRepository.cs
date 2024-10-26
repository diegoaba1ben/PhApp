using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class PermisoRepository : GenericRepository<Permiso>, IPermisoRepository
    {
        private readonly PhAppUserDbContext _context;

        public PermisoRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Permiso> ObtenerPermisoPorNombreAsync(string nombre)
        {
            return await _context.Set<Permiso>().FirstOrDefaultAsync(p => p.Nombre == nombre);
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisosActivosAsync()
        {
            return await _context.Set<Permiso>().Where(p => p.Estado).ToListAsync();
        }
    }
}
