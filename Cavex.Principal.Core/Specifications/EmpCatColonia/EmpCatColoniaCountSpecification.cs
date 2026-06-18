using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpCatColonia
{
    public class EmpCatColoniaCountSpecification : BaseSpecification<Entities.EmpCatColonia>
    {
        public EmpCatColoniaCountSpecification(string? search)
            : base(CreateCriteria(search))
        {
        }

        private static Expression<Func<Entities.EmpCatColonia, bool>> CreateCriteria(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return x => true;

            if (int.TryParse(search, out var searchId))
            {
                return x =>
                    x.Id == searchId ||
                    x.IntCodigoPostal == searchId ||
                    x.IntEmpCatMunicipio == searchId;
            }

            return x =>
                x.StrValor.Contains(search) ||
                x.StrTipoAsentamiento.Contains(search) ||
                (x.StrDescripcion != null && x.StrDescripcion.Contains(search));
        }
    }
}
