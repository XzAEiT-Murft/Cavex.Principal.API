namespace Cavex.Principal.Core.Specifications.VehPlacas
{
    public class VehPlacasSpecification : BaseSpecification<Entities.VehPlacas>
    {
        public VehPlacasSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumPlaca.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPlacas.Contains(search))
        {
            AddOrderBy(x => x.StrNumPlaca);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehPlacasSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
