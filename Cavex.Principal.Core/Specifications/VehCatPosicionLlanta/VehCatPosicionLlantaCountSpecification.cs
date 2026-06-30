namespace Cavex.Principal.Core.Specifications.VehCatPosicionLlanta
{
    public class VehCatPosicionLlantaCountSpecification : BaseSpecification<Entities.VehCatPosicionLlanta>
    {
        public VehCatPosicionLlantaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
