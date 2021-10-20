using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Common.Dtos.KendoGrid
{
    public class GridState
    {
        public int skip { get; set; }
        public int take { get; set; }
        public HashSet<SortDescriptor> sort { get; set; }
        public Filter filter { get; set; }
    }
}
