namespace Cavex.Principal.Core.Specifications.EmpCatPais
{
    public class EmpCatPaisSpecification : BaseSpecification<Entities.EmpCatPais>
    {
        public EmpCatPaisSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public EmpCatPaisSpecification(int id)
            : base(x => x.Id == id)
        {
        }
    }
}