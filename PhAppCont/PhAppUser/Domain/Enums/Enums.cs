namespace PhAppUser.Domain.Enums
{
    /// <summary>
    /// Enumerador para los tipos de identificación personal.
    /// </summary>
    public enum TipoIdentificacion
    {
        Cedula,
        CedulaExtranjeria,
        Pasaporte,
        TarjetaIdentidad
    }

    /// <summary>
    /// Enumerador para los tipos de identificación tributaria.
    /// </summary>
    public enum TipoIdenTrib
    {
        NIT,
        RUT,
        NoAplica
    }

    /// <summary>
    /// Enumerador para los tipos de seguridad social.
    /// </summary>
    public enum TipoSegSoc
    {
        Salud,
        Pension
    }
}
