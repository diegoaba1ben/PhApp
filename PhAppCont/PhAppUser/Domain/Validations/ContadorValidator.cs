using System;
using FluentValidation;
using PhAppUser.Domain.Entities;
using PhAppUser.Domain.Enums;

namespace PhAppUser.Domain.Validations
{
    /// <summary>
    /// Clase de validación para la entidad Contador
    /// </summary>
    public class ContadorValidator : AbstractValidator<Contador>
    {
        public ContadorValidator()
        {
            // Validación del TipoUsuario
            RuleFor(c => c.TipoUsuario)
                .Equal(TipoUsuario.Contador)
                .WithMessage("El TipoUsuario debe ser 'Contador' para este tipo de validación.");

            // Validación de la tarjeta profesional
            RuleFor(c => c.TarjProf)
                .NotEmpty().WithMessage("El campo Tarjeta Profesional es requerido.")
                .Length(4, 20).WithMessage("El número de la tarjeta profesional debe estar entre 4 y 20 caracteres.")
                .Matches(@"^[a-zA-Z0-9\-_]+$").WithMessage("El campo de la tarjeta profesional solo puede contener números, letras y los signos _ -.")
                .Matches(@"^TP[0-9]+$").WithMessage("La tarjeta profesional debe comenzar con 'TP' seguido de números."); // Ejemplo opcional

            // Aquí se podría agregar una validación de unicidad si fuera necesario (ej, cuando hay dos contadores)
        }
    }
}


