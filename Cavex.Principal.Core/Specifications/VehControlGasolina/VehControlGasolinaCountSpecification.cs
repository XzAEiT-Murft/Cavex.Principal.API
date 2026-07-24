namespace Cavex.Principal.Core.Specifications.VehControlGasolina
{
    public class VehControlGasolinaCountSpecification : BaseSpecification<Entities.VehControlGasolina>
    {
        public VehControlGasolinaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || (x.StrUrlComprobantePago != null && x.StrUrlComprobantePago.Contains(search)))
        {
        }
    }
}
