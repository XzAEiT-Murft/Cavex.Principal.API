namespace Cavex.Principal.Core.Specifications.EmpCatEntidadFederativa
{
    public class EmpCatEntidadFederativaSpecification : BaseSpecification<Entities.EmpCatEntidadFederativa>
    {
        public EmpCatEntidadFederativaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public EmpCatEntidadFederativaSpecification(int id)
            : base(x => x.Id == id)
        {
        }
    }
}