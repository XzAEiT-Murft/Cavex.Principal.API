using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpTelefono
{
    public class EmpTelefonoSpecification : BaseSpecification<Entities.EmpTelefono>
    {
        public EmpTelefonoSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.Id);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpTelefonoSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpTelefono, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
                return x => x.IdEmpEmpleado == searchId || x.Id == searchId;

            return x =>
                x.StrNumeroFijo.Contains(search) ||
                (x.StrNumeroCelular != null && x.StrNumeroCelular.Contains(search));
        }
    }
}