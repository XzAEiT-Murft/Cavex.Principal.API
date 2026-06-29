namespace Cavex.Principal.Core.Entities
{
    public class VehContratoArrendamiento : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatArrendatario { get; set; }
        public required string StrNumeroContrato { get; set; }
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaFin { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrPeriodoPago { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlContratoArrendamiento { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatArrendatario? VehCatArrendatario { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}