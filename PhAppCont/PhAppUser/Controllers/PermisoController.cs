using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Permiso.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoRepository _permisoRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de permisos a través de inyección de dependencias.
        /// </summary>
        /// <param name="permisoRepository">El repositorio de permisos.</param>
        public PermisoController(IPermisoRepository permisoRepository)
        {
            _permisoRepository = permisoRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de permisos.
        /// </summary>
        /// <returns>Una lista de objetos Permiso.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermisos()
        {
            var permisos = await _permisoRepository.GetAllAsync();
            return Ok(permisos);
        }

        /// <summary>
        /// Obtiene un permiso específico por su ID.
        /// </summary>
        /// <param name="id">El ID del permiso a obtener.</param>
        /// <returns>El objeto Permiso si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Permiso>> GetPermiso(int id)
        {
            var permiso = await _permisoRepository.GetByIdAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            return Ok(permiso);
        }

        /// <summary>
        /// Crea un nuevo permiso.
        /// </summary>
        /// <param name="permiso">El objeto Permiso a crear.</param>
        /// <returns>El objeto Permiso creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<Permiso>> CreatePermiso(Permiso permiso)
        {
            await _permisoRepository.AddAsync(permiso);
            return CreatedAtAction(nameof(GetPermiso), new { id = permiso.Id }, permiso);
        }

        /// <summary>
        /// Actualiza un permiso existente.
        /// </summary>
        /// <param name="id">El ID del permiso a actualizar.</param>
        /// <param name="permiso">El objeto Permiso con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePermiso(int id, Permiso permiso)
        {
            if (id != permiso.Id)
            {
                return BadRequest();
            }
            await _permisoRepository.UpdateAsync(permiso);
            return NoContent();
        }

        /// <summary>
        /// Elimina un permiso específico por su ID.
        /// </summary>
        /// <param name="id">El ID del permiso a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            var permiso = await _permisoRepository.GetByIdAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            await _permisoRepository.DeleteAsync(permiso);
            return NoContent();
        }
    }
}
