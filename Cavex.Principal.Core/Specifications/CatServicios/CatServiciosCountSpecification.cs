namespace Cavex.Principal.Core.Specifications.CatServicios
{
    public class CatServiciosCountSpecification : BaseSpecification<Entities.CatServicios>
    {
        public CatServiciosCountSpecification(string? search)
            : base(x => 
                string.IsNullOrWhiteSpace(search) || 
                x.StrValor.Contains(search))
        {
        }
    }
}
