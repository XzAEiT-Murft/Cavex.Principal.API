namespace Cavex.Principal.Core.Specifications.VehCatFormaPago
{
    public class VehCatFormaPagoSpecification : BaseSpecification<Entities.VehCatFormaPago>
    {
        public VehCatFormaPagoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatFormaPagoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
