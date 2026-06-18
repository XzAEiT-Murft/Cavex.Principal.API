using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpExperiencia
{
    public class EmpExperienciaUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string StrEmpresa { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string StrPuesto { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string StrArea { get; set; } = string.Empty;

        [Required]
        public DateOnly DteFechaIncio { get; set; }

        [Required]
        public DateOnly DteFechaFin { get; set; }

        [Required]
        public decimal MnySueldo { get; set; }

        [Required]
        [MaxLength(500)]
        public string StrMotivoSalida { get; set; } = string.Empty;

        [Required]
        public int IdEmpEmpleado { get; set; }
    }
}
