namespace Cavex.Principal.Core.Specifications.CatSucursales
{
    public class CatSucursalesSpecification : BaseSpecification<Entities.CatSucursales>
    {
        public CatSucursalesSpecification(string? search, int? status, int pageIndex, int pageSize)
            : base(x => 
                (string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search)) &&
                (!status.HasValue || x.IdCatStatus == status.Value))
        {
            AddOrderBy(x => x.StrValor);
            ApplyPaging((pageIndex - 1) * pageSize, pageSize);
        }

        public CatSucursalesSpecification(int id) : base(x => x.Id == id) { }
    }
}