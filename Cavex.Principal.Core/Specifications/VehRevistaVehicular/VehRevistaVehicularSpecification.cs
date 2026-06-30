namespace Cavex.Principal.Core.Specifications.VehRevistaVehicular
{
    public class VehRevistaVehicularSpecification : BaseSpecification<Entities.VehRevistaVehicular>
    {
        public VehRevistaVehicularSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioRevista.Contains(search) || x.StrResultado.Contains(search) || x.StrInspector.Contains(search) || x.StrUrlComprobantePago.Contains(search))
        {
            AddOrderBy(x => x.StrFolioRevista);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehRevistaVehicularSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
