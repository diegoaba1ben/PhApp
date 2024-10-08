using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad Pension. 
    /// </summary>
    public interface IPensionService
    {
        /// <summary>
        /// Recupera una entidad Pension por su identificador ID único.
        /// </summary>
        /// <param name="id">Recupera la entidad por su identificador ID único.</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene a la entidad Pension.</returns>
        Task<Pension> GetByIdAsync(int id);

        /// <summary>
        /// Devuelve una lista de las entidades Pension.
        /// </summary>
        Task<IEnumerable<Pension>> GetAllAsync();

        /// <summary>
        /// Crea una nueva entidad Pension en el repositorio.
        /// </summary>
        /// <param name="pension">La entidad Pension para agregar.</param>
        /// <returns>Una tarea asíncrona para la operación.</returns>
        Task AddAsync(Pension pension);

        /// <summary>
        /// Actualiza a una entidad Pension existente en el repositorio.
        /// </summary>
        /// <param name="pension">La entidad Pension para actualizar.</param>
        /// <returns>Una operación de actualización asincrónica.</returns>
        Task UpdateAsync(Pension pension);

        /// <summary>
        /// Elimina a una entidad Pension por su identificador único.   
        /// </summary>
        /// <param name="id">El Id de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una Pension.</returns>
        Task DeleteAsync(int id);
    }
}