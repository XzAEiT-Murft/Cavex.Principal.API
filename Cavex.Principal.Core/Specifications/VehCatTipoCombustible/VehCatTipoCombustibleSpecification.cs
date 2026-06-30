namespace Cavex.Principal.Core.Specifications.VehCatTipoCombustible
{
    public class VehCatTipoCombustibleSpecification : BaseSpecification<Entities.VehCatTipoCombustible>
    {
        public VehCatTipoCombustibleSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTipoCombustibleSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
