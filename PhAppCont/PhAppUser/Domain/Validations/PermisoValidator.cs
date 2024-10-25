using System;
using FluentValidation;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad Permiso utilizando FluentValidation.
    /// </summary>
    public class PermisoValidator : AbstractValidator<Permiso>
    {
        public PermisoValidator()
        {
            #region Validación del Nombre
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El nombre del permiso es requerido.")
                .Length(3, 20).WithMessage("El nombre del permiso debe tener entre 3 y 20 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");
            #endregion

            #region Validación de la Descripción
            RuleFor(p => p.Descripcion)
                .NotEmpty().WithMessage("La descripción del permiso es requerida.")
                .Length(10, 100).WithMessage("La descripción debe tener entre 10 y 100 caracteres.");
            #endregion

            #region Validación de la Fecha de Creación
            RuleFor(p => p.FechaCreacion.ToString("yyyy-MM-dd"))
                .NotEmpty().WithMessage("La fecha de creación es requerida.")
                .Must(BeAValidISO8601Date).WithMessage("La fecha de creación debe estar en formato ISO 8601 (yyyy-MM-dd).")
                .LessThanOrEqualTo(DateTime.Now.ToString("yyyy-MM-dd")).WithMessage("La fecha de creación no puede ser futura.");
            #endregion

            #region Validación del Creador
            RuleFor(p => p.Creador)
                .NotEmpty().WithMessage("El nombre del creador es requerido.")
                .Length(3, 50).WithMessage("El nombre del creador debe tener entre 3 y 50 caracteres.");
            #endregion

            #region Validación de la Categoría
            RuleFor(p => p.Categoria)
                .NotEmpty().WithMessage("La categoría del permiso es requerida.")
                .Length(3, 50).WithMessage("La categoría del permiso debe tener entre 3 y 50 caracteres.");
            #endregion

            #region Validación del Estado
            RuleFor(p => p.Estado)
                .NotNull().WithMessage("El estado del permiso es requerido.");
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
