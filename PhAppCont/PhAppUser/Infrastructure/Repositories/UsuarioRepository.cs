using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Usuario que interactúa con la base de datos.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de UsuarioRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de usuarios.</param>
        public UsuarioRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los usuarios.
        /// </summary>
        /// <returns>Una lista de objetos Usuario.</returns>
        public async Task<IEnumerable<Usuario>> GetAllAsync(int pageNumber, int pageSize)
        {
            // Paginación de resultados para mejor rendimiento
            return await _context.Usuarios
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a buscar.</param>
        /// <returns>El objeto Usuario si se encuentra, o null si no se encuentra.</returns>
        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo usuario a la base de datos.
        /// </summary>
        /// <param name="usuario">El objeto Usuario a agregar.</param>
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">El objeto Usuario con los nuevos valores.</param>
        public async Task UpdateAsync(Usuario usuario)
        {
            try
            {
                var usuarioExistente = await _context.Usuarios.FindAsync(usuario.Id);
                if (usuarioExistente != null)
                {
                    _context.Entry(usuarioExistente).CurrentValues.SetValues(usuario);
                    await _context.SaveChangesAsync();
                }
            }
            catch (DbUpdateException ex)
            {
                // Manejo de errores de actualización
                throw new Exception($"Error al actualizar el usuario con ID {usuario.Id} no se encontró en la base de datos", ex);
            }
        }

        /// <summary>
        /// Elimina un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException($"El usuario con Id {id} no se encontró en la base de datos.");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException($"Error al eliminar el usuario con Id {id}.", ex);
            }
        }

    }
}

