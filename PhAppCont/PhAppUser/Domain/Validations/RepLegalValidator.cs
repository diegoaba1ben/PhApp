using FluentValidation;
using PhAppUser.Domain.Entities;
using System;
using System.Globalization;
using System.Linq;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad RepLegal
    /// </summary>
    public class RepLegalValidator : AbstractValidator<RepLegal>
    {
        public RepLegalValidator()
        {
            // Validación del campo CertLegal
            RuleFor(r => r.CertLegal)
                .NotEmpty().WithMessage("El número de certificación legal es requerido.")
                .Length(5, 20).WithMessage("El número de certificación debe tener entre 5 y 20 caracteres.")
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("La certificación legal solo puede contener números y letras.");

            // Validación de la fecha de emisión de la certificación en formato ISO 8601
            RuleFor(r => r.FechaInicio)  // Se usa directamente el campo DateTime sin ToString()
                .NotEmpty().WithMessage("La fecha de emisión de la certificación es requerida.")
                .Must(BeAValidISO8601Date).WithMessage("La fecha de emisión debe estar en formato ISO 8601 (yyyy-MM-dd o yyyy-MM-ddTHH:mm).")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de emisión no puede ser posterior a la fecha actual.");

            // Validación de la fecha de vencimiento de la certificación en formato ISO 8601
            RuleFor(r => r.FechaFinal)  // Se usa directamente el campo DateTime sin ToString()
                .NotEmpty().WithMessage("La fecha de vencimiento de la certificación es requerida.")
                .Must(BeAValidISO8601Date).WithMessage("La fecha de vencimiento debe estar en formato ISO 8601 (yyyy-MM-dd o yyyy-MM-ddTHH:mm).")
                .GreaterThan(r => r.FechaInicio).WithMessage("La fecha de vencimiento debe ser posterior a la fecha de emisión.");
        }

        /// <summary>
        /// Método para validar si una cadena está en formato ISO 8601
        /// </summary>
        private bool BeAValidISO8601Date(DateTime fecha)
        {
            // Convertir la fecha a string en formato ISO 8601 y verificar si es válida
            string[] formats = { "yyyy-MM-dd", "yyyy-MM-ddTHH:mm", "yyyy-MM-ddTHH:mm:ss" };
            string fechaStr = fecha.ToString("yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture);
            return DateTime.TryParseExact(fechaStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}


