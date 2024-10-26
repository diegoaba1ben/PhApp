using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Perfil.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de perfiles a través de inyección de dependencias.
        /// </summary>
        /// <param name="perfilRepository">El repositorio de perfiles.</param>
        public PerfilController(IPerfilRepository perfilRepository)
        {
            _perfilRepository = perfilRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de perfiles.
        /// </summary>
        /// <returns>Una lista de objetos Perfil.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> GetPerfiles()
        {
            var perfiles = await _perfilRepository.GetAllAsync();
            return Ok(perfiles);
        }

        /// <summary>
        /// Obtiene un perfil específico por su ID.
        /// </summary>
        /// <param name="id">El ID del perfil a obtener.</param>
        /// <returns>El objeto Perfil si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Perfil>> GetPerfil(int id)
        {
            var perfil = await _perfilRepository.GetByIdAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            return Ok(perfil);
        }

        /// <summary>
        /// Crea un nuevo perfil.
        /// </summary>
        /// <param name="perfil">El objeto Perfil a crear.</param>
        /// <returns>El objeto Perfil creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<Perfil>> CreatePerfil(Perfil perfil)
        {
            await _perfilRepository.AddAsync(perfil);
            return CreatedAtAction(nameof(GetPerfil), new { id = perfil.Id }, perfil);
        }

        /// <summary>
        /// Actualiza un perfil existente.
        /// </summary>
        /// <param name="id">El ID del perfil a actualizar.</param>
        /// <param name="perfil">El objeto Perfil con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerfil(int id, Perfil perfil)
        {
            if (id != perfil.Id)
            {
                return BadRequest();
            }
            await _perfilRepository.UpdateAsync(perfil);
            return NoContent();
        }

        /// <summary>
        /// Elimina un perfil específico por su ID.
        /// </summary>
        /// <param name="id">El ID del perfil a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil(int id)
        {
            var perfil = await _perfilRepository.GetByIdAsync(id);
            if (perfil == null)
            {
                return NotFound();
            }
            await _perfilRepository.DeleteAsync(perfil);
            return NoContent();
        }
    }
}
