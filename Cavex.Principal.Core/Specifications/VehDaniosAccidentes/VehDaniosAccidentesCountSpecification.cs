namespace Cavex.Principal.Core.Specifications.VehDaniosAccidentes
{
    public class VehDaniosAccidentesCountSpecification : BaseSpecification<Entities.VehDaniosAccidentes>
    {
        public VehDaniosAccidentesCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrDescripcion.Contains(search) || x.StrUbicacion.Contains(search) || x.StrUrlEvidencia.Contains(search) || x.StrObservaciones.Contains(search))
        {
        }
    }
}
