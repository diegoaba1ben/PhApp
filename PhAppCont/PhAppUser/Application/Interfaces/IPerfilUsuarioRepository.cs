using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Application.Interfaces
{
    public interface IPerfilUsuarioRepository
    {
        /// <summary>
        /// Método para obtener  todos los perfiles de usuario
        /// </summary>
        Task<IEnumerable<PerfilUsuario>> GetAllAsync();

        /// <summary>
        /// Método para obtener un perifl  de usuario por id
        /// </summary>
        Task<PerfilUsuario> GetByIdAsync(int id);

        /// <summary>
        /// Método para  crear un perfil de usuario
        /// </summary>
        Task AddAsync(PerfilUsuario perfilUsuario);

        /// <summary>
        /// Método para  actualizar un perfil de usuario existente
        /// </summary>
        Task UpdateAsync (PerfilUsuario perfilUsuario);

        /// <summary>
        /// Método para eliminar un perfil de usuario existente 
        /// </summary>
        Task DeleteAsync(int id);
    }
}