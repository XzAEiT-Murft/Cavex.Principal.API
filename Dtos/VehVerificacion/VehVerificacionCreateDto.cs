using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.VehVerificacion
{
    public class VehVerificacionCreateDto
    {
        public int IdVehDatosGenerales { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrFolioVerificacion { get; set; } = string.Empty;

        public int IdVehCatHolograma { get; set; }

        [Required]
        [MaxLength(300)]
        public string StrCentroVerificacion { get; set; } = string.Empty;

        public int IntAnio { get; set; }

        [Required]
        [MaxLength(50)]
        public string StrSemestre { get; set; } = string.Empty;

        public DateOnly DteFechaVerificacion { get; set; }

        public DateOnly DteFechaVencimiento { get; set; }

        public int IdVehCatStatus { get; set; }
    }
}
