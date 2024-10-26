using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Cargo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepository _cargoRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de cargos a través de inyección de dependencias.
        /// </summary>
        /// <param name="cargoRepository">El repositorio de cargos.</param>
        public CargoController(ICargoRepository cargoRepository)
        {
            _cargoRepository = cargoRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de cargos.
        /// </summary>
        /// <returns>Una lista de objetos Cargo.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargo>>> GetCargos()
        {
            var cargos = await _cargoRepository.GetAllAsync();
            return Ok(cargos);
        }

        /// <summary>
        /// Obtiene un cargo específico por su ID.
        /// </summary>
        /// <param name="id">El ID del cargo a obtener.</param>
        /// <returns>El objeto Cargo si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> GetCargo(int id)
        {
            var cargo = await _cargoRepository.GetByIdAsync(id);
            if (cargo == null)
            {
                return NotFound();
            }
            return Ok(cargo);
        }

        /// <summary>
        /// Crea un nuevo cargo.
        /// </summary>
        /// <param name="cargo">El objeto Cargo a crear.</param>
        /// <returns>El objeto Cargo creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task
