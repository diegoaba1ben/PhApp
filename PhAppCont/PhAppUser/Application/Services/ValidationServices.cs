using System;
using System.Collections.Generic;
using PhAppUser.Domain.Enums;
using PhAppUser.Application.Interfaces;

namespace PhAppUser.Application.Services
{
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Diccionario para almacenar las funciones de validación para cada tipo.
        /// </summary>
        private readonly Dictionary<string, Func<string, bool>> _validationRules;

        /// <summary>
        /// Constructor para inicializar las reglas de validación.
        /// </summary>
        public ValidationService()
        {
            _validationRules = new Dictionary<string, Func<string, bool>>
            {
                { nameof(TipoIdentificacion.Cedula), ValidateMinLength },
                { nameof(TipoIdentificacion.CedulaExtranjeria), ValidateMinLength },
                { nameof(TipoIdentificacion.Pasaporte), ValidateMinLength },
                { nameof(TipoIdentificacion.TarjetaIdentidad), ValidateMinLength },
                { nameof(TipoIdenTrib.NIT), ValidateMinLength },
                { nameof(TipoIdenTrib.RUT), ValidateMinLength },
                { nameof(TipoIdenTrib.NoAplica), ValidateNoAplica },
                { nameof(TipoSegSoc.Salud), ValidateMinLength },
                { nameof(TipoSegSoc.Pension), ValidateMinLength }
            };
        }

        /// <summary>
        /// Método principal para validar el valor según su tipo.
        /// </summary>
        public bool Validate(string type, string value)
        {
            if (_validationRules.ContainsKey(type))
            {
                return _validationRules[type](value);
            }
            throw new ArgumentException($"No existe una regla de validación para el tipo {type}");
        }

        /// <summary>
        /// Validación general para asegurar que el valor no esté vacío y tenga una longitud mínima.
        /// </summary>
        private bool ValidateMinLength(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Length >= 1;
        }

        /// <summary>
        /// Validación específica para cuando el tipo es 'No Aplica'.
        /// </summary>
        private bool ValidateNoAplica(string value)
        {
            return string.IsNullOrWhiteSpace(value); // Permite valor vacío
        }
    }
}

