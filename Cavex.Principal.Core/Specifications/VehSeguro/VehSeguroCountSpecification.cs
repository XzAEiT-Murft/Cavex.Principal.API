namespace Cavex.Principal.Core.Specifications.VehSeguro
{
    public class VehSeguroCountSpecification : BaseSpecification<Entities.VehSeguro>
    {
        public VehSeguroCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroPoliza.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPolizaSeguro.Contains(search))
        {
        }
    }
}
