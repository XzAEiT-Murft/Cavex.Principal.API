namespace Cavex.Principal.Core.Specifications.VehControlServicio
{
    public class VehControlServicioSpecification : BaseSpecification<Entities.VehControlServicio>
    {
        public VehControlServicioSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) ||
                       (x.StrDescripcion != null && x.StrDescripcion.Contains(search)) ||
                       (x.VehServicioDetalle != null && x.VehServicioDetalle.StrUrlComprobantePago != null && x.VehServicioDetalle.StrUrlComprobantePago.Contains(search)) ||
                       (x.VehServicioDetalle != null && x.VehServicioDetalle.StrDescripcion != null && x.VehServicioDetalle.StrDescripcion.Contains(search)))
        {
            AddInclude(x => x.VehServicioDetalle!);
            AddOrderByDescending(x => x.DteFechaInicio);

            var skip = (pageIndex - 1) * pageSize;
            ApplyPaging(skip, pageSize);
        }

        public VehControlServicioSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.VehServicioDetalle!);
        }
    }
}
