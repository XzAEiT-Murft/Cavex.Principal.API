namespace Cavex.Principal.Core.Specifications.VehCatAseguradora
{
    public class VehCatAseguradoraSpecification : BaseSpecification<Entities.VehCatAseguradora>
    {
        public VehCatAseguradoraSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatAseguradoraSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
