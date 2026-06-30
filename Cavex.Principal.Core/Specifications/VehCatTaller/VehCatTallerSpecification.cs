namespace Cavex.Principal.Core.Specifications.VehCatTaller
{
    public class VehCatTallerSpecification : BaseSpecification<Entities.VehCatTaller>
    {
        public VehCatTallerSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTallerSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
