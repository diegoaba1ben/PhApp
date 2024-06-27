using Microsoft.AspNetCore.Mvc;
using PhAppGateway.Models;

namespace PhAppGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Método para registrar un usuario
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserModel user)
        {
            // Aquí iría la lógica para registrar el usuario, por ahora es solo un ejemplo
            user.Registrar();
            return Ok("User registered successfully");
        }

        // Método para iniciar sesión
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            // Aquí iría la lógica para iniciar sesión, por ahora es solo un ejemplo
            bool success = user.IniciarSesion();
            if (success)
            {
                return Ok("Login successful");
            }
            return Unauthorized("Invalid credentials");
        }

        // Método para recordar contraseña
        [HttpPost("remember-password")]
        public IActionResult RememberPassword([FromBody] UserModel user)
        {
            // Aquí iría la lógica para recordar contraseña, por ahora es solo un ejemplo
            user.RecuperarPassw();
            return Ok("Password reminder sent");
        }

        // Método para cambiar contraseña
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] UserModel user)
        {
            // Aquí iría la lógica para cambiar contraseña, por ahora es solo un ejemplo
            user.CambiarPassw();
            return Ok("Password changed successfully");
        }

        // Método para verificar reCAPTCHA
        [HttpPost("recaptcha")]
        public IActionResult VerifyReCAPTCHA([FromBody] UserModel user)
        {
            // Aquí iría la lógica para verificar reCAPTCHA, por ahora es solo un ejemplo
            bool success = user.reCAPTCHA();
            if (success)
            {
                return Ok("reCAPTCHA verified successfully");
            }
            return BadRequest("reCAPTCHA verification failed");
        }
    }
}
