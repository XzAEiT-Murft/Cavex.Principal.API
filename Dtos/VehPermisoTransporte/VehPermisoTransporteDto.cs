namespace Cavex.Principal.API.Dtos.VehPermisoTransporte
{
    public class VehPermisoTransporteDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public string StrNumeroPermiso { get; set; } = string.Empty;
        public int IdVehCatTipoPermiso { get; set; }
        public string StrAutoridad { get; set; } = string.Empty;
        public DateOnly DteFechaExpedicion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlPermisoTransporte { get; set; }
        public int IdVehCatStatus { get; set; }
    }
}
