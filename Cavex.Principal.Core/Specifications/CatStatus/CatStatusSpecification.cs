namespace Cavex.Principal.Core.Specifications.CatStatus
{
    public class CatStatusSpecification : BaseSpecification<Entities.CatStatus>
    {
        public CatStatusSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public CatStatusSpecification(int id)
            : base(x => x.Id == id)
        {
        }
    }
}