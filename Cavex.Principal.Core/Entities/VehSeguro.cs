namespace Cavex.Principal.Core.Entities
{
    public class VehSeguro : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public int IdVehCatAseguradora { get; set; }
        public required string StrNumeroPoliza { get; set; }
        public decimal MnyMontoCoberura { get; set; }
        public int IdVehCatTipoCobertura { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public DateOnly DteFechaInicio { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlPolizaSeguro { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatAseguradora? VehCatAseguradora { get; set; }
        public VehCatTipoCobertura? VehCatTipoCobertura { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDaniosAccidentes>? VehDaniosAccidentes { get; set; }
        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}