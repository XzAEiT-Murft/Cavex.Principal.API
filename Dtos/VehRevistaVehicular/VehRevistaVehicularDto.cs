namespace Cavex.Principal.API.Dtos.VehRevistaVehicular
{
    public class VehRevistaVehicularDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public string StrFolioRevista { get; set; } = string.Empty;
        public string StrResultado { get; set; } = string.Empty;
        public string StrInspector { get; set; } = string.Empty;
        public DateOnly DteFechaRevista { get; set; }
        public DateOnly DteProximaRevista { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlRevistaVehicular { get; set; }
        public int IdVehCatStatus { get; set; }
    }
}
