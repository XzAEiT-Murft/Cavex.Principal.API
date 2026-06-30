namespace Cavex.Principal.Core.Specifications.VehPlacas
{
    public class VehPlacasCountSpecification : BaseSpecification<Entities.VehPlacas>
    {
        public VehPlacasCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumPlaca.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPlacas.Contains(search))
        {
        }
    }
}
