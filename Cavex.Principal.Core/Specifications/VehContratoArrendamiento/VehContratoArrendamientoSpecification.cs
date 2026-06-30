namespace Cavex.Principal.Core.Specifications.VehContratoArrendamiento
{
    public class VehContratoArrendamientoSpecification : BaseSpecification<Entities.VehContratoArrendamiento>
    {
        public VehContratoArrendamientoSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroContrato.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrPeriodoPago.Contains(search) || x.StrUrlContratoArrendamiento.Contains(search))
        {
            AddOrderBy(x => x.StrNumeroContrato);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehContratoArrendamientoSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
