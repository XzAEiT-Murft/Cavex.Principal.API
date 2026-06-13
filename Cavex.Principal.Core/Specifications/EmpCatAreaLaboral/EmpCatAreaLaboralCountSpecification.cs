namespace Cavex.Principal.Core.Specifications.EmpCatAreaLaboral
{

    public class EmpCatAreaLaboralCountSpecification : BaseSpecification<Entities.EmpCatAreaLaboral>
    {
        public EmpCatAreaLaboralCountSpecification(string? search)
            : base(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.StrValor.Contains(search))
        {
        }
    }
}

