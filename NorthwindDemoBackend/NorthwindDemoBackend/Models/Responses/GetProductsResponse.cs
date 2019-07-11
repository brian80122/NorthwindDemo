using NorthwindDemoBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Models.Responses
{
    public class GetProductsResponse
    {
        public List<ProductViewModel> Products { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
