namespace Cavex.Principal.Core.Specifications.VehVerificacion
{
    public class VehVerificacionCountSpecification : BaseSpecification<Entities.VehVerificacion>
    {
        public VehVerificacionCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioVerificacion.Contains(search) || x.StrCentroVerificacion.Contains(search) || x.StrSemestre.Contains(search))
        {
        }
    }
}
