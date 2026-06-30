namespace Cavex.Principal.Core.Specifications.VehCatStatus
{
    public class VehCatStatusSpecification : BaseSpecification<Entities.VehCatStatus>
    {
        public VehCatStatusSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatStatusSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
