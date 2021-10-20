using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validata.Common.Dtos.KendoGrid
{
    public class SortDescriptor
    {
        public string field { get; set; }

        public string dir { get; set; } = "asc";
    }
}
