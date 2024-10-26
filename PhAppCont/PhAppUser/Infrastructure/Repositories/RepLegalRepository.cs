using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class RepLegalRepository : GenericRepository<RepLegal>, IRepLegalRepository
    {
        private readonly PhAppUserDbContext _context;

        public RepLegalRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepLegal> ObtenerRepLegalPorIdentificacionAsync(string identificacion)
        {
            return await _context.Set<RepLegal>().FirstOrDefaultAsync(r => r.Identificacion == identificacion);
        }

        public async Task<IEnumerable<RepLegal>> ObtenerRepsLegalesActivosAsync()
        {
            return await _context.Set<RepLegal>().Where(r => r.EsActivo).ToListAsync();
        }

        public async Task<IEnumerable<RepLegal>> ObtenerRepsLegalesPorFechaFinalAsync(DateTime fechaFinal)
        {
            return await _context.Set<RepLegal>().Where(r => r.FechaFinal == fechaFinal).ToListAsync();
        }
    }
}
