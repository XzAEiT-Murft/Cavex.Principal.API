namespace Cavex.Principal.Core.Specifications.VehInfracciones
{
    public class VehInfraccionesCountSpecification : BaseSpecification<Entities.VehInfracciones>
    {
        public VehInfraccionesCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrMotivo.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrObservaciones.Contains(search))
        {
        }
    }
}
