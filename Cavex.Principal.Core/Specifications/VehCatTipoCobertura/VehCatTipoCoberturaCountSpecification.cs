namespace Cavex.Principal.Core.Specifications.VehCatTipoCobertura
{
    public class VehCatTipoCoberturaCountSpecification : BaseSpecification<Entities.VehCatTipoCobertura>
    {
        public VehCatTipoCoberturaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
