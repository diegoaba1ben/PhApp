using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad EntSalud. 
    /// </summary>
    public interface IEntSaludRepository
    {
        /// <summary>
        /// Recupera una entidad EntSalud por su identificador ID único.
        /// </summary>
        /// <param name="id">Recupera la entidad por su identificador ID único.</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene a la entidad EntSalud.</returns>
        Task<EntSalud> GetByIdAsync(int id); // Cambiado de Permiso a EntSalud

        /// <summary>
        /// Devuelve una lista de las entidades EntSalud.
        /// </summary>
        Task<IEnumerable<EntSalud>> GetAllAsync();

        /// <summary>
        /// Crea una nueva entidad EntSalud en el repositorio.
        /// </summary>
        /// <param name="entSalud">La entidad EntSalud para agregar.</param>
        /// <returns>Una tarea asíncrona para la operación.</returns>
        Task AddAsync(EntSalud entSalud);

        /// <summary>
        /// Actualiza a una entidad EntSalud existente en el repositorio.
        /// </summary>
        /// <param name="entSalud">La entidad EntSalud para actualizar.</param>
        /// <returns>Una operación de actualización asincrónica.</returns>
        Task UpdateAsync(EntSalud entSalud);

        /// <summary>
        /// Elimina a una entidad EntSalud por su identificador único.   
        /// </summary>
        /// <param name="id">El Id de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una entidad EntSalud.</returns>
        Task DeleteAsync(int id);
    }
}

