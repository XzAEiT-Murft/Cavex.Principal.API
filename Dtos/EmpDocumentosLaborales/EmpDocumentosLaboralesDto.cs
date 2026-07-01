namespace Cavex.Principal.API.Dtos.EmpDocumentosLaborales
{
    public class EmpDocumentosLaboralesDto
    {
        public int Id { get; set; }
        public string StrUrlIdentificacionOficial { get; set; } = string.Empty;
        public string StrUrlComprobanteDomicilio { get; set; } = string.Empty;
        public string StrUrlCurriculumVitae { get; set; } = string.Empty;
        public string StrUrlContrato { get; set; } = string.Empty;
        public string StrUrlLicencia { get; set; } = string.Empty;
        public string StrUrlFotoEmp { get; set; } = string.Empty;
    }
}
