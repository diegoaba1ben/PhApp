using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        private readonly PhAppUserDbContext _context;

        public AreaRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Area> ObtenerAreaPorNombreAsync(string nombre)
        {
            return await _context.Set<Area>().FirstOrDefaultAsync(a => a.Nombre == nombre);
        }

        public async Task<IEnumerable<Area>> ObtenerAreasActivasAsync()
        {
            return await _context.Set<Area>().Where(a => a.EsActivo).ToListAsync();
        }

        public async Task<IEnumerable<Cargo>> ObtenerCargosPorAreaAsync(int areaId)
        {
            var area = await _context.Set<Area>()
                .Include(a => a.Cargos) // Incluye la relación con Cargos
                .FirstOrDefaultAsync(a => a.Id == areaId);

            return area?.Cargos ?? Enumerable.Empty<Cargo>();
        }
    }
}
