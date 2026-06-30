namespace Cavex.Principal.Core.Specifications.VehCatColor
{
    public class VehCatColorCountSpecification : BaseSpecification<Entities.VehCatColor>
    {
        public VehCatColorCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
