using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpExperiencia
{
    public class EmpExperienciaCountSpecification : BaseSpecification<Entities.EmpExperiencia>
    {
        public EmpExperienciaCountSpecification(string? search)
            : base(CreateCriteria(search))
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