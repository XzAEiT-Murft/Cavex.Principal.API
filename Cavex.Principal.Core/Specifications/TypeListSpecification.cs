
using Cavex.Principal.Core.Entities;

namespace Cavex.Principal.Core.Specifications
{
    public class TypeListSpecification : BaseSpecification<EmpCatPais, string>
    {
        public TypeListSpecification()
        {
            /*revisar el typespecification*/
            AddSelect(x => x.StrValor);
            ApplyDistinct();
        }

    }
}
