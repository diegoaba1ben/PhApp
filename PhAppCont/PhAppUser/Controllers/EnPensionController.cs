using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad EntPension.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EntPensionController : ControllerBase
    {
        private readonly IEntPensionRepository _entPensionRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de EntPension a través de inyección de dependencias.
        /// </summary>
        /// <param name="entPensionRepository">El repositorio de EntPension.</param>
        public EntPensionController(IEntPensionRepository entPensionRepository)
        {
            _entPensionRepository = entPensionRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de entidades de pensión.
        /// </summary>
        /// <returns>Una lista de objetos EntPension.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntPension>>> GetEntidadesPension()
        {
            var entidadesPension = await _entPensionRepository.GetAllAsync();
            return Ok(entidadesPension);
        }

        /// <summary>
        /// Obtiene una entidad de pensión específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad de pensión a obtener.</param>
        /// <returns>El objeto EntPension si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EntPension>> GetEntPension(int id)
        {
            var entPension = await _entPensionRepository.GetByIdAsync(id);
            if (entPension == null)
            {
                return NotFound();
            }
            return Ok(entPension);
        }

        /// <summary>
        /// Crea una nueva entidad de pensión.
        /// </summary>
        /// <param name="entPension">El objeto EntPension a crear.</param>
        /// <returns>El objeto EntPension creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<EntPension>> CreateEntPension(EntPension entPension)
        {
            await _entPensionRepository.AddAsync(entPension);
            return CreatedAtAction(nameof(GetEntPension), new { id = entPension.Id }, entPension);
        }

        /// <summary>
        /// Actualiza una entidad de pensión existente.
        /// </summary>
        /// <param name="id">El ID de la entidad de pensión a actualizar.</param>
        /// <param name="entPension">El objeto EntPension con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntPension(int id, EntPension entPension)
        {
            if (id != entPension.Id)
            {
                return BadRequest();
            }
            await _entPensionRepository.UpdateAsync(entPension);
            return NoContent();
        }

        /// <summary>
        /// Elimina una entidad de pensión específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad de pensión a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntPension(int id)
        {
            var entPension = await _entPensionRepository.GetByIdAsync(id);
            if (entPension == null)
            {
                return NotFound();
            }
            await _entPensionRepository.DeleteAsync(entPension);
            return NoContent();
        }
    }
}
