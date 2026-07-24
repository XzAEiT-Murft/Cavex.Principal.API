namespace Cavex.Principal.Core.Specifications.CatServicios
{
    public class CatServiciosSpecification : BaseSpecification<Entities.CatServicios>
    {
        public CatServiciosSpecification(string? search, int? status, 
            int pageIndex, int pageSize) : base(x => 
                (string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search)) &&
                (!status.HasValue || x.IdCatStatus == status.Value))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public CatServiciosSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}