namespace Cavex.Principal.Core.Specifications.VehContratoArrendamiento
{
    public class VehContratoArrendamientoCountSpecification : BaseSpecification<Entities.VehContratoArrendamiento>
    {
        public VehContratoArrendamientoCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroContrato.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrPeriodoPago.Contains(search) || x.StrUrlContratoArrendamiento.Contains(search))
        {
        }
    }
}
