using NorthwindDemoBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Interfaces
{
    public interface IProductService
    {
        bool CreateProduct(ProductViewModel request);
    }
}
