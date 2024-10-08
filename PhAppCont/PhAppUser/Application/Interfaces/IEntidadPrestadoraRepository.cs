using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad EntidadPrestadora. 
    /// </summary>
    public interface IEntidadPrestadoraRepository
    {
        /// <summary>
        /// Recupera una entidad EntidadPrestadora por su identificador ID único.
        /// </summary>
        /// <param name="id">Recupera la entidad por su identificador ID único.</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene a la EntidadPrestadora.</returns>
        Task<EntidadPrestadora> GetByIdAsync(int id);

        /// <summary>
        /// Devuelve una lista de las entidades EntidadPrestadora.
        /// </summary>
        Task<IEnumerable<EntidadPrestadora>> GetAllAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Crea una nueva entidad EntidadPrestadora en el repositorio.
        /// </summary>
        /// <param name="entidadPrestadora">La entidad EntidadPrestadora para agregar.</param>
        /// <returns>Una tarea asíncrona para la operación.</returns>
        Task AddAsync(EntidadPrestadora entidadPrestadora);

        /// <summary>
        /// Actualiza a una entidad EntidadPrestadora existente en el repositorio.
        /// </summary>
        /// <param name="entidadPrestadora">La entidad EntidadPrestadora para actualizar.</param>
        /// <returns>Una operación de actualización asincrónica.</returns>
        Task UpdateAsync(EntidadPrestadora entidadPrestadora); // Actualización completa

        /// <summary>
        /// Actualiza parcialmente a una entidad EntidadPrestadora en el repositorio.
        /// </summary>
        /// <param name="entidadPrestadora">La entidad EntidadPrestadora para actualizar parcialmente.</param>
        /// <returns>Una operación de actualización parcial asincrónica.</returns>
        Task UpdatePartialAsync(EntidadPrestadora entidadPrestadora); // Actualización parcial

        /// <summary>
        /// Elimina a una entidad EntidadPrestadora por su identificador único.   
        /// </summary>
        /// <param name="id">El ID de la entidad a eliminar.</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una entidad EntidadPrestadora.</returns>
        Task DeleteAsync(int id);
    }
}

