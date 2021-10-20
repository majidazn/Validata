using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Common.Dtos.KendoGrid
{
    public class GridDataResult<T>
    {
        public List<T> data { get; set; }
        public decimal total { get; set; }
        public T FilterObject { get; set; }
        public HashSet<string> VisibleColumns { get; set; }
        public GridState GridState { get; set; }
    }
}
