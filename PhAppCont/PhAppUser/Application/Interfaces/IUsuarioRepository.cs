using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad Usuario.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Recupera una entidad Usuario por su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a recuperar.</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene la entidad Usuario.</returns>
        Task<Usuario> GetByIdAsync(int id);

        /// <summary>
        /// Devuelve toda la lista de entidades Usuario.
        /// </summary>
        /// <param name="pageNumber">Número de página para la paginación.</param>
        /// <param name="pageSize">Tamaño de la página para la paginación.</param>
        /// <returns>Una tarea que representa una operación asíncrona que contiene una lista de entidades Usuario.</returns>
        Task<IEnumerable<Usuario>> GetAllAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Crea una nueva entidad Usuario en el repositorio.
        /// </summary>
        /// <param name="usuario">La entidad Usuario para agregar.</param>
        /// <returns>Una tarea asíncrona para la operación.</returns>
        Task AddAsync(Usuario usuario);

        /// <summary>
        /// Actualiza a un usuario existente en el repositorio.
        /// </summary>
        /// <param name="usuario">La entidad Usuario para actualizar.</param>
        /// <returns>Una tarea asíncrona para la operación de actualización.</returns>
        Task UpdateAsync(Usuario usuario);

        /// <summary>
        /// Elimina a una entidad Usuario por su identificador único.
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una entidad Usuario.</returns>
        Task DeleteAsync(int id);
    }
}
