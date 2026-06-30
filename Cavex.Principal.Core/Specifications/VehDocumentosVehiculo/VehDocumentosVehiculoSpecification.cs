namespace Cavex.Principal.Core.Specifications.VehDocumentosVehiculo
{
    public class VehDocumentosVehiculoSpecification : BaseSpecification<Entities.VehDocumentosVehiculo>
    {
        public VehDocumentosVehiculoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrUrlFactura.Contains(search))
        {
            AddOrderBy(x => x.StrUrlFactura);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehDocumentosVehiculoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
