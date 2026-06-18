using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDocumentosLaborales
{
    public class EmpDocumentosLaboralesCountSpecification : BaseSpecification<Entities.EmpDocumentosLaborales>
    {
        public EmpDocumentosLaboralesCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpDocumentosLaborales, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
                return x => x.Id == searchId;

            return x =>
                x.StrUrlIdentificacionOficial.Contains(search) ||
                x.StrUrlComprobanteDomicilio.Contains(search) ||
                x.StrUrlCurriculumVitae.Contains(search) ||
                x.StrUrlContrato.Contains(search) ||
                x.StrUrlLicencia.Contains(search);
        }
    }
}
