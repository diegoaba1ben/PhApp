using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad EntSalud.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EntSaludController : ControllerBase
    {
        private readonly IEntSaludRepository _entSaludRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de EntSalud a través de inyección de dependencias.
        /// </summary>
        /// <param name="entSaludRepository">El repositorio de EntSalud.</param>
        public EntSaludController(IEntSaludRepository entSaludRepository)
        {
            _entSaludRepository = entSaludRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de entidades de salud.
        /// </summary>
        /// <returns>Una lista de objetos EntSalud.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntSalud>>> GetEntidadesSalud()
        {
            var entidadesSalud = await _entSaludRepository.GetAllAsync();
            return Ok(entidadesSalud);
        }

        /// <summary>
        /// Obtiene una entidad de salud específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad de salud a obtener.</param>
        /// <returns>El objeto EntSalud si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EntSalud>> GetEntSalud(int id)
        {
            var entSalud = await _entSaludRepository.GetByIdAsync(id);
            if (entSalud == null)
            {
                return NotFound();
            }
            return Ok(entSalud);
        }

        /// <summary>
        /// Crea una nueva entidad de salud.
        /// </summary>
        /// <param name="entSalud">El objeto EntSalud a crear.</param>
        /// <returns>El objeto EntSalud creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<EntSalud>> CreateEntSalud(EntSalud entSalud)
        {
            await _entSaludRepository.AddAsync(entSalud);
            return CreatedAtAction(nameof(GetEntSalud), new { id = entSalud.Id }, entSalud);
        }

        /// <summary>
        /// Actualiza una entidad de salud existente.
        /// </summary>
        /// <param name="id">El ID de la entidad de salud a actualizar.</param>
        /// <param name="entSalud">El objeto EntSalud con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntSalud(int id, EntSalud entSalud)
        {
            if (id != entSalud.Id)
            {
                return BadRequest();
            }
            await _entSaludRepository.UpdateAsync(entSalud);
            return NoContent();
        }

        /// <summary>
        /// Elimina una entidad de salud específica por su ID.
        /// </summary>
        /// <param name="id">El ID de la entidad de salud a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntSalud(int id)
        {
            var entSalud = await _entSaludRepository.GetByIdAsync(id);
            if (entSalud == null)
            {
                return NotFound();
            }
            await _entSaludRepository.DeleteAsync(entSalud);
            return NoContent();
        }
    }
}
