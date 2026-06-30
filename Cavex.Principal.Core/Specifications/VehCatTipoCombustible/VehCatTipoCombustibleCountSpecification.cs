namespace Cavex.Principal.Core.Specifications.VehCatTipoCombustible
{
    public class VehCatTipoCombustibleCountSpecification : BaseSpecification<Entities.VehCatTipoCombustible>
    {
        public VehCatTipoCombustibleCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
