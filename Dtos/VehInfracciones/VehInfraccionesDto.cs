namespace Cavex.Principal.API.Dtos.VehInfracciones
{
    public class VehInfraccionesDto
    {
        public int Id { get; set; }
        public int IdVehDatosGenerales { get; set; }
        public int IdEmpEmpleado { get; set; }
        public DateOnly DteFechaInfraccion { get; set; }
        public string StrMotivo { get; set; } = string.Empty;
        public decimal? MnyMontoPagado { get; set; }
        public int IdVehCatStatus { get; set; }
        public DateOnly? DteFechaPago { get; set; }
        public int? IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrObservaciones { get; set; }
    }
}
