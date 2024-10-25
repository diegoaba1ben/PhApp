using System;
using FluentValidation;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad Area utilizando FluentValidation.
    /// </summary>
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            #region Validación del Nombre
            RuleFor(a => a.Nombre)
                .NotEmpty().WithMessage("El nombre del área es requerido.")
                .Length(3, 20).WithMessage("El nombre del área debe tener entre 3 y 20 caracteres.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre del área solo puede contener letras y espacios.");
            #endregion

            #region Validación de la Descripción
            RuleFor(a => a.Descripcion)
                .MaximumLength(150).WithMessage("La descripción del área no puede exceder los 150 caracteres.");
            #endregion

            #region Validación del Estado de Representación Legal
            RuleFor(a => a.EsRepLegal)
                .NotNull().WithMessage("Debe especificar si el área tiene responsabilidades de representación legal.");
            #endregion

            #region Validación de los Cargos
            RuleForEach(a => a.Cargos).SetValidator(new CargoValidator())
                .When(a => a.Cargos != null && a.Cargos.Count > 0)
                .WithMessage("Los cargos asociados al área deben ser válidos.");
            #endregion
        }
    }
}
