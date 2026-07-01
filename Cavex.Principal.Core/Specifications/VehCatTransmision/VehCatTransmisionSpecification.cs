namespace Cavex.Principal.Core.Specifications.VehCatTransmision
{
    /// <summary>
    /// Specification para consultar transmisiones vehiculares con busqueda y paginacion.
    /// </summary>
    public class VehCatTransmisionSpecification : BaseSpecification<Entities.VehCatTransmision>
    {
        public VehCatTransmisionSpecification(string? search, int pageIndex, int pageSize)
            : base(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.StrValor.Contains(search) ||
                (x.StrDescripcion != null && x.StrDescripcion.Contains(search)))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTransmisionSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
