namespace Cavex.Principal.Core.Specifications.VehInfracciones
{
    public class VehInfraccionesSpecification : BaseSpecification<Entities.VehInfracciones>
    {
        public VehInfraccionesSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrMotivo.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrObservaciones.Contains(search))
        {
            AddOrderBy(x => x.StrMotivo);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehInfraccionesSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
