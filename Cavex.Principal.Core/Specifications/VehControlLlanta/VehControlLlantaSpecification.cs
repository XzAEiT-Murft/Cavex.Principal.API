namespace Cavex.Principal.Core.Specifications.VehControlLlanta
{
    public class VehControlLlantaSpecification : BaseSpecification<Entities.VehControlLlanta>
    {
        public VehControlLlantaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrModelo.Contains(search) || x.StrMedida.Contains(search) || x.StrUrlEvidencia.Contains(search))
        {
            AddOrderBy(x => x.StrModelo);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehControlLlantaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
