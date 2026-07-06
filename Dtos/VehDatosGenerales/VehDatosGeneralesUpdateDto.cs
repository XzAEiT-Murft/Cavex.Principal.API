using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehDatosGenerales
{
    public class VehDatosGeneralesUpdateDto
    {
        [Required]
        [MaxLength(20)]
        public string StrNumSerie { get; set; } = string.Empty;

        public int IdVehCatMarcaVehiculo { get; set; }

        [Required]
        [MaxLength(250)]
        public string StrModelo { get; set; } = string.Empty;

        public int IntAnio { get; set; }

        [MaxLength(250)]
        public string? StrVersion { get; set; }

        public int IdVehCatColor { get; set; }

        [Required]
        [MaxLength(20)]
        public string StrPlaca { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? StrNumMotor { get; set; }

        public int IdVehCatTipoVehiculo { get; set; }

        public int IdVehCatCapacidad { get; set; }

        public int IdVehCatTipoCombustible { get; set; }

        public decimal DecKilometrajeActual { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlFoto { get; set; }

        public DateOnly DteFechaRegistro { get; set; }

        [MaxLength(500)]
        public string? StrObservaciones { get; set; }

        [MaxLength(500)]
        public string? StrMotor { get; set; }

        public int IdVehCatTransmision { get; set; }
    }
}
