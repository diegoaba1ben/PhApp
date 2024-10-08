using System;

namespace PhAppUser.Application.Interfaces
{
    public interface IValidationService
    {
        /// <summary>
        /// Valida el valor según el tipo especificado.
        /// </summary>
        /// <param name="type">Tipo de identificación.</param>
        /// <param name="value">Valor a validar.</param>
        /// <returns>Resultado de la validación.</returns>
        bool Validate(string type, string value);
    }
}
