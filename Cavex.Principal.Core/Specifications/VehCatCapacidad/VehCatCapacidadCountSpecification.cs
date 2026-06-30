namespace Cavex.Principal.Core.Specifications.VehCatCapacidad
{
    public class VehCatCapacidadCountSpecification : BaseSpecification<Entities.VehCatCapacidad>
    {
        public VehCatCapacidadCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
