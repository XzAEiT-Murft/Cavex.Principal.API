using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDatosAcademicos
{
    public class EmpDatosAcademicosSpecification : BaseSpecification<Entities.EmpDatosAcademicos>
    {
        public EmpDatosAcademicosSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderByDescending(x => x.DteFechaInicio);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpDatosAcademicosSpecification(int id)
            : base(x => x.Id == id)
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