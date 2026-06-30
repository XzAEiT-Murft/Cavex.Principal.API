namespace Cavex.Principal.API.Dtos.VehTarjetaCirculacion
{
    public class VehTarjetaCirculacionDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public string StrNumeroTarjeta { get; set; } = string.Empty;
        public int IdEmpCatEntidadFederativa { get; set; }
        public DateOnly DteFechaExpedicion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlTarjeta { get; set; }
    }
}
