namespace Cavex.Principal.Core.Specifications.VehCatHolograma
{
    public class VehCatHologramaCountSpecification : BaseSpecification<Entities.VehCatHolograma>
    {
        public VehCatHologramaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
