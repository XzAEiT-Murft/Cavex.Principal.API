using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpCatTipoContratacion
{
    public class EmpCatTipoContratacionSpecification : BaseSpecification<Entities.EmpCatTipoContratacion>
    {
        public EmpCatTipoContratacionSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpCatTipoContratacionSpecification(int id)
            : base(x => x.Id == id)
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