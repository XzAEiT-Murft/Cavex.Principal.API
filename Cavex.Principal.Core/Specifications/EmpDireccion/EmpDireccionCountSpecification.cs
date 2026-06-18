using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpDireccion
{
    public class EmpDireccionCountSpecification : BaseSpecification<Entities.EmpDireccion>
    {
        public EmpDireccionCountSpecification(string? search)
            : base(CreateCriteria(search))
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