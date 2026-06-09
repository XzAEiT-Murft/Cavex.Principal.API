using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.Core.Specifications
{
    public class EmpCatPaisSpecification: BaseSpecification<EmpCatPais>
    {
        public EmpCatPaisSpecification(string? brand, string? type, string sort): base(x=> (string.IsNullOrWhiteSpace(brand) || x.Brand==brand)
        &&(string.IsNullOrWhiteSpace(type) || x.GetType==type))
        {
            switch (sort)
            {
                case ""
            }
        }
    }
}
