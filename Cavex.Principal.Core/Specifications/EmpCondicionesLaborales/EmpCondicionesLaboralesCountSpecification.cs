using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Specifications.EmpCondicionesLaborales
{
    public class EmpCondicionesLaboralesCountSpecification : BaseSpecification<Entities.EmpCondicionesLaborales>
    {
        public EmpCondicionesLaboralesCountSpecification(string? search)
            : base(CreateCriteria(search))
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
