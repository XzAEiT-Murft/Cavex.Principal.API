namespace Cavex.Principal.Core.Specifications.VehSeguro
{
    public class VehSeguroSpecification : BaseSpecification<Entities.VehSeguro>
    {
        public VehSeguroSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroPoliza.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPolizaSeguro.Contains(search))
        {
            AddOrderBy(x => x.StrNumeroPoliza);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehSeguroSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
