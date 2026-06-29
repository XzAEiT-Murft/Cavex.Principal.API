namespace Cavex.Principal.Core.Entities
{
    public class VehTarjetaCirculacion : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public required string StrNumeroTarjeta { get; set; }
        public int IdEmpCatEntidadFederativa { get; set; }
        public DateOnly DteFechaExpedicion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public int IdVehCatStatus { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public string? StrUrlTarjeta { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public EmpCatEntidadFederativa? EmpCatEntidadFederativa { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
        public VehCatFormaPago? VehFormaPago { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}