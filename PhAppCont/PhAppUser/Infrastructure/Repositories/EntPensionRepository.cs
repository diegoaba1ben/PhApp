using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class EntPensionRepository : GenericRepository<EntPension>, IEntPensionRepository
    {
        private readonly PhAppUserDbContext _context;

        public EntPensionRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EntPension> ObtenerEntPensionPorNombreAsync(string nombre)
        {
            return await _context.Set<EntPension>().FirstOrDefaultAsync(e => e.Nombre == nombre);
        }

        public async Task<IEnumerable<EntPension>> ObtenerEntPensionActivasAsync()
        {
            return await _context.Set<EntPension>().Where(e => e.EsActivo).ToListAsync();
        }
    }
}
