namespace Cavex.Principal.Core.Specifications.EmpCatEntidadFederativa
{
    public class EmpCatEntidadFederativaCountSpecification : BaseSpecification<Entities.EmpCatEntidadFederativa>
    {
        public EmpCatEntidadFederativaCountSpecification(string? search)
            : base(x => string.IsNullOrWhiteSpace(search) || x.StrValor.Contains(search))
        {
        }
    }
}