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
        public string AlcaldiaEmisora { get; private set; }

        /// <summary>
        /// Relación con la entidad Cargo que indica el rol asociado a este documento.
        /// </summary>
        [Required]
        public int CargoId { get; private set; }

        [ForeignKey("CargoId")]
        public Cargo Cargo { get; private set; }

        /// <summary>
        /// Fecha de expedición del documento de representación legal.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(RepLegal), nameof(ValidarFechaExpedicion))]
        public DateTime FechaExpedicion { get; private set; }

        /// <summary>
        /// Fecha de vencimiento del documento.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaVencimiento { get; private set; }

        /// <summary>
        /// Atributo que indica si el Representante Legal está en condición de activo o inactivo.
        /// </summary>
        public bool EsActivo { get; set; } = true;

        // Constructor privado para el builder
        private RepLegal() { }

        /// <summary>
        /// Constructor privado para inicializar un representante legal a través del builder.
        /// </summary>
        /// <param name="builder">El builder que crea la instancia de RepLegal.</param>
        private RepLegal(RepLegalBuilder builder)
        {
            FechaExpedicion = builder.FechaExpedicion;
            FechaVencimiento = builder.FechaVencimiento;
            AlcaldiaEmisora = builder.AlcaldiaEmisora;
            CargoId = builder.CargoId;
            Cargo = builder.Cargo;
            EsActivo = builder.EsActivo;
        }

        /// <summary>
        /// Valida la fecha de expedición.
        /// </summary>
        public static ValidationResult ValidarFechaExpedicion(DateTime fechaExpedicion)
        {
            if (fechaExpedicion > DateTime.Today)
            {
                return new ValidationResult("La fecha de expedición no puede ser posterior a la fecha actual");
            }
            return ValidationResult.Success ?? new ValidationResult("Validación exitosa");
        }

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
        /// Builder para crear instancias de RepLegal.
        /// </summary>
        public class RepLegalBuilder
        {
            public DateTime FechaExpedicion { get; private set; }
            public DateTime FechaVencimiento { get; private set; }
            public string AlcaldiaEmisora { get; private set; }
            public int CargoId { get; private set; }
            public Cargo Cargo { get; private set; }
            public bool EsActivo { get; private set; } = true;

            /// <summary>
            /// Establece la fecha de expedición.
            /// </summary>
            public RepLegalBuilder WithFechaExpedicion(DateTime fechaExpedicion)
            {
                FechaExpedicion = fechaExpedicion;
                return this;
            }

            /// <summary>
            /// Establece la fecha de vencimiento.
            /// </summary>
            public RepLegalBuilder WithFechaVencimiento(DateTime fechaVencimiento)
            {
                FechaVencimiento = fechaVencimiento;
                return this;
            }

            /// <summary>
            /// Establece la alcaldía emisora del documento.
            /// </summary>
            public RepLegalBuilder WithAlcaldiaEmisora(string alcaldiaEmisora)
            {
                AlcaldiaEmisora = alcaldiaEmisora;
                return this;
            }

            /// <summary>
            /// Establece el ID del cargo asociado.
            /// </summary>
            public RepLegalBuilder WithCargoId(int cargoId)
            {
                CargoId = cargoId;
                return this;
            }

            /// <summary>
            /// Establece el cargo asociado al documento.
            /// </summary>
            public RepLegalBuilder WithCargo(Cargo cargo)
            {
                Cargo = cargo ?? throw new ArgumentNullException(nameof(cargo), "El cargo no puede ser nulo.");
                return this;
            }

            /// <summary>
            /// Establece si el documento está activo.
            /// </summary>
            public RepLegalBuilder WithEsActivo(bool esActivo)
            {
                EsActivo = esActivo;
                return this;
            }

            /// <summary>
            /// Crea una nueva instancia de RepLegal.
            /// </summary>
            public RepLegal Build()
            {
                return new RepLegal(this);
            }
        }
    }
}
