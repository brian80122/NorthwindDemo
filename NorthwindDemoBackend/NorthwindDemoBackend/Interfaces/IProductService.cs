using NorthwindDemoBackend.Models.Responses;
using NorthwindDemoBackend.Models.Rquests;
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
        GetProductsResponse FindProducts(FindProductsRequest request);
        bool UpdateProduct(ProductViewModel request);
        bool DeleteProduct(DeleteProductRequest request);
    }
}
