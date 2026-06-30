namespace Cavex.Principal.API.Dtos.VehDaniosAccidentes
{
    public class VehDaniosAccidentesDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaEvento { get; set; }
        public string StrDescripcion { get; set; } = string.Empty;
        public string? StrUbicacion { get; set; }
        public decimal? MnyMontoReparacion { get; set; }
        public bool BitCubiertoPorSeguro { get; set; }
        public int? IdVehSeguro { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlEvidencia { get; set; }
        public string? StrObservaciones { get; set; }
    }
}
