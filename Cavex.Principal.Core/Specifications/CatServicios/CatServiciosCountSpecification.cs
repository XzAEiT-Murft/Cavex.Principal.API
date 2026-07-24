namespace Cavex.Principal.Core.Specifications.CatServicios
{
    public class CatServiciosCountSpecification : BaseSpecification<Entities.CatServicios>
    {
        public CatServiciosCountSpecification(string? search, int? status)
            : base(x => 
                (string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search)) &&
                (!status.HasValue || x.IdCatStatus == status.Value))
        {
        }
    }
}
