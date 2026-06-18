using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpHistorialArea
{
    public class EmpHistorialAreaSpecification : BaseSpecification<Entities.EmpHistorialArea>
    {
        public EmpHistorialAreaSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderByDescending(x => x.DteFechaInicio);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public EmpHistorialAreaSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpHistorialArea, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return x => true;
            }

            if (!int.TryParse(search, out var searchId))
            {
                return x => false;
            }

            return x =>
                x.IdEmpEmpleado == searchId ||
                x.IdEmpCatAreaLaboral == searchId;
        }
    }
}