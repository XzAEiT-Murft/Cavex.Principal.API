namespace Cavex.Principal.Core.Specifications.VehCatMarcaVehiculo
{
    public class VehCatMarcaVehiculoSpecification : BaseSpecification<Entities.VehCatMarcaVehiculo>
    {
        public VehCatMarcaVehiculoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatMarcaVehiculoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
