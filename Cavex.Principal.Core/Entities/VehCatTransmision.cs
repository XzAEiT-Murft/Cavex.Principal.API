namespace Cavex.Principal.Core.Entities
{
    /// <summary>
    /// Catalogo de tipos de transmision disponibles para los vehiculos.
    /// </summary>
    public class VehCatTransmision : BaseEntity
    {
        public required string StrValor { get; set; }
        public string? StrDescripcion { get; set; }

        public List<VehDatosGenerales>? VehDatosGenerales { get; set; }
    }
}
