namespace Cavex.Principal.Core.Specifications.VehDocumentosVehiculo
{
    public class VehDocumentosVehiculoCountSpecification : BaseSpecification<Entities.VehDocumentosVehiculo>
    {
        public VehDocumentosVehiculoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrUrlFactura.Contains(search))
        {
        }
    }
}
