namespace Cavex.Principal.API.Dtos.VehPlacas
{
    public class VehPlacasDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public string StrNumPlaca { get; set; } = string.Empty;
        public int IdEmpCatEntidadFederativa { get; set; }
        public DateOnly DteFechaAsignacion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehCatFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlPlacas { get; set; }
    }
}
