namespace Cavex.Principal.Core.Specifications.VehCatTipoPermiso
{
    public class VehCatTipoPermisoSpecification : BaseSpecification<Entities.VehCatTipoPermiso>
    {
        public VehCatTipoPermisoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTipoPermisoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
