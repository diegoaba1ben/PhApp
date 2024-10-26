using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class ContadorRepository : GenericRepository<Contador>, IContadorRepository
    {
        private readonly PhAppUserDbContext _context;

        public ContadorRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Contador> ObtContadorPorIdentificacionAsync(string identificacion)
        {
            return await _context.Set<Contador>().FirstOrDefaultAsync(c => c.Identificacion == identificacion);
        }

        public async Task<IEnumerable<Contador>> ObtContadoresActivosAsync()
        {
            return await _context.Set<Contador>().Where(c => c.EsActivo).ToListAsync();
        }
    }
}
