namespace Cavex.Principal.Core.Specifications.VehCatTipoCobertura
{
    public class VehCatTipoCoberturaSpecification : BaseSpecification<Entities.VehCatTipoCobertura>
    {
        public VehCatTipoCoberturaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTipoCoberturaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
