namespace Cavex.Principal.Core.Specifications.VehDatosGenerales
{
    public class VehDatosGeneralesCountSpecification : BaseSpecification<Entities.VehDatosGenerales>
    {
        public VehDatosGeneralesCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumSerie.Contains(search) || x.StrModelo.Contains(search) || x.StrVersion.Contains(search) || x.StrPlaca.Contains(search))
        {
        }
    }
}
