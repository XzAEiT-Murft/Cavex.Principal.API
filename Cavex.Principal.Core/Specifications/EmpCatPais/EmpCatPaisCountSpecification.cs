namespace Cavex.Principal.Core.Specifications.EmpCatPais
{
    public class EmpCatPaisCountSpecification : BaseSpecification<Entities.EmpCatPais>
    {
        public EmpCatPaisCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
        }
    }
}