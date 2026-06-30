namespace Cavex.Principal.Core.Specifications.VehCatMarcaVehiculo
{
    public class VehCatMarcaVehiculoCountSpecification : BaseSpecification<Entities.VehCatMarcaVehiculo>
    {
        public VehCatMarcaVehiculoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
        }
    }
}
