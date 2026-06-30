using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehControlLlanta
{
    public class VehControlLlantaCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        public int IdVehCatMarcaLlanta { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrModelo { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string StrMedida { get; set; } = string.Empty;

        public DateOnly DteFechaCompra { get; set; }

        public decimal MnyCosto { get; set; }

        public int IdVehCatPosicionLlanta { get; set; }

        public decimal DecKilometrajeActual { get; set; }

        public DateOnly? DteFechaFinVidaEstimada { get; set; }

        public DateOnly? DteFechaRotacion { get; set; }

        public DateOnly? DteFechaSiguienteRotacion { get; set; }

        [MaxLength(2048)]
        public string? StrUrlEvidencia { get; set; }

        public int IdVehCatStatus { get; set; }
    }
}
