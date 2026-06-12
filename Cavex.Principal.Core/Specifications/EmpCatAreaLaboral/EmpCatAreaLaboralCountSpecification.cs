using Cavex.Principal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

