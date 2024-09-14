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
        /// Entidad emisora del documento.
        /// </summary>
        [Required]
        [StringLength(50)]  // Longitud máxima de 50 caracteres para asegurar la consistencia
        public required string AlcaldiaEmisora { get; set; }

        /// <summary>
        /// Relación con la entidad Cargo que indica el rol asociado a este documento.
        /// </summary>
        [Required]
        public required int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public required Cargo Cargo { get; set; }

        /// <summary>
        /// Fecha de expedición del documento de representación legal.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(RepLegal), nameof(ValidarFechaExpedicion))]
        public required DateTime FechaExpedicion { get; set; }

        public static ValidationResult ValidarFechaExpedicion(DateTime fechaExpedicion)
        {
            
            if(fechaExpedicion > DateTime.Now)
            {
                return new ValidationResult("La fecha de expedición no puede ser posterior a la fecha actual");
            }
            return ValidationResult.Success ?? new ValidationResult("Validación exitosa");
        }

        /// <summary>
        /// Calcula la fecha de vencimiento basada en la fecha de expedición.
        /// Esta fecha debe ser proporcionada manualmente según lo autorizado.
        /// </summary>
       [Required]
       [DataType(DataType.Date)]
       public required DateTime FechaVencimiento { get; set; }


        /// <summary>
        /// Calcula los días restantes hasta el vencimiento del documento.
        /// </summary>
        public int CalcularDiasRestantes()
        {
            return (FechaVencimiento - DateTime.Now).Days;
        }

         /// <summary>
        /// Verifica si el documento ya está vencido.
        /// </summary>
        public bool EsDocumentoVencido()
        {
            return DateTime.Now > FechaVencimiento;
        }

        /// <summary>
        /// Constructor vacío requerido por EF Core
        /// </summary>
        public RepLegal()
        {
            
        }

        /// <summary>
        /// Constructor para inicializar un representante legal con los valores especificados.
        /// </summary>
        public RepLegal(DateTime fechaExpedicion, DateTime fechaVencimiento,  string alcaldiaEmisora, int cargoId, Cargo cargo)
        {
            FechaExpedicion = fechaExpedicion;
            FechaVencimiento = fechaVencimiento; 
            AlcaldiaEmisora = alcaldiaEmisora;
            CargoId = cargoId;
            Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo), "El cargo no puede ser nulo.");
            
        }     
    }
}


