namespace Cavex.Principal.Core.Specifications.VehCatArrendatario
{
    public class VehCatArrendatarioSpecification : BaseSpecification<Entities.VehCatArrendatario>
    {
        public VehCatArrendatarioSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatArrendatarioSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
