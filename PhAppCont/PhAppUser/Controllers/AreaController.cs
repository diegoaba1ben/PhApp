using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Area.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _areaRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de áreas a través de inyección de dependencias.
        /// </summary>
        /// <param name="areaRepository">El repositorio de áreas.</param>
        public AreaController(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de áreas.
        /// </summary>
        /// <returns>Una lista de objetos Area.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> GetAreas()
        {
            var areas = await _areaRepository.GetAllAsync();
            return Ok(areas);
        }

        /// <summary>
        /// Obtiene un área específica por su ID.
        /// </summary>
        /// <param name="id">El ID del área a obtener.</param>
        /// <returns>El objeto Area si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> GetArea(int id)
        {
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        /// <summary>
        /// Crea una nueva área.
        /// </summary>
        /// <param name="area">El objeto Area a crear.</param>
        /// <returns>El objeto Area creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<Area>> CreateArea(Area area)
        {
            await _areaRepository.AddAsync(area);
            return CreatedAtAction(nameof(GetArea), new { id = area.Id }, area);
        }

        /// <summary>
        /// Actualiza una área existente.
        /// </summary>
        /// <param name="id">El ID del área a actualizar.</param>
        /// <param name="area">El objeto Area con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArea(int id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }
            await _areaRepository.UpdateAsync(area);
            return NoContent();
        }

        /// <summary>
        /// Elimina un área específica por su ID.
        /// </summary>
        /// <param name="id">El ID del área a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            var area = await _areaRepository.GetByIdAsync(id);
            if (area == null)
            {
                return NotFound();
            }
            await _areaRepository.DeleteAsync(area);
            return NoContent();
        }
    }
}
