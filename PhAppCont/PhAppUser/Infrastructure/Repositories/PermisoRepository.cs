using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Permiso que interactúa con la base de datos.
    /// </summary>
    public class PermisoRepository : IPermisoRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de PermisoRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de los permisos.</param>
        public PermisoRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los Permisos del sistema.
        /// </summary>
        /// <returns>Una lista de objetos Permiso.</returns>
        public async Task<IEnumerable<Permiso>> GetAllAsync(int pageNumber, int pageSize)
        {
            // Paginación de resultados para mejor rendimiento
            return await _context.Permisos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un permiso por su ID.
        /// </summary>
        /// <param name="id">El ID del permiso a buscar.</param>
        /// <returns>El objeto Permiso si se encuentra, o null si no se encuentra.</returns>
        public async Task<Permiso> GetByIdAsync(int id)
        {
            return await _context.Permisos.FindAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo permiso a la base de datos.
        /// </summary>
        /// <param name="permiso">El objeto Permiso a agregar.</param>
        public async Task AddAsync(Permiso permiso)
        {
            await _context.Permisos.AddAsync(permiso);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un permiso existente en la base de datos.
        /// </summary>
        /// <param name="permiso">El objeto Permiso con los nuevos valores.</param>
        public async Task UpdateAsync(Permiso permiso)
        {
            var permisoExistente = await _context.Permisos.FindAsync(permiso.Id);
            if (permisoExistente != null)
            {
                _context.Entry(permisoExistente).CurrentValues.SetValues(permiso);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina un permiso por su ID.
        /// </summary>
        /// <param name="id">El ID del permiso a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso != null)
            {
                _context.Permisos.Remove(permiso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
