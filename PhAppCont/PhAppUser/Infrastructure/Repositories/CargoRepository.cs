using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Cargo que interactúa con la base de datos.
    /// </summary>
    public class CargoRepository : ICargoRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de CargoRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de los cargos existentes.</param>
        public CargoRepository(PhAppUserDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de todos los cargos, con paginación opcional.
        /// </summary>
        /// <param name="pageNumber">Número de página para la paginación.</param>
        /// <param name="pageSize">Tamaño de la página para la paginación.</param>
        /// <returns>Una lista de objetos Cargo.</returns>
        public async Task<IEnumerable<Cargo>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
        {
            // Paginación de resultados para mejor rendimiento
            return await _context.Cargos
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene un Cargo por su ID.
        /// </summary>
        /// <param name="id">El ID del cargo a buscar.</param>
        /// <returns>El objeto Cargo si se encuentra, o null si no se encuentra.</returns>
        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _context.Cargos.FindAsync(id);
        }

        /// <summary>
        /// Agrega un nuevo cargo a la base de datos.
        /// </summary>
        /// <param name="cargo">El objeto Cargo a agregar.</param>
        public async Task AddAsync(Cargo cargo)
        {
            await _context.Cargos.AddAsync(cargo); 
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza un cargo existente en la base de datos.
        /// </summary>
        /// <param name="cargo">El objeto Cargo con los nuevos valores.</param>
        public async Task UpdateAsync(Cargo cargo)
        {
           var  cargoExistente = await _context.Cargos.FindAsync(cargo.Id);
           if(cargoExistente != null)
           {
            _context.Entry(cargoExistente).CurrentValues.SetValues(cargo);
                await _context.SaveChangesAsync();
           }
        }

        /// <summary>
        /// Elimina un cargo por su ID.
        /// </summary>
        /// <param name="id">El ID del cargo a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo != null)
            {
                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
