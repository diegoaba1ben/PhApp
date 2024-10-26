using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class EntSaludRepository : GenericRepository<EntSalud>, IEntSaludRepository
    {
        private readonly PhAppUserDbContext _context;

        public EntSaludRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EntSalud> ObtenerEntSaludPorNombreAsync(string nombre)
        {
            return await _context.Set<EntSalud>().FirstOrDefaultAsync(e => e.Nombre == nombre);
        }

        public async Task<IEnumerable<EntSalud>> ObtenerEntSaludActivasAsync()
        {
            return await _context.Set<EntSalud>().Where(e => e.EsActivo).ToListAsync();
        }
    }
}
