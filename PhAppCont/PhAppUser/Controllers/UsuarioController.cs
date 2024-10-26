using Microsoft.AspNetCore.Mvc;
using PhAppUser.Application.Interfaces;
using PhAppUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhAppUser.Controllers
{
    /// <summary>
    /// Controlador para manejar operaciones CRUD para la entidad Usuario.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor que recibe el repositorio de usuarios a través de inyección de dependencias.
        /// </summary>
        /// <param name="usuarioRepository">El repositorio de usuarios.</param>
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Obtiene la lista completa de usuarios.
        /// </summary>
        /// <returns>Una lista de objetos Usuario.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return Ok(usuarios);
        }

        /// <summary>
        /// Obtiene un usuario específico por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a obtener.</param>
        /// <returns>El objeto Usuario si se encuentra; de lo contrario, NotFound.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="usuario">El objeto Usuario a crear.</param>
        /// <returns>El objeto Usuario creado, junto con la ruta de acceso.</returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Actualiza un usuario existente.
        /// </summary>
        /// <param name="id">El ID del usuario a actualizar.</param>
        /// <param name="usuario">El objeto Usuario con los datos actualizados.</param>
        /// <returns>NoContent si la actualización es exitosa; de lo contrario, BadRequest.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            await _usuarioRepository.UpdateAsync(usuario);
            return NoContent();
        }

        /// <summary>
        /// Elimina un usuario específico por su ID.
        /// </summary>
        /// <param name="id">El ID del usuario a eliminar.</param>
        /// <returns>NoContent si la eliminación es exitosa; de lo contrario, NotFound.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            await _usuarioRepository.DeleteAsync(usuario);
            return NoContent();
        }
    }
}
