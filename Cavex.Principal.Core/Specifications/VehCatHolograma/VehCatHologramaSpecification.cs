namespace Cavex.Principal.Core.Specifications.VehCatHolograma
{
    public class VehCatHologramaSpecification : BaseSpecification<Entities.VehCatHolograma>
    {
        public VehCatHologramaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatHologramaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
