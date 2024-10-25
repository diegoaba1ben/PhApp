using System;
using System.Globalization;
using FluentValidation;
using PhAppUser.Domain.Entities;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Clase de validación para la entidad Usuario utilizando FluentValidation.
    /// </summary>
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            #region Validaciones para las propiedades básicas 

            RuleFor(u => u.NombresCompletos)
                .NotEmpty().WithMessage("El campo nombres completos es requerido.")
                .Length(3, 60).WithMessage("El campo nombres completos debe tener entre 3 y 60 caracteres.")
                .Matches(@"^[\p{L}''\-\s]+$").WithMessage("El campo nombres completos solo debe contener letras y espacios en blanco.");

            RuleFor(u => u.ApellidosCompletos)
                .NotEmpty().WithMessage("El campo apellidos completos es requerido.")
                .Length(3, 60).WithMessage("El campo apellidos completos debe tener entre 3 y 60 caracteres.")
                .Matches(@"^[\p{L}''\-\s]+$").WithMessage("El campo apellidos completos solo debe contener letras y espacios en blanco.");
            
            RuleFor(u => u.Identificacion)
                .NotEmpty().WithMessage("La identificación es requerida.")
                .Length(5, 20).WithMessage("La identificación debe tener entre 5 y 20 caracteres.")
                .Matches(@"^\d+$").WithMessage("La identificación solo debe contener números.");

            #endregion

            #region Validaciones para el estado del usuario

            RuleFor(u => u.EsActivo)
                .NotNull().WithMessage("El estado de activación es requerido.");

            RuleFor(u => u.FechaRegistro)
                .NotEmpty().WithMessage("La fecha de registro es requerida.")
                .Must(BeAValidISO8601Date).WithMessage("La fecha de registro debe estar en formato ISO 8601 (yyyy-MM-dd).");

            RuleFor(u => u.FechaInactivacion)
                .Must(date => date == null || date >= DateTime.UtcNow)
                .WithMessage("La fecha de inactivación no puede ser menor a la fecha actual.");

            #endregion

            #region Validaciones para el tipo de contrato y responsabilidades tributarias

            RuleFor(u => u.TipoContrato)
                .NotNull().WithMessage("El tipo de contrato es requerido.")
                .IsInEnum().WithMessage("El tipo de contrato no es válido.");

            When(u => u.TipoContrato == TipoContrato.Empleado, () =>
            {
                RuleFor(u => u.SujetoARetencion)
                    .NotNull().WithMessage("Debe indicar si el usuario es sujeto a retención.");
            });

            When(u => u.TipoContrato == TipoContrato.PrestadorDeServicios, () =>
            {
                RuleFor(u => u.TipoIdenTrib)
                    .NotNull().WithMessage("El tipo de identificación tributaria es requerido para prestadores de servicios.")
                    .IsInEnum().WithMessage("El tipo de identificación tributaria no es válido.");

                RuleFor(u => u.NombreSocial)
                    .NotEmpty().WithMessage("El nombre o razón social es requerido para prestadores de servicios.");
            });

            #endregion

            #region Validaciones para la seguridad social (Salud y Pensión)

            RuleFor(u => u.Salud)
                .NotNull().WithMessage("La afiliación a una entidad de salud es requerida.")
                .SetValidator(new EntSaludValidator());

            RuleFor(u => u.Pension)
                .NotNull().WithMessage("La afiliación a una entidad de pensión es requerida.")
                .SetValidator(new EntPensionValidator());

            #endregion
        }

        /// <summary>
        /// Valida si una fecha está en formato ISO 8601 (yyyy-MM-dd).
        /// </summary>
        /// <param name="fecha">Fecha a validar</param>
        /// <returns>Verdadero si la fecha es válida para el formato ISO 8601</returns>
        private bool BeAValidISO8601Date(string fecha)
        {
            var formats = new[] { "yyyy-MM-dd", "yyyy-MM-ddTHH:mm", "yyyy-MM-ddTHH:mm:ss" };
            return DateTime.TryParseExact(fecha, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}

