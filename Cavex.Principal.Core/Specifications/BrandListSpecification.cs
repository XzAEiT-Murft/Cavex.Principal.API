using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.Core.Specifications
{
    public class BrandListSpecification: BaseSpecification<EmpCatPais, string>
    {
        public BrandListSpecification() 
        {
            AddSelect(x => x.StrValor);
            ApplyDistinct();
        }
    }
}
