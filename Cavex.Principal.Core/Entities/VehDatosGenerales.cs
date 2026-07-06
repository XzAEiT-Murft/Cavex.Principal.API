namespace Cavex.Principal.Core.Entities
{
    public class VehDatosGenerales : BaseEntity
    {
        public required string StrNumSerie { get; set; }
        public int IdVehCatMarcaVehiculo { get; set; }
        public required string StrModelo { get; set; }
        public int IntAnio { get; set; }
        public string? StrVersion { get; set; }
        public int IdVehCatColor { get; set; }
        public required string StrPlaca { get; set; }
        public int? IntNumMotor { get; set; }
        public string? StrNumMotor { get; set; }
        public int IdVehCatTipoVehiculo { get; set; }
        public int IdVehCatCapacidad { get; set; }
        public int IdVehCatTipoCombustible { get; set; }
        public decimal DecKilometrajeActual { get; set; }
        public int IdVehCatStatus { get; set; }
        public string? StrUrlFoto { get; set; }
        public DateOnly DteFechaRegistro { get; set; }
        public string? StrObservaciones { get; set; }
        public string? StrMotor { get; set; }
        public int IdVehCatTransmision { get; set; }

        public VehCatMarcaVehiculo? VehCatMarcaVehiculo { get; set; }
        public VehCatColor? VehCatColor { get; set; }
        public VehCatTipoVehiculo? VehCatTipoVehiculo { get; set; }
        public VehCatCapacidad? VehCatCapacidad { get; set; }
        public VehCatTipoCombustible? VehCatTipoCombustible { get; set; }
        public VehCatStatus? VehCatStatus { get; set; }
        public VehCatTransmision? VehCatTransmision { get; set; }

        public List<VehAsignacionVehiculos>? VehAsignacionesVehiculos { get; set; }
        public List<VehContratoArrendamiento>? VehContratosArrendamiento { get; set; }
        public List<VehControlGasolina>? VehControlesGasolina { get; set; }
        public List<VehControlLlanta>? VehControlesLlanta { get; set; }
        public List<VehControlServicio>? VehControlesServicio { get; set; }
        public List<VehDaniosAccidentes>? VehDaniosAccidentes { get; set; }
        public List<VehDocumentosVehiculo>? VehDocumentosVehiculo { get; set; }
        public List<VehInfracciones>? VehInfracciones { get; set; }
        public List<VehPermisoTransporte>? VehPermisosTransporte { get; set; }
        public List<VehPlacas>? VehPlacas { get; set; }
        public List<VehRevistaVehicular>? VehRevistasVehiculares { get; set; }
        public List<VehSeguro>? VehSeguros { get; set; }
        public List<VehTarjetaCirculacion>? VehTarjetasCirculacion { get; set; }
        public List<VehTenencia>? VehTenencias { get; set; }
        public List<VehVerificacion>? VehVerificaciones { get; set; }
    }
}
