using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehRevistaVehicular
{
    public class VehRevistaVehicularUpdateDto
    {
        public int IdVehDatosGenerales { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrFolioRevista { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StrResultado { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StrInspector { get; set; } = string.Empty;

        public DateOnly DteFechaRevista { get; set; }

        public DateOnly DteProximaRevista { get; set; }

        public decimal MnyMontoPagado { get; set; }

        public int IdVehFormaPago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlComprobantePago { get; set; }

        [MaxLength(2048)]
        public string? StrUrlRevistaVehicular { get; set; }

        public int IdVehCatStatus { get; set; }
    }
}
