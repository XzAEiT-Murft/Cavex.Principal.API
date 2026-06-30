namespace Cavex.Principal.Core.Specifications.VehCatMarcaLlanta
{
    public class VehCatMarcaLlantaSpecification : BaseSpecification<Entities.VehCatMarcaLlanta>
    {
        public VehCatMarcaLlantaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatMarcaLlantaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
