namespace Cavex.Principal.API.Dtos.VehDatosGenerales
{
    public class VehDatosGeneralesDto
    {
        public int Id { get; set; }
        public string StrNumSerie { get; set; } = string.Empty;
        public int IdVehCatMarcaVehiculo { get; set; }
        public string StrModelo { get; set; } = string.Empty;
        public int IntAnio { get; set; }
        public string? StrVersion { get; set; }
        public int IdVehCatColor { get; set; }
        public string StrPlaca { get; set; } = string.Empty;
        public int? IntNumMotor { get; set; }
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
    }
}
