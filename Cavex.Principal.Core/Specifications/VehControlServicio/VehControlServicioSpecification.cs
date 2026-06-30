namespace Cavex.Principal.Core.Specifications.VehControlServicio
{
    public class VehControlServicioSpecification : BaseSpecification<Entities.VehControlServicio>
    {
        public VehControlServicioSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrDescripcion.Contains(search) || x.StrUrlComprobantePago.Contains(search))
        {
            AddOrderBy(x => x.StrDescripcion);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehControlServicioSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
