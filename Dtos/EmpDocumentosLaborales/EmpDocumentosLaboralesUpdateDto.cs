using System.ComponentModel.DataAnnotations;

namespace Cavex.Principal.API.Dtos.EmpDocumentosLaborales
{
    public class EmpDocumentosLaboralesUpdateDto
    {
        [Required]
        [MaxLength(2048)]
        public string StrUrlIdentificacionOficial { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string StrUrlComprobanteDomicilio { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string StrUrlCurriculumVitae { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string StrUrlContrato { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string StrUrlLicencia { get; set; } = string.Empty;

        [Required]
        [MaxLength(2048)]
        public string StrUrlFotoEmp { get; set; } = string.Empty;
    }
}
