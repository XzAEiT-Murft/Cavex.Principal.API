namespace Cavex.Principal.Core.Specifications.VehControlServicio
{
    public class VehControlServicioCountSpecification : BaseSpecification<Entities.VehControlServicio>
    {
        public VehControlServicioCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) ||
                       (x.StrDescripcion != null && x.StrDescripcion.Contains(search)) ||
                       (x.VehServicioDetalle != null && x.VehServicioDetalle.StrUrlComprobantePago != null && x.VehServicioDetalle.StrUrlComprobantePago.Contains(search)) ||
                       (x.VehServicioDetalle != null && x.VehServicioDetalle.StrDescripcion != null && x.VehServicioDetalle.StrDescripcion.Contains(search)))
        {
        }
    }
}
