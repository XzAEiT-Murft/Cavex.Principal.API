using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpCondicionesLaborales
{
    public class EmpCondicionesLaboralesSpecification : BaseSpecification<Entities.EmpCondicionesLaborales>
    {
        public EmpCondicionesLaboralesSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderByDescending(x => x.DteFechaIngreso);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public EmpCondicionesLaboralesSpecification(int id)
            : base(x => x.Id == id)
        {
        }

        private static Expression<Func<Entities.EmpCondicionesLaborales, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return x => true;
            }

            if (int.TryParse(search, out var searchId))
            {
                return x => x.Id == searchId;
            }

            if (bool.TryParse(search, out var searchBool))
            {
                return x =>
                    x.BitCercaniaVivienda == searchBool ||
                    x.BitDisponibilidadDeViaje == searchBool ||
                    x.BitExperienciaEnArea == searchBool ||
                    x.BitDisponibilidadCambioResidencia == searchBool;
            }

            return x => false;
        }
    }
}
