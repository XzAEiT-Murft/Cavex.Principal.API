using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpReferenciasPersonales
{
    public class EmpReferenciasPersonalesCountSpecification : BaseSpecification<Entities.EmpReferenciasPersonales>
    {
        public EmpReferenciasPersonalesCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpReferenciasPersonales, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (long.TryParse(search, out var searchId))
            {
                return x =>
                    x.Id == searchId ||
                    x.IntTelefono == searchId ||
                    x.IdEmpEmpleado == searchId;
            }

            return x =>
                x.StrNombreCompleto.Contains(search) ||
                x.StrParentezco.Contains(search);
        }
    }
}
