namespace Cavex.Principal.Core.Specifications.VehCatStatus
{
    public class VehCatStatusCountSpecification : BaseSpecification<Entities.VehCatStatus>
    {
        public VehCatStatusCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
