using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpTelefono
{
    public class EmpTelefonoCountSpecification : BaseSpecification<Entities.EmpTelefono>
    {
        public EmpTelefonoCountSpecification(string? search)
            : base(CreateCriteria(search))
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