using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpExperiencia
{
    public class EmpExperienciaSpecification : BaseSpecification<Entities.EmpExperiencia>
    {
        public EmpExperienciaSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderByDescending(x => x.DteFechaIncio);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpExperienciaSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpExperiencia, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
                return x => x.IdEmpEmpleado == searchId;

            return x =>
                x.StrEmpresa.Contains(search) ||
                x.StrPuesto.Contains(search) ||
                x.StrArea.Contains(search) ||
                x.StrMotivoSalida.Contains(search);
        }
    }
}