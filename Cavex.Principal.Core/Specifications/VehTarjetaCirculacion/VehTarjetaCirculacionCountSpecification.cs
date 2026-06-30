namespace Cavex.Principal.Core.Specifications.VehTarjetaCirculacion
{
    public class VehTarjetaCirculacionCountSpecification : BaseSpecification<Entities.VehTarjetaCirculacion>
    {
        public VehTarjetaCirculacionCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrNumeroTarjeta.Contains(search) || x.StrUrlComprobantePago.Contains(search) || x.StrUrlTarjeta.Contains(search))
        {
        }
    }
}
