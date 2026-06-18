using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDireccion
{
    public class EmpDireccionSpecification : BaseSpecification<Entities.EmpDireccion>
    {
        public EmpDireccionSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.Id);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpDireccionSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpDireccion, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (!int.TryParse(search, out var searchId))
                return x => false;

            return x =>
                x.Id == searchId ||
                x.IdEmpCatColonia == searchId ||
                x.IntNumExterior == searchId ||
                x.IntNumInterior == searchId;
        }
    }
}