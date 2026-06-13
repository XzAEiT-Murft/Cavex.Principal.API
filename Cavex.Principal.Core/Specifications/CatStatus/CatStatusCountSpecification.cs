using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavex.Principal.Core.Specifications.CatStatus
{
    public class CatStatusCountSpecification : BaseSpecification<Entities.CatStatus>
    {
        public CatStatusCountSpecification(string? search)
            : base(x =>
                string.IsNullOrWhiteSpace(search) ||
                x.StrValor.Contains(search))
        {
        }
    }
}
