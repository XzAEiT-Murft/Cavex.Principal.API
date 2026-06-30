namespace Cavex.Principal.Core.Specifications.VehCatTipoServicio
{
    public class VehCatTipoServicioSpecification : BaseSpecification<Entities.VehCatTipoServicio>
    {
        public VehCatTipoServicioSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTipoServicioSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
