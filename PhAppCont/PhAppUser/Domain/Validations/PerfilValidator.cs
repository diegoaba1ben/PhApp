using System;
using FluentValidation;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Validador para la entidad Perfil utilizando FluentValidation.
    /// </summary>
    public class PerfilValidator : AbstractValidator<Perfil>
    {
        public PerfilValidator()
        {
            #region Validación del Usuario
            RuleFor(p => p.Usuario)
                .NotNull().WithMessage("El perfil debe estar asociado a un usuario.")
                .SetValidator(new UsuarioValidator());
            #endregion

            #region Validación del Área
            RuleFor(p => p.Area)
                .NotNull().WithMessage("El perfil debe estar asociado a un área.")
                .SetValidator(new AreaValidator());
            #endregion

            #region Validación del Cargo
            RuleFor(p => p.Cargo)
                .NotNull().WithMessage("El perfil debe incluir un cargo específico.")
                .SetValidator(new CargoValidator());

            // Verificación de unicidad para RepLegal
            When(p => p.Cargo != null && p.Cargo.Nombre == "RepLegal", () =>
            {
                RuleFor(p => p.Area)
                    .Must(area => !ExisteOtroRepLegalEnArea(area))
                    .WithMessage("Ya existe un representante legal asignado a esta área.");
            });
            #endregion

            #region Validación de la Fecha de Creación
            RuleFor(p => p.FechaCreacion)
                .NotEmpty().WithMessage("La fecha de creación del perfil es requerida.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de creación no puede ser futura.");
            #endregion
        }

        /// <summary>
        /// Lógica para verificar si ya existe un usuario con el rol de RepLegal en el área.
        /// </summary>
        private bool ExisteOtroRepLegalEnArea(Area area)
        {
            // Implementación simulada para verificar si existe otro RepLegal en el área
            // En una aplicación real, podrías consultar la base de datos o contexto
            return area.Cargos.Any(c => c.Nombre == "RepLegal");
        }
    }
}
