namespace Cavex.Principal.Core.Specifications.VehCatResponsableServicio
{
    public class VehCatResponsableServicioCountSpecification : BaseSpecification<Entities.VehCatResponsableServicio>
    {
        public VehCatResponsableServicioCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
