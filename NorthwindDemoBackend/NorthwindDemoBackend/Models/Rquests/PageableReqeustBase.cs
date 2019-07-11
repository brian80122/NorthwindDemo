using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Models.Rquests
{
    public class PageableReqeustBase
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
