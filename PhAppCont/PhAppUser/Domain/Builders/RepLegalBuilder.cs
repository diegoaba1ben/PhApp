using System;
using PhAppUser.Domain.Entities;

namespace PhAppUser.Domain.Builders
{
    public class RepLegalBuilder : UsuarioBuilder
    {
        public RepLegalBuilder() : base(new RepLegal()) 
        {
            // Aseguramos que siempre se cree un usuario de tipo RepLegal
        }

        // Método específico para agregar la certificación legal del RepLegal
        public RepLegalBuilder ConCertLegal(string certLegal)
        {
            ((RepLegal)_usuario).CertLegal = certLegal;
            return this;
        }

        // Método para agregar la fecha de inicio de la certificación
        public RepLegalBuilder ConFechaInicio(DateTime fechaInicio)
        {
            ((RepLegal)_usuario).FechaInicio = fechaInicio;
            return this;
        }

        // Método para agregar la fecha final de la certificación
        public RepLegalBuilder ConFechaFinal(DateTime fechaFinal)
        {
            ((RepLegal)_usuario).FechaFinal = fechaFinal;
            return this;
        }

        // Método para construir y devolver el objeto RepLegal
        public override RepLegal Build()
        {
            return (RepLegal)_usuario;
        }
    }
}

