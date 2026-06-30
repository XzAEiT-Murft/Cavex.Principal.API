namespace Cavex.Principal.Core.Specifications.VehPermisoTransporte
{
    public class VehPermisoTransporteCountSpecification : BaseSpecification<Entities.VehPermisoTransporte>
    {
        public VehPermisoTransporteCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroPermiso.Contains(search) || x.StrAutoridad.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPermisoTransporte.Contains(search))
        {
        }
    }
}
