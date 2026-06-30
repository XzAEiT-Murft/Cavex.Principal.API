namespace Cavex.Principal.Core.Specifications.VehCatTipoPermiso
{
    public class VehCatTipoPermisoCountSpecification : BaseSpecification<Entities.VehCatTipoPermiso>
    {
        public VehCatTipoPermisoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
