using System;
using System.ComponentModel.DataAnnotations;

namespace PhAppUser.Domain.Entities
{
    /// <summary>
    /// Representa a un usuario en el sistema.
    /// </summary>
    public class Usuario
    {
        #region Atributos básicos para un usuario
        [Key]
        public int Id { get; set; }
        public string NombresCompletos { get; set; }
        public string ApellidosCompletos { get; set; }

        public TipoIdentificacion TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        #endregion

        #region Atributos de ubicación
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        #endregion

        #region Atributos del estado de un usuario
        public bool EsActivo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public DateTime? FechaInactivacion { get; set; }
        #endregion

        #region Atributos de identificación de loggin
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        #endregion

        #region Atributos para determinar el tipo de usuario
        public TipoUsuario TipoUsuario { get; set; }
        public string TarjProf { get; set; }
        public string CertLegal { get; set; }
        #endregion

        #region Tipo de contrato y manejo tributario
        public TipoContrato TipoContrato { get; set; }
        public bool? SujetoARetencion { get; set; } // Aplica si el contrato es de tipo empleado
        public TipoIdenTrib? TipoIdenTrib { get; set; } // Aplica si el contrato es de tipo prestador de servicios
        public string NombreSocial { get; set; } // Aplica si el contrato es de tipo prestador de servicios
        #endregion

        #region Atributos relacionados con la seguridad social
        public EntSalud Salud { get; set; }
        public EntPension Pensions { get; set; }
        #endregion

        // Constructor privado para usar con el builder
        private Usuario() { }

        // Método estático para iniciar el builder
        public static UsuarioBuilder Builder() => new UsuarioBuilder();

        public class UsuarioBuilder
        {
            private readonly Usuario _usuario;

            public UsuarioBuilder()
            {
                _usuario = new Usuario();
            }

            #region Métodos concatenados de atributos básicos
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
            #endregion

            #region Métodos concatenados de ubicación de un usuario
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

            #region Métodos concatenados del estado de un usuario
            public UsuarioBuilder ConEsActivo(bool esActivo)
            {
                _usuario.EsActivo = esActivo;
                if (esActivo) _usuario.FechaInactivacion = null;
                return this;
            }
            #endregion

            #region Métodos concatenados para determinar el tipo de contrato de un usuario
            public UsuarioBuilder ConTipoContrato(TipoContrato tipoContrato)
            {
                _usuario.TipoContrato = tipoContrato;
                return this;
            }
            #endregion

            #region Métodos concatenados de responsabilidades tributarias
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

            #region Métodos concatenados de seguridad social
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



