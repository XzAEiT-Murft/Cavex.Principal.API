namespace Cavex.Principal.Core.Specifications.VehCatMarcaLlanta
{
    public class VehCatMarcaLlantaCountSpecification : BaseSpecification<Entities.VehCatMarcaLlanta>
    {
        public VehCatMarcaLlantaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
