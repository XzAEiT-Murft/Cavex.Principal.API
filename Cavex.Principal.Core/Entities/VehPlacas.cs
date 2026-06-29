namespace Cavex.Principal.Core.Entities
{
    public class VehPlacas : BaseEntity
    {
        public int IdVehDatosGenerales { get; set; }
        public required string StrNumPlaca { get; set; }
        public int IdEmpCatEntidadFederativa { get; set; }
        public DateOnly DteFechaAsignacion { get; set; }
        public DateOnly DteFechaVencimiento { get; set; }
        public decimal MnyMontoPagado { get; set; }
        public int IdVehCatFormaPago { get; set; }
        public string? StrUrlComprobantePago { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlPlacas { get; set; }

        public VehDatosGenerales? VehDatosGenerales { get; set; }
        public EmpCatEntidadFederativa? EmpCatEntidadFederativa { get; set; }
        public VehCatFormaPago? VehCatFormaPago { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }

        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
    }
}