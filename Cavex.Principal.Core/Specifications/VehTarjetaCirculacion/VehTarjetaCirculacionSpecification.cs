namespace Cavex.Principal.Core.Specifications.VehTarjetaCirculacion
{
    public class VehTarjetaCirculacionSpecification : BaseSpecification<Entities.VehTarjetaCirculacion>
    {
        public VehTarjetaCirculacionSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroTarjeta.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlTarjeta.Contains(search))
        {
            AddOrderBy(x => x.StrNumeroTarjeta);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehTarjetaCirculacionSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
