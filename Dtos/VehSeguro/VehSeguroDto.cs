namespace Cavex.Principal.API.Dtos.VehSeguro
{
    public class VehSeguroDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatAseguradora { get; set; }
        public string StrNumeroPoliza { get; set; } = string.Empty;
        public decimal MnyMontoCoberura { get; set; }
        public int IdVehCatTipoCobertura { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlPolizaSeguro { get; set; }
    }
}
