using system;
using System.DataAnnotations;

namespace PhAppUser.Domain.Entities;
{
    public class RepLegal
    {
        /// <summary>
        /// Representa la entidad para la validación de la certificación legal del usuario
        /// </summary>
        
        public class ValidRepLegal
        {
            /// <summary>
            /// Obtiene o establece el identificador único de la validación
            /// </summary>
            [Key]
            public int Id { get; set; }

            /// <summary>
            /// Obtiene o establece la fecha en que se establece la fecha en la que se emitió la certificación legal
            /// </summary>
            [Required]
            public DateTime FechaEmision { get; set; }

            /// <summary>
            /// Obtiene la fecha de exporación de la certificación  legal (365 días después de la fecha de certificación)
            /// Calcula años bisisestos
            /// </summary>
            public DateTime FechaExpiracion
            {
                get 
                {
                    return FechaCert.AddDays(IsLeapYear(FechaEmision.Year)? 366:365);
                }
            }

            /// <summary>
            /// Obtiene o establece el estado del usuario (true Si las credenciales están activas).
            /// </summary>
            public bool EstadoUsuario { get; set;}

            /// <summary>
            /// Indica si el usuario es nuevo  o si es una renovación de la certificación.
            /// Si esnuevo, se abrirá una interfaz de usuario completa, si es una renovación se permitirán actualizaciones
            /// </summary>
            public bool EsNvoUsuario { get; set;}

            /// <summary>
            /// Calcula si la fecha de expiración está dentro de los 30 dían anteriores a la certificación
            /// </summary>
            public bool Aviso30Dias
            {
                get
                {
                    return(FechExp - DateTime.Now).TotalDays <= 30;
                }
            }

            /// <summary>
            /// Calcula si la fecha está dentro de los 15 días antes de la expiración
            /// </summary>
            public bool Aviso15Dias
            {
                get
                {
                    return(FechaExp - DateTime.Now).TotalDays <= 15;
                }
            }

            /// <summary>
            /// Calcula si la fecha está dentro de los 8 días antes de la expiración
            /// </summary>
            public bool Aviso8Dias
            {
                get{
                    return(FechaExp - DateTime.Now).TotalDays <= 8;
                }
            }

        }
    }
} 