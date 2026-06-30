namespace Cavex.Principal.Core.Specifications.VehCatArrendatario
{
    public class VehCatArrendatarioCountSpecification : BaseSpecification<Entities.VehCatArrendatario>
    {
        public VehCatArrendatarioCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
