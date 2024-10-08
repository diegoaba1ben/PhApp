using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad RepLegal que interactúa con la base de datos.
    /// </summary>
    public class RepLegalRepository : IRepLegalRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de RepLegalRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de representación legal.</param>
        public RepLegalRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todas las representaciones legales, con paginación opcional.
        /// </summary>
        /// <param name="pageNumber">Número de página para la paginación.</param>
        /// <param name="pageSize">Tamaño de la página para la paginación.</param>
        /// <returns>Una lista de objetos RepLegal.</returns>
        public async Task<IEnumerable<RepLegal>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Paginación de resultados para mejor rendimiento
            return await _context.RepLegales
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un documento de representación legal por su ID.
        /// </summary>
        /// <param name="id">El ID del repLegal a buscar.</param>
        /// <returns>El objeto RepLegal si se encuentra, o null si no se encuentra.</returns>
        public async Task<RepLegal> GetByIdAsync(int id)
        {
            return await _context.RepLegales.FindAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo documento de representación legal a la base de datos.
        /// </summary>
        /// <param name="repLegal">El objeto RepLegal a agregar.</param>
        public async Task AddAsync(RepLegal repLegal)
        {
            await _context.RepLegales.AddAsync(repLegal); 
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un documento de representación legal existente en la base de datos.
        /// </summary>
        /// <param name="repLegal">El objeto RepLegal con los nuevos valores.</param>
        public async Task UpdateAsync(RepLegal repLegal)
        {
            var repLegalExistente = await _context.RepLegales.FindAsync(repLegal.Id);
            if (repLegalExistente != null)
            {
                _context.Entry(repLegalExistente).CurrentValues.SetValues(repLegal);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina un documento de representación legal por su ID.
        /// </summary>
        /// <param name="id">El ID del repLegal a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var repLegal = await _context.RepLegales.FindAsync(id);
            if (repLegal != null)
            {
                _context.RepLegales.Remove(repLegal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
