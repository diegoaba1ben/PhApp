using Microsoft.EntityFrameworkCore;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;

namespace PhAppUser.Infrastructure.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly PhAppUserDbContext _context;

        public UsuarioRepository(PhAppUserDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> ObtenerUsuarioPorIdentificacionAsync(string identificacion)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Identificacion == identificacion);
        }

        public async Task<Usuario> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuariosPorEstadoAsync(bool estado)
        {
            return await _context.Usuarios.Where(u => u.EsActivo == estado).ToListAsync();
        }
    }
}
