namespace Cavex.Principal.Core.Specifications.VehCatAseguradora
{
    public class VehCatAseguradoraCountSpecification : BaseSpecification<Entities.VehCatAseguradora>
    {
        public VehCatAseguradoraCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
