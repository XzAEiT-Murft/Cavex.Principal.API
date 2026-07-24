namespace Cavex.Principal.Core.Specifications.CatSucursales
{
    public class CatSucursalesCountSpecification : BaseSpecification<Entities.CatSucursales>
    {
        public CatSucursalesCountSpecification(string? search, int? status)
            : base(x => 
                (string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search)) &&
                (!status.HasValue || x.IdCatStatus == status.Value)) { }
    }
}
