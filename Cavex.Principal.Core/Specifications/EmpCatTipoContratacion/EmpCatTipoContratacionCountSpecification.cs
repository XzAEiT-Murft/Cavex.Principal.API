using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpCatTipoContratacion
{
    public class EmpCatTipoContratacionCountSpecification : BaseSpecification<Entities.EmpCatTipoContratacion>
    {
        public EmpCatTipoContratacionCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpCatTipoContratacion, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
                return x => x.Id == searchId;

            return x =>
                x.StrValor.Contains(search) ||
                (x.StrDescripcion != null && x.StrDescripcion.Contains(search));
        }
    }
}