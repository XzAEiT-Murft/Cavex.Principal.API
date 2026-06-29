namespace Cavex.Principal.Core.Entities
{
    public class VehTenencia : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IntAnio { get; set; }
        public DateOnly DteFechaPago { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public string? StrFolioPago { get; set; }
        public int IdVehCatFormaPago { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlFormatoTenencia { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatFormaPago? VehCatFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}