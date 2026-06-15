namespace Cavex.Principal.Core.Specifications.EmpCatAreaLaboral
{
    public class EmpCatAreaLaboralSpecification : BaseSpecification<Entities.EmpCatAreaLaboral>
    {
        public EmpCatAreaLaboralSpecification(string? search,
            int pageIndex,int pageSize) : base(x=> string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }
        public EmpCatAreaLaboralSpecification(int id): base(x => x.Id == id)
        {
        }
    }
}
