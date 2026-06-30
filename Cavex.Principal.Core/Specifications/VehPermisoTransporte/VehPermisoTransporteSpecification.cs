namespace Cavex.Principal.Core.Specifications.VehPermisoTransporte
{
    public class VehPermisoTransporteSpecification : BaseSpecification<Entities.VehPermisoTransporte>
    {
        public VehPermisoTransporteSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroPermiso.Contains(search) || x.StrAutoridad.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlPermisoTransporte.Contains(search))
        {
            AddOrderBy(x => x.StrNumeroPermiso);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehPermisoTransporteSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
