namespace Cavex.Principal.Core.Specifications.VehControlServicio
{
    public class VehControlServicioCountSpecification : BaseSpecification<Entities.VehControlServicio>
    {
        public VehControlServicioCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrDescripcion.Contains(search) || x.StrUrlComprobantePago.Contains(search))
        {
        }
    }
}
