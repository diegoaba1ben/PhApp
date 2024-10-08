using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad EntSalud que interactúa con la base de datos.
    /// </summary>
    public class EntSaludRepository : IEntSaludRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de EntSaludRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de las EntSalud existentes.</param>
        public EntSaludRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todas las EntSalud.
        /// </summary>
        /// <returns>Una lista de objetos EntSalud.</returns>
        public async Task<IEnumerable<EntSalud>> GetAllAsync()
        {
            return await _context.EntsSalud.ToListAsync(); // Cambiado para usar EntSalud
        }

        /// <summary>
        /// Obtiene una entSalud por su ID.
        /// </summary>
        /// <param name="id">El ID de la EntSalud a buscar.</param>
        /// <returns>El objeto EntSalud si se encuentra, o null si no se encuentra.</returns>
        public async Task<EntSalud> GetByIdAsync(int id)
        {
            return await _context.EntsSalud.FindAsync(id); // Cambiado para usar EntSalud
        }

        /// <summary>
        /// Agrega un nuevo objeto EntSalud a la base de datos.
        /// </summary>
        /// <param name="entSalud">El objeto EntSalud a agregar.</param>
        public async Task AddAsync(EntSalud entSalud)
        {
            await _context.EntsSalud.AddAsync(entSalud);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza una EntSalud existente en la base de datos.
        /// </summary>
        /// <param name="entSalud">El objeto EntSalud con los nuevos valores.</param>
        public async Task UpdateAsync(EntSalud entSalud)
        {
            var entSaludExistente = await _context.EntsSalud.FindAsync(entSalud.Id); // Usar entSalud.Id para buscar
            if (entSaludExistente != null)
            {
                _context.Entry(entSaludExistente).CurrentValues.SetValues(entSalud);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina una EntSalud por su ID.
        /// </summary>
        /// <param name="id">El ID de la EntSalud a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var entSalud = await _context.EntsSalud.FindAsync(id);
            if (entSalud != null)
            {
                _context.EntsSalud.Remove(entSalud);
                await _context.SaveChangesAsync();
            }
        }
    }
}
