using Cavex.Principal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Specifications
{
    public class BrandListSpecification: BaseSpecification<EmpCatPais, string>
    {
        public BrandListSpecification() 
        {
            AddSelect(x => x.Brand);
            ApplyDistinct();
        }
    }
}
