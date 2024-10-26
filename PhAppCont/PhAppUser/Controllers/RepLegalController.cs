using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad RepLegal.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RepLegalController : ControllerBase
    {
        private readonly IRepLegalRepository _repLegalRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de representantes legales a través de inyección de dependencias.
        /// </summary>
        /// <param name="repLegalRepository">El repositorio de representantes legales.</param>
        public RepLegalController(IRepLegalRepository repLegalRepository)
        {
            _repLegalRepository = repLegalRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de representantes legales.
        /// </summary>
        /// <returns>Una lista de objetos RepLegal.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepLegal>>> GetRepLegales()
        {
            var repLegales = await _repLegalRepository.GetAllAsync();
            return Ok(repLegales);
        }

        /// <summary>
        /// Obtiene un representante legal específico por su ID.
        /// </summary>
        /// <param name="id">El ID del representante legal a obtener.</param>
        /// <returns>El objeto RepLegal si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<RepLegal>> GetRepLegal(int id)
        {
            var repLegal = await _repLegalRepository.GetByIdAsync(id);
            if (repLegal == null)
            {
                return NotFound();
            }
            return Ok(repLegal);
        }

        /// <summary>
        /// Crea un nuevo representante legal.
        /// </summary>
        /// <param name="repLegal">El objeto RepLegal a crear.</param>
        /// <returns>El objeto RepLegal creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<RepLegal>> CreateRepLegal(RepLegal repLegal)
        {
            await _repLegalRepository.AddAsync(repLegal);
            return CreatedAtAction(nameof(GetRepLegal), new { id = repLegal.Id }, repLegal);
        }

        /// <summary>
        /// Actualiza un representante legal existente.
        /// </summary>
        /// <param name="id">El ID del representante legal a actualizar.</param>
        /// <param name="repLegal">El objeto RepLegal con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRepLegal(int id, RepLegal repLegal)
        {
            if (id != repLegal.Id)
            {
                return BadRequest();
            }
            await _repLegalRepository.UpdateAsync(repLegal);
            return NoContent();
        }

        /// <summary>
        /// Elimina un representante legal específico por su ID.
        /// </summary>
        /// <param name="id">El ID del representante legal a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepLegal(int id)
        {
            var repLegal = await _repLegalRepository.GetByIdAsync(id);
            if (repLegal == null)
            {
                return NotFound();
            }
            await _repLegalRepository.DeleteAsync(repLegal);
            return NoContent();
        }
    }
}
