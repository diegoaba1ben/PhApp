using FluentValidation;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad EntSalud.
    /// </summary>
    public class EntSaludValidator : AbstractValidator<EntSalud>
    {
        public EntSaludValidator()
        {
            #region Validación del tipo de identificación tributaria
            RuleFor(s => s.TipoIdenTrib)
                .NotNull().WithMessage("El tipo de identificación tributaria es requerido.")
                .IsInEnum().WithMessage("El tipo de identificación tributaria no es válido.");
            #endregion

            #region Validación del número de identificación tributaria
            RuleFor(s => s.Numero)
                .NotEmpty().WithMessage("El número de identificación tributaria es requerido.")
                .Length(5, 20).WithMessage("El número de identificación debe tener entre 5 y 20 caracteres.")
                .Matches(@"^\d+$").WithMessage("El número de identificación tributaria solo debe contener números.");
            #endregion

            #region Validación de la razón social
            RuleFor(s => s.RazonSocial)
                .NotEmpty().WithMessage("La razón social es requerida.")
                .Length(3, 100).WithMessage("La razón social debe tener entre 3 y 100 caracteres.")
                .Matches(@"^[\p{L}\s]+$").WithMessage("La razón social solo puede contener letras y espacios.");
            #endregion
        }
    }
}
