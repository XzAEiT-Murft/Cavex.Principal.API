namespace Cavex.Principal.Core.Specifications.VehRevistaVehicular
{
    public class VehRevistaVehicularCountSpecification : BaseSpecification<Entities.VehRevistaVehicular>
    {
        public VehRevistaVehicularCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioRevista.Contains(search) || x.StrResultado.Contains(search) || x.StrInspector.Contains(search) || x.StrUrlComprobantePago.Contains(search))
        {
        }
    }
}
