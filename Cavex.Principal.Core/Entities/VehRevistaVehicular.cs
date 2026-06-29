namespace Cavex.Principal.Core.Entities
{
    public class VehRevistaVehicular : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public required string StrFolioRevista { get; set; }
        public required string StrResultado { get; set; }
        public required string StrInspector { get; set; }
        public DateOnly DteFechaRevista { get; set; }
        public DateOnly DteProximaRevista { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlRevistaVehicular { get; set; }
        public int IdVehCatStatus { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}