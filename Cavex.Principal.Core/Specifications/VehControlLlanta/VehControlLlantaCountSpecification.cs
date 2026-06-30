namespace Cavex.Principal.Core.Specifications.VehControlLlanta
{
    public class VehControlLlantaCountSpecification : BaseSpecification<Entities.VehControlLlanta>
    {
        public VehControlLlantaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrModelo.Contains(search) || x.StrMedida.Contains(search) || x.StrUrlEvidencia.Contains(search))
        {
        }
    }
}
