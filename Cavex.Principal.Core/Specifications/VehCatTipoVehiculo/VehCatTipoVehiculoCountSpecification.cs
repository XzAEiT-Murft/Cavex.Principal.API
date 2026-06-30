namespace Cavex.Principal.Core.Specifications.VehCatTipoVehiculo
{
    public class VehCatTipoVehiculoCountSpecification : BaseSpecification<Entities.VehCatTipoVehiculo>
    {
        public VehCatTipoVehiculoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
