using System.ComponentModel.DataAnnotations;

namespace PhAppGateway.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "El usuario debe tener al menos 5 caracteres")]
        [MaxLength(25, ErrorMessage = "El usuarioi no puede tener más de 25 caracteres")]
        [RegularExpression(@"^[\p{L}\p{Nd}]+$", ErrorMessage = "El usuario solo puede contener letras y números.")]
        public string Usuario { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        [MaxLength(15, ErrorMessage = "La contraseña no puede tener más de 15 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$", 
            ErrorMessage = "La contraseña debe contener al menos una letra minúscula, una letra mayúscula, un número y un carácter especial.")]
        public string Password { get; set; }

        [Required]
        public string Estado { get; set; }

        // Constructor para inicializar las propiedades
        public UserModel()
        {
            Id = 0;
            Usuario = string.Empty;
            Password = string.Empty;
            Estado = string.Empty;
        }

        // Métodos
        public void Registrar()
        {
            // Lógica para registrar un usuario
        }

        public bool IniciarSesion()
        {
            // Lógica para iniciar sesión
            return true;
        }

        public void RecuperarPassw()
        {
            // Lógica para recordar contraseña
        }

        public void CambiarPassw()
        {
            // Lógica para cambiar contraseña
        }

        public bool reCAPTCHA()
        {
            // Lógica para verificar reCAPTCHA
            return true;
        }
    }
}
