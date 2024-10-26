using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Contador.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ContadorController : ControllerBase
    {
        private readonly IContadorRepository _contadorRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de contadores a través de inyección de dependencias.
        /// </summary>
        /// <param name="contadorRepository">El repositorio de contadores.</param>
        public ContadorController(IContadorRepository contadorRepository)
        {
            _contadorRepository = contadorRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de contadores.
        /// </summary>
        /// <returns>Una lista de objetos Contador.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contador>>> GetContadores()
        {
            var contadores = await _contadorRepository.GetAllAsync();
            return Ok(contadores);
        }

        /// <summary>
        /// Obtiene un contador específico por su ID.
        /// </summary>
        /// <param name="id">El ID del contador a obtener.</param>
        /// <returns>El objeto Contador si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Contador>> GetContador(int id)
        {
            var contador = await _contadorRepository.GetByIdAsync(id);
            if (contador == null)
            {
                return NotFound();
            }
            return Ok(contador);
        }

        /// <summary>
        /// Crea un nuevo contador.
        /// </summary>
        /// <param name="contador">El objeto Contador a crear.</param>
        /// <returns>El objeto Contador creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<Contador>> CreateContador(Contador contador)
        {
            await _contadorRepository.AddAsync(contador);
            return CreatedAtAction(nameof(GetContador), new { id = contador.Id }, contador);
        }

        /// <summary>
        /// Actualiza un contador existente.
        /// </summary>
        /// <param name="id">El ID del contador a actualizar.</param>
        /// <param name="contador">El objeto Contador con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContador(int id, Contador contador)
        {
            if (id != contador.Id)
            {
                return BadRequest();
            }
            await _contadorRepository.UpdateAsync(contador);
            return NoContent();
        }

        /// <summary>
        /// Elimina un contador específico por su ID.
        /// </summary>
        /// <param name="id">El ID del contador a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContador(int id)
        {
            var contador = await _contadorRepository.GetByIdAsync(id);
            if (contador == null)
            {
                return NotFound();
            }
            await _contadorRepository.DeleteAsync(contador);
            return NoContent();
        }
    }
}
