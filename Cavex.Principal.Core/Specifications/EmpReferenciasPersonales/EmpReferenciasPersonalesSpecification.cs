using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpReferenciasPersonales
{
    public class EmpReferenciasPersonalesSpecification : BaseSpecification<Entities.EmpReferenciasPersonales>
    {
        public EmpReferenciasPersonalesSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.StrNombreCompleto);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpReferenciasPersonalesSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpReferenciasPersonales, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
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
