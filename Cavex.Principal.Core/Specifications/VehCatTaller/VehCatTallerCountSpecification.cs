namespace Cavex.Principal.Core.Specifications.VehCatTaller
{
    public class VehCatTallerCountSpecification : BaseSpecification<Entities.VehCatTaller>
    {
        public VehCatTallerCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
