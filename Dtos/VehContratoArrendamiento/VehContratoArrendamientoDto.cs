namespace Cavex.Principal.API.Dtos.VehContratoArrendamiento
{
    public class VehContratoArrendamientoDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatArrendatario { get; set; }
        public string StrNumeroContrato { get; set; } = string.Empty;
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaFin { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrPeriodoPago { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlContratoArrendamiento { get; set; }
    }
}
