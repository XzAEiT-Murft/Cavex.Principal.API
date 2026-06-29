namespace Cavex.Principal.Core.Entities
{
    public class VehPermisoTransporte : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public required string StrNumeroPermiso { get; set; }
        public int IdVehCatTipoPermiso { get; set; }
        public required string StrAutoridad { get; set; }
        public DateOnly DteFechaExpedicion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlPermisoTransporte { get; set; }
        public int IdVehCatStatus { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public VehCatTipoPermiso? VehCatTipoPermiso { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}