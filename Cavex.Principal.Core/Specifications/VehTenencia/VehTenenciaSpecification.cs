namespace Cavex.Principal.Core.Specifications.VehTenencia
{
    public class VehTenenciaSpecification : BaseSpecification<Entities.VehTenencia>
    {
        public VehTenenciaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioPago.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlFormatoTenencia.Contains(search))
        {
            AddOrderBy(x => x.StrFolioPago);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehTenenciaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
