using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interfaz relacionada con operaciones CRUD de la entidad Categoria.  
    /// </summary>
    public interface ICategoriaRepository
    {
        /// <summary>
        /// Recupera una entidad Categoria por su identificador ID único.
        /// </summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene la entidad Categoria.</returns>
        Task<Categoria> GetByIdAsync(int id);

        /// <summary>
        /// Devuelve una lista de todas las entidades Categoria.
        /// </summary>
        /// <returns>Tarea asíncrona que contiene una lista de entidades Categoria.</returns>
        Task <IEnumerable<Categoria>> GetAllAsync(int PageNumber, int pageSize);

        /// <summary>
        /// Crea una nueva entidad Categoria en el repositorio.
        /// </summary>
        /// <param name="categoria">La entidad Categoria para agregar.</param>
        /// <returns>Tarea asíncrona que representa la operación de agregar una nueva entidad Categoria.</returns>
        Task AddAsync(Categoria categoria);

        /// <summary>
        /// Actualiza una entidad Categoria existente en el repositorio.
        /// </summary>
        /// <param name="categoria">La entidad Categoria para actualizar.</param>
        /// <returns>Tarea asíncrona de actualización de la entidad Categoria.</returns>
        Task UpdateAsync(Categoria categoria);

        /// <summary>
        /// Elimina una entidad Categoria por su identificador único.   
        /// </summary>
        /// <param name="id">Identificador único de la entidad a eliminar.</param>
        /// <returns>Tarea que representa una operación asíncrona de eliminación de una entidad Categoria.</returns>
        Task DeleteAsync(int id);
    }
}


