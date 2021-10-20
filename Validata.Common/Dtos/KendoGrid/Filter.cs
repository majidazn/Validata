using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Common.Dtos.KendoGrid
{
    public class Filter
    {
        public HashSet<FilterItems> filters { get; set; }
        public string logic { get; set; }
    }
}
