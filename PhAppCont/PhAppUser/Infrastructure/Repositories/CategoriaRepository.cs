using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using PhAppUser.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para la entidad Categoria que interactúa con la base de datos.
    /// </summary>
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly PhAppUserDbContext _context;

        /// <summary>
        /// Constructor de CategoriaRepository.
        /// </summary>
        /// <param name="context">El contexto de la base de datos para interactuar con los datos de las categorías.</param>
        public CategoriaRepository(PhAppUserDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene un usuario por su ID.
        /// </summary>
        /// <param name="id">El ID de la categoría a buscar.</param>
        /// <returns>El objeto Categoria si se encuentra, o null si no se encuentra.</returns>
        public async Task<Categoria> GetByIdAsync(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        /// <summary>
        /// Obtiene una lista de todos las categorias en el sistema.
        /// </summary>
        /// <returns>Una lista de objetos Categoria.</returns>
        public async Task<IEnumerable<Categoria>> GetAllAsync(int pageNumber, int pageSize)
        {
            // Paginación de resultados para mejor rendimiento
            return await _context.Categorias
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }


        /// <summary>
        /// Agrega una nueva categoria a la base de datos.
        /// </summary>
        /// <param name="categoria">El objeto Categoria a agregar.</param>
        public async Task AddAsync(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Actualiza una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">El objeto Categoria con los nuevos valores.</param>
        public async Task UpdateAsync(Categoria categoria)
        {
            var categoriaExistente = await _context.Categorias.FindAsync(categoria.Id);
            if (categoriaExistente != null)
            {
                _context.Entry(categoriaExistente).CurrentValues.SetValues(categoria);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Elimina un permiso por su ID.
        /// </summary>
        /// <param name="id">El ID de la categoría a eliminar.</param>
        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}