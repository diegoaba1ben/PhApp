using System.Collections.Generic;
using System.Threading.Tasks;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Application.Interfaces
{
    ///  <summary>
    ///  Interface relacionada con operaciones CRUD de la entidad Cargo.
    /// </summary>
    public interface ICargoRepository
    {
        /// <summary>
        /// Recupera una entidad Cargo por su identificador ID único
        /// </summary>
        /// <param name="id">Identificador único de la entidad</param>
        /// <returns> Tarea que representa una operación asíncrona que contiene un cargo dentro de una agrupación</returns>
        Task <Cargo> GetByIdAsync(int id);

        ///  <summary>
        ///  Devuelve toda la lista de cargos 
        ///  </summary>
        ///  <returns>Una tarea asíncrona que contiene  una lista de cargos</returns>
        Task<IEnumerable<Cargo>> GetAllAsync(int pageNumber = 1, int pageSize = 10);

        ///  <summary>
        ///  Crea una nueva entidad  Cargo en el repositorio
        ///  </summary>
        ///  <param name="cargo">La entidad cargo para agregar</param>
        ///  <returns> Tarea que representa una operación asíncrona que contiene un cargo dentro</returns>
        Task AddAsync(Cargo cargo);

        /// <summary>
        /// Actualiza una entidad Cargo  existente en el repositorio
        /// </summary>
        /// <param name="cargo">el cargo para actualizar</param>
        /// <returns>Una operación asíncrona de actualización de una entidad cargo</returns>
        Task UpdateAsync(Cargo cargo);

        ///  <summary>
        ///  Elimina a una entidad Cargo por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único de la entidad</param>
        /// <returns>Una tarea que representa una operación asíncrona de eliminación de una entidad Cargo </returns>
        Task DeleteAsync(int id);      
    } 
}