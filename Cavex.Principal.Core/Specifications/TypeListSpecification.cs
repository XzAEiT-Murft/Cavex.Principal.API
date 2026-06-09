using Cavex.

using Cavex.Principal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Specifications
{
    public class TypeListSpecification : BaseSpecification<EmpCatPais, string>
    {
        public TypeListSpecification()
        {
            AddSelect(x => x.Type);
            ApplyDistinct();
        }

    }
}
