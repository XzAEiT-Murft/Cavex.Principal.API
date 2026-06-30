namespace Cavex.Principal.Core.Specifications.VehTenencia
{
    public class VehTenenciaCountSpecification : BaseSpecification<Entities.VehTenencia>
    {
        public VehTenenciaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrFolioPago.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlFormatoTenencia.Contains(search))
        {
        }
    }
}
