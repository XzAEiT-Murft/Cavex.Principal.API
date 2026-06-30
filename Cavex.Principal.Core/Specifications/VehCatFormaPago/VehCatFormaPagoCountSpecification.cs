namespace Cavex.Principal.Core.Specifications.VehCatFormaPago
{
    public class VehCatFormaPagoCountSpecification : BaseSpecification<Entities.VehCatFormaPago>
    {
        public VehCatFormaPagoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
