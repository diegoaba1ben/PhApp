using System.ComponentModel;

namespace PhAppUser.Domain.Enums
{
    /// <summary>
    /// Enumerador para los tipos de identificación personal.
    /// </summary>
    public enum TipoIdentificacion
    {   
        [Description("Cédula")]
        Cedula = 1,
        [Description("Cédula de extranjería")]
        CedulaExtranjeria = 2,
        [Description("Pasaporte")]
        Pasaporte = 3,
        [Description("Tarjeta de Identidad")]
        TarjetaIdentidad = 4
    }

    /// <summary>
    /// Enumerador para los tipos de usuario en el sistema 
    /// </summary>
    public enum TipoUsuario
    {
        [Description("Usuario común")]
        Comun = 1,
        [Description("Representante legal")]
        RepLegal = 2,
        [Description("Contador")]
        Contador = 3
    }

    /// <summary>
    /// Enumerador para el tipo de contrato.
    /// </summary>
    public enum TipoContrato
    {
        Empleado,
        PrestadorDeServicios
    }

    /// <summary>
    /// Enumerador para los tipos de identificación tributaria.
    /// </summary>
    public enum TipoIdenTrib
    {
        [Description("NIT")]
        NIT = 1,
        [Description("RUT")]
        RUT = 2,
        [Description("No Aplicable")]
        NoAplica = 3
    }

    /// <summary>
    /// Enumerador para los tipos de afiliación a la seguridad social.
    /// </summary>
    public enum TipoAfiliacion
    {
        [Description("Salud")]
        Salud = 1,

        [Description("Pensión")]
        Pension = 2
    }
}


