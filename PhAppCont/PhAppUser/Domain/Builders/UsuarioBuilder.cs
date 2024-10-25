using System;
using System.ComponentModel.DataAnnotations;
using PhAppUser.Domain.Enums;  // Para los enums como TipoContrato, TipoIdenTrib, etc.
using PhAppUser.Domain.Entities;  // Para las clases EntSalud y EntPension

namespace PhAppUser.Domain.Builders
{
    public class Usuario
    {
        // Atributos y propiedades básicas de la clase Usuario...

        public TipoContrato TipoContrato { get; set; }
        public bool? SujetoARetencion { get; set; } // Para Empleado
        public TipoIdenTrib? TipoIdenTrib { get; set; } // Para PrestadorDeServicios
        public string NombreSocial { get; set; } // Para PrestadorDeServicios

        public EntSalud Salud { get; set; } // Atributo para la afiliación a salud
        public EntPension Pension { get; set; } // Atributo para la afiliación a pensión

        // Constructor privado
        private Usuario() { }

        public static UsuarioBuilder Builder() => new UsuarioBuilder();

        public class UsuarioBuilder
        {
            private readonly Usuario _usuario;

            public UsuarioBuilder()
            {
                _usuario = new Usuario();
            }

            #region Métodos concatenados para los atributos básicos de Usuario
            public UsuarioBuilder ConNombresCompletos(string nombresCompletos)
            {
                _usuario.NombresCompletos = nombresCompletos;
                return this;
            }

            public UsuarioBuilder ConApellidosCompletos(string apellidosCompletos)
            {
                _usuario.ApellidosCompletos = apellidosCompletos;
                return this;
            }

            public UsuarioBuilder ConTipoIdentificacion(TipoIdentificacion tipoIdentificacion)
            {
                _usuario.TipoIdentificacion = tipoIdentificacion;
                return this;
            }

            public UsuarioBuilder ConIdentificacion(string identificacion)
            {
                _usuario.Identificacion = identificacion;
                return this;
            }

            public UsuarioBuilder ConDireccion(string direccion)
            {
                _usuario.Direccion = direccion;
                return this;
            }

            public UsuarioBuilder ConCiudad(string ciudad)
            {
                _usuario.Ciudad = ciudad;
                return this;
            }

            public UsuarioBuilder ConTelefono(string telefono)
            {
                _usuario.Telefono = telefono;
                return this;
            }

            public UsuarioBuilder ConEmail(string email)
            {
                _usuario.Email = email;
                return this;
            }
            #endregion

            #region Métodos concatenados para el estado del usuario
            public UsuarioBuilder ConEsActivo(bool esActivo)
            {
                _usuario.EsActivo = esActivo;

                if (esActivo)
                {
                    _usuario.FechaInactivacion = null;
                }

                return this;
            }

            public UsuarioBuilder ConFechaRegistro(DateTime fechaRegistro)
            {
                _usuario.FechaRegistro = fechaRegistro;
                return this;
            }
            #endregion

            #region Métodos concatenados para el tipo de contrato y atributos relacionados
            public UsuarioBuilder ConTipoContrato(TipoContrato tipoContrato)
            {
                _usuario.TipoContrato = tipoContrato;
                return this;
            }

            public UsuarioBuilder ConSujetoARetencion(bool? sujetoARetencion)
            {
                if (_usuario.TipoContrato == TipoContrato.Empleado)
                {
                    _usuario.SujetoARetencion = sujetoARetencion;
                }
                return this;
            }

            public UsuarioBuilder ConTipoIdenTrib(TipoIdenTrib? tipoIdenTrib)
            {
                if (_usuario.TipoContrato == TipoContrato.PrestadorDeServicios)
                {
                    _usuario.TipoIdenTrib = tipoIdenTrib;
                }
                return this;
            }

            public UsuarioBuilder ConNombreSocial(string nombreSocial)
            {
                if (_usuario.TipoContrato == TipoContrato.PrestadorDeServicios)
                {
                    _usuario.NombreSocial = nombreSocial;
                }
                return this;
            }
            #endregion

            #region Métodos concatenados para afiliaciones a seguridad social
            public UsuarioBuilder ConSalud(EntSalud salud)
            {
                _usuario.Salud = salud;
                return this;
            }

            public UsuarioBuilder ConPension(EntPension pension)
            {
                _usuario.Pension = pension;
                return this;
            }
            #endregion

            public Usuario Build()
            {
                return _usuario;
            }
        }
    }
}


