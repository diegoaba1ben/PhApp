using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Perfil que interactúa con la base de datos.
    /// </summary>
    public class PerfilUsuarioRepository : IPerfilUsuarioRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de PerfilUsuarioRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de usuarios.</param>
        public PerfilUsuarioRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los perfiles de usuarios.
        /// </summary>
        /// <returns>Una lista de objetos PerfilUsuario.</returns>
        public async Task<IEnumerable<PerfilUsuario>> GetAllAsync()
        {
            return await _context.PerfilesUsuarios
                .Include(p => p.Usuario)
                .Include(p => p.Cargo)
                .Include(p => p.Categorias)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un Perfil por su ID.
        /// </summary>
        /// <param name="id">El ID del Perfil a buscar.</param>
        /// <returns>El objeto PerfilUsuario si se encuentra, o null si no se encuentra.</returns>
        public async Task<PerfilUsuario> GetByIdAsync(int id)
        {
            return await _context.PerfilesUsuarios
                .Include(p => p.Usuario)
                .Include(p => p.Cargo)
                .Include(p => p.Categorias)
                .FirstOrDefaultAsync(p => p.PerfilUsuarioId == id);
        }

        /// <summary>
        /// Agrega un nuevo perfil a la base de datos.
        /// </summary>
        /// <param name="perfilUsuario">El objeto PerfilUsuario a agregar.</param>
        public async Task AddAsync(PerfilUsuario perfilUsuario)
        {
            await _context.PerfilesUsuarios.AddAsync(perfilUsuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un perfilUsuario existente en la base de datos.
        /// </summary>
        /// <param name="perfilUsuario">El objeto PerfilUsuario con los nuevos valores.</param>
        public async Task UpdateAsync(PerfilUsuario perfilUsuario)
        {
            try
            {
                var perfilUsuarioExistente = await _context.PerfilesUsuarios.FindAsync(perfilUsuario.PerfilUsuarioId);
                if (perfilUsuarioExistente != null)
                {
                    _context.Entry(perfilUsuarioExistente).CurrentValues.SetValues(perfilUsuario);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                // Manejo de errores de actualización
                throw new Exception($"Error al actualizar el perfil con ID {perfilUsuario.PerfilUsuarioId}: no se encontró en la base de datos.", ex);
            }
        }

        /// <summary>
        /// Elimina un perfilUsuario por su ID.
        /// </summary>
        /// <param name="id">El ID del perfilusuario a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var perfilUsuario = await _context.PerfilesUsuarios.FindAsync(id);
            if (perfilUsuario != null)
            {
                _context.PerfilesUsuarios.Remove(perfilUsuario);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Búsqueda de perfiles por usuario.
        /// </summary>
        /// <param name="usuarioId">ID del usuario asociado al perfil.</param>
        public async Task<IEnumerable<PerfilUsuario>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.PerfilesUsuarios
                .Where(p => p.UsuarioId == usuarioId)
                .Include(p => p.Cargo)
                .Include(p => p.Categorias)
                .ToListAsync();
        }
    }
}
