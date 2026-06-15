using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpDatosAcademicos
{
    public class EmpDatosAcademicosCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string StrNivelEstudios { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string StrInstitucion { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? StrCarrera { get; set; }

        [Required]
        [MaxLength(200)]
        public string StrEstatus { get; set; } = string.Empty;

        [Required]
        public DateOnly DteFechaInicio { get; set; }

        [Required]
        public DateOnly DteFechaFin { get; set; }
    }
}
