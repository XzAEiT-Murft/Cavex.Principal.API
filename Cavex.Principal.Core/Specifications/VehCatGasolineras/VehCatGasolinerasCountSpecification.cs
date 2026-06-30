namespace Cavex.Principal.Core.Specifications.VehCatGasolineras
{
    public class VehCatGasolinerasCountSpecification : BaseSpecification<Entities.VehCatGasolineras>
    {
        public VehCatGasolinerasCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
