namespace Cavex.Principal.Core.Specifications.VehControlGasolina
{
    public class VehControlGasolinaSpecification : BaseSpecification<Entities.VehControlGasolina>
    {
        public VehControlGasolinaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || (x.StrUrlComprobantePago != null && x.StrUrlComprobantePago.Contains(search)))
        {
            AddOrderBy(x => x.StrUrlComprobantePago);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehControlGasolinaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
