using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad Permiso. 
    /// </summary>
    public interface IPermisoRepository
    {
        /// <summary>
        /// Recupera una entidad Permiso por su identificador ID único
        /// </summary>
        /// <param name="id">Recupera  la entidad por su identificador ID único</param>
        /// <returns>Tarea que representa una operación asíncrona que contiene a la entidad Permiso</returns>
        Task<Permiso> GetByIdAsync(int Id);

        /// <summary>
        /// Devuelve una lista de las entidades Permiso
        /// </summary>
        Task<IEnumerable<Permiso>> GetAllAsync(int pageNumber, int pageSize);

        /// <summary>
        /// Crea una nueva entidad Permiso en el repositorio
        /// </summary>
        /// <param name="permiso">La entidad permiso para agregar</param>
        /// <returns>Una tarea asíncrona para la operación </returns>
        Task AddAsync(Permiso permiso);

        /// <summary>
        /// Actualiza a un permiso existente en el repositorio
        /// </summary>
        /// <param name="permiso">La entidad permiso para actualizar</param>
        /// <returns>Una operación de actualización asincrónica</returns>
        Task UpdateAsync(Permiso permiso);

        /// <summary>
        /// Elimina a una entidad Permiso por su identificador único.   
        /// </summary>
        /// <param name="Id">El Id de la entidad a eliminar</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una entidad Permiso</returns>
        Task DeleteAsync(int id);
    }
}