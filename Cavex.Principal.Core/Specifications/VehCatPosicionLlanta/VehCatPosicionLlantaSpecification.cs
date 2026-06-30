namespace Cavex.Principal.Core.Specifications.VehCatPosicionLlanta
{
    public class VehCatPosicionLlantaSpecification : BaseSpecification<Entities.VehCatPosicionLlanta>
    {
        public VehCatPosicionLlantaSpecification(string? search, int pageIndex, int pageSize)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search) || x.StrDescripcion.Contains(search))
        {
            AddOrderBy(x => x.StrValor);

            var skip = (pageIndex - 1) * pageSize;

            ApplyPaging(skip, pageSize);
        }

        public VehCatPosicionLlantaSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
