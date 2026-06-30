using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehDaniosAccidentes
{
    public class VehDaniosAccidentesCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdEmpEmpleado { get; set; }

        public DateOnly DteFechaEvento { get; set; }

        [Required]
        [MaxLength(500)]
        public string StrDescripcion { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? StrUbicacion { get; set; }

        public decimal? MnyMontoReparacion { get; set; }

        public bool BitCubiertoPorSeguro { get; set; }

        public int? IdVehSeguro { get; set; }

        public int IdVehCatStatus { get; set; }

        [MaxLength(2048)]
        public string? StrUrlEvidencia { get; set; }

        [MaxLength(500)]
        public string? StrObservaciones { get; set; }
    }
}
