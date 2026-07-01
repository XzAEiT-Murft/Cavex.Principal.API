namespace Cavex.Principal.API.Dtos.VehCatTransmision
{
    /// <summary>
    /// Datos expuestos del catalogo de transmisiones vehiculares.
    /// </summary>
    public class VehCatTransmisionDto
    {
        public int Id { get; set; }
        public string StrValor { get; set; } = string.Empty;
        public string? StrDescripcion { get; set; }
    }
}
