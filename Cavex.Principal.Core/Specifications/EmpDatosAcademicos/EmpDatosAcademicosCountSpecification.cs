using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDatosAcademicos
{
    public class EmpDatosAcademicosCountSpecification : BaseSpecification<Entities.EmpDatosAcademicos>
    {
        public EmpDatosAcademicosCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpDatosAcademicos, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
                return x => x.Id == searchId;

            return x =>
                x.StrNivelEstudios.Contains(search) ||
                x.StrInstitucion.Contains(search) ||
                x.StrEstatus.Contains(search) ||
                (x.StrCarrera != null && x.StrCarrera.Contains(search));
        }
    }
}