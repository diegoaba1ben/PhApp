using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly PhAppUserDbContext _context;

        public CargoRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cargo> ObtenerCargoPorNombreAsync(string nombre)
        {
            return await _context.Set<Cargo>().FirstOrDefaultAsync(c => c.Nombre == nombre);
        }

        public async Task<IEnumerable<Cargo>> ObtenerCargosActivosAsync()
        {
            return await _context.Set<Cargo>().Where(c => c.Estado).ToListAsync();
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisosPorCargoAsync(int cargoId)
        {
            var cargo = await _context.Set<Cargo>()
                .Include(c => c.Permisos) // Incluir la relación de Permisos
                .FirstOrDefaultAsync(c => c.Id == cargoId);

            return cargo?.Permisos ?? Enumerable.Empty<Permiso>();
        }
    }
}
