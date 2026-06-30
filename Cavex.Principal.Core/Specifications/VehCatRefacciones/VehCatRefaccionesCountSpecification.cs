namespace Cavex.Principal.Core.Specifications.VehCatRefacciones
{
    public class VehCatRefaccionesCountSpecification : BaseSpecification<Entities.VehCatRefacciones>
    {
        public VehCatRefaccionesCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
