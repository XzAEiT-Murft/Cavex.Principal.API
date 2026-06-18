using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpHistorialArea
{
    public class EmpHistorialAreaCountSpecification : BaseSpecification<Entities.EmpHistorialArea>
    {
        public EmpHistorialAreaCountSpecification(string? search)
            : base(CreateCriteria(search))
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