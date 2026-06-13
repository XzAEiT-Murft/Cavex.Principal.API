namespace Cavex.Principal.Core.Entities
{
    public class EmpDocumentosLaborales : BaseEntity
    {
        public required string StrUrlIdentificacionOficial { get; set; }
        public required string StrUrlComprobanteDomicilio { get; set; }
        public required string StrUrlCurriculumVitae { get; set; }
        public required string StrUrlContrato { get; set; }
        public required string StrUrlLicencia { get; set; }

        public List<EmpEmpleado>? EmpEmpleados { get; set; }
    }
}
