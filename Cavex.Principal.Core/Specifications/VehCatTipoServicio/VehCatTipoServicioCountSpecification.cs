namespace Cavex.Principal.Core.Specifications.VehCatTipoServicio
{
    public class VehCatTipoServicioCountSpecification : BaseSpecification<Entities.VehCatTipoServicio>
    {
        public VehCatTipoServicioCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
