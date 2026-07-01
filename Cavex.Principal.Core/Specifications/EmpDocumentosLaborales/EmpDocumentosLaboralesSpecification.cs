using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDocumentosLaborales
{
    public class EmpDocumentosLaboralesSpecification : BaseSpecification<Entities.EmpDocumentosLaborales>
    {
        public EmpDocumentosLaboralesSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.Id);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpDocumentosLaboralesSpecification(int id)
            : base(x => x.Id == id)
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
                x.StrUrlLicencia.Contains(search) ||
                x.StrUrlFotoEmp.Contains(search);
        }
    }
}
