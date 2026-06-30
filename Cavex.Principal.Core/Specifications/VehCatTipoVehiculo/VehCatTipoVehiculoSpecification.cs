namespace Cavex.Principal.Core.Specifications.VehCatTipoVehiculo
{
    public class VehCatTipoVehiculoSpecification : BaseSpecification<Entities.VehCatTipoVehiculo>
    {
        public VehCatTipoVehiculoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatTipoVehiculoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
