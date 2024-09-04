using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa el documento de representación legal asociado a un usuario.
    /// </summary>
    public class RepLegal
    {
        /// <summary>
        /// Identificador único del representante legal.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Fecha de expedición del documento de representación legal.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(RepLegal), nameof(ValidarFechaExpedicion))]
        public DateTime FechaExpedicion { get; set; }

        public static ValidationResult ValidarFechaExpedicion(DateTime fechaExpedicion, ValidationContext context)
        {
            if (fechaExpedicion > DateTime.Now)
            {
                return new ValidationResult("La fecha de expedición no puede ser posterior a la fecha actual");
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// Entidad emisora del documento.
        /// </summary>
        [Required]
        [StringLength(50)]  // Longitud máxima de 50 caracteres para asegurar la consistencia
        public string AlcaldiaEmisora { get; set; }

        /// <summary>
        /// Relación con la entidad Cargo que indica el rol asociado a este documento.
        /// </summary>
        [Required]
        public int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public Cargo Cargo { get; set; }

        /// <summary>
        /// Indica si el usuario está activo como representante legal.
        /// </summary>
        public bool EsRepresentanteLegal { get; set; }

        /// <summary>
        /// Constructor vacío necesario para Entity Framework.
        /// </summary>
        public RepLegal() {}

        /// <summary>
        /// Constructor para inicializar un representante legal con los valores especificados.
        /// </summary>
        public RepLegal(DateTime fechaExpedicion, string alcaldiaEmisora, bool esRepresentanteLegal, int cargoId)
        {
            FechaExpedicion = fechaExpedicion;
            AlcaldiaEmisora = alcaldiaEmisora;
            EsRepresentanteLegal = esRepresentanteLegal;
            CargoId = cargoId;
        }

        /// <summary>
        /// Calcula la fecha de vencimiento basada en la fecha de expedición (1 año calendario por defecto).
        /// </summary>
        public DateTime ObtenerFechaVencimiento()
        {
            return FechaExpedicion.AddYears(1);
        }

        /// <summary>
        /// Calcula los días restantes hasta el vencimiento del documento.
        /// </summary>
        public int CalcularDiasRestantes()
        {
            return (ObtenerFechaVencimiento() - DateTime.Now).Days;
        }

        /// <summary>
        /// Verifica si el documento ya está vencido.
        /// </summary>
        public bool EsDocumentoVencido()
        {
            return DateTime.Now > ObtenerFechaVencimiento();
        }
    }
}
