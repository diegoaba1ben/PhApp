using System;
using FluentValidation;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad Cargo utilizando FluentValidation.
    /// </summary>
    public class CargoValidator : AbstractValidator<Cargo>
    {
        public CargoValidator()
        {
            #region Validación del Nombre
            RuleFor(c => c.Nombre)
                .NotEmpty().WithMessage("El nombre del cargo es requerido.")
                .Length(3, 20).WithMessage("El nombre del cargo debe tener entre 3 y 20 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre del cargo solo puede contener letras y espacios.");
            #endregion

            #region Validación de la Descripción
            RuleFor(c => c.Descripcion)
                .NotEmpty().WithMessage("La descripción del cargo es requerida.")
                .Length(10, 100).WithMessage("La descripción debe tener entre 10 y 100 caracteres.");
            #endregion

            #region Validación de la Fecha de Creación
            RuleFor(c => c.FechaCreacion.ToString("yyyy-MM-dd"))
                .NotEmpty().WithMessage("La fecha de creación es requerida.")
                .Must(BeAValidISO8601Date).WithMessage("La fecha de creación debe estar en formato ISO 8601 (yyyy-MM-dd).")
                .LessThanOrEqualTo(DateTime.Now.ToString("yyyy-MM-dd")).WithMessage("La fecha de creación no puede ser futura.");
            #endregion

            #region Validación del Creador
            RuleFor(c => c.Creador)
                .NotEmpty().WithMessage("El nombre del creador es requerido.")
                .Length(3, 50).WithMessage("El nombre del creador debe tener entre 3 y 50 caracteres.");
            #endregion

            #region Validación del Estado
            RuleFor(c => c.Estado)
                .NotNull().WithMessage("El estado del cargo es requerido.");
            #endregion
        }

        /// <summary>
        /// Valida si una fecha está en formato ISO 8601 (yyyy-MM-dd).
        /// </summary>
        /// <param name="fecha">Fecha a validar</param>
        /// <returns>Verdadero si la fecha es válida para el formato ISO 8601</returns>
        private bool BeAValidISO8601Date(string fecha)
        {
            var formats = new[] { "yyyy-MM-dd" };
            return DateTime.TryParseExact(fecha, formats, null, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}
