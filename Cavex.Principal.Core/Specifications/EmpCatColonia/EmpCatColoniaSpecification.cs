using System.Linq.Expressions;

namespace Cavex.Principal.Core.Specifications.EmpCatColonia
{
    public class EmpCatColoniaSpecification : BaseSpecification<Entities.EmpCatColonia>
    {
        public EmpCatColoniaSpecification(string? search, int pageIndex, int pageSize)
            : base(CreateCriteria(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public EmpCatColoniaSpecification(int id)
            : base(x => x.Id == id)
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
