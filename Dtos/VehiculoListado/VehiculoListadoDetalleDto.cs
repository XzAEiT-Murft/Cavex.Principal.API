namespace Cavex.Principal.API.Dtos.VehiculoListado
{
    public class VehiculoListadoDetalleDto
    {
        public int Id { get; set; }

        public string StrPlaca { get; set; } = string.Empty;
        public string StrNumSerie { get; set; } = string.Empty;

        public int IdVehCatMarcaVehiculo { get; set; }
        public string StrMarca { get; set; } = string.Empty;

        public string StrModelo { get; set; } = string.Empty;
        public int IntAnio { get; set; }
        public string? StrVersion { get; set; }

        public int IdVehCatColor { get; set; }
        public string StrColor { get; set; } = string.Empty;

        public string? StrNumMotor { get; set; }
        public string? StrMotor { get; set; }

        public int IdVehCatTipoVehiculo { get; set; }
        public string StrTipoVehiculo { get; set; } = string.Empty;

        public int IdVehCatCapacidad { get; set; }
        public string StrCapacidad { get; set; } = string.Empty;

        public int IdVehCatTipoCombustible { get; set; }
        public string StrTipoCombustible { get; set; } = string.Empty;

        public int IdVehCatTransmision { get; set; }
        public string StrTransmision { get; set; } = string.Empty;

        public decimal DecKilometrajeActual { get; set; }

        public int IdVehCatStatus { get; set; }
        public string StrStatus { get; set; } = string.Empty;

        public string? StrUrlFoto { get; set; }
        public DateOnly DteFechaRegistro { get; set; }
        public string? StrObservaciones { get; set; }
    }
}
