using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    /// <summary>
    /// Interface relacionada con operaciones CRUD de la entidad RepLegal. 
    /// </summary>
    public interface IRepLegalRepository
    {
        /// <summary>
    /// Recupera una entidad RepLegal por su identificador ID único
    /// </summary>
    /// <param name="Id">El Id  de la Representación Legal a recuperar</param>
    /// <returns>Tarea que representa una operación asíncrona que contiene a la entidad RepLegal</returns>
    Task<RepLegal> GetByIdAsync(int id);

    /// <summary>
    /// Devuelve toda la  lista de entidades RepLegal
    /// </summary>
    Task<IEnumerable<RepLegal>> GetAllAsync(int pageNumber = 1, int pageSize = 10);

    /// <summary>
    /// Crea una nueva entidad RepLegal en el repositorio
    /// </summary>
    /// <param name="repLegal">La entidad repLegal para agregar</param>
    /// <returns>Una tarea asíncrona para la operación </returns>
    Task AddAsync(RepLegal repLegal);

    /// <summary>
    /// Actualiza a un documento de representación legal existente en el repositorio
    /// </summary>
    /// <param name="RepLegal">La entidad RepLegal para actualizar</param>
    /// <returns>Una operación de actualización asincrónica</returns>
    Task UpdateAsync(RepLegal repLegal);

    /// <summary>
    /// Elimina a una entidad RepLegal por su identificador único.   
    /// </summary>
    /// <param name="Id">El Id de la entidad a eliminar</param>
    /// <returns>Una tarea que represdenta una operación asíncrona de eliminación de una entidad RepLegal</returns>
    Task DeleteAsync(int id);
    }
}