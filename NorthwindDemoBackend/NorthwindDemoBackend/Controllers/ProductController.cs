using Microsoft.AspNetCore.Mvc;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models.Responses;
using NorthwindDemoBackend.Models.Rquests;
using NorthwindDemoBackend.Models.ViewModels;

namespace NorthwindDemoBackend.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(
                                 IProductService productService
                                )
        {
            _productService = productService;
        }

        [HttpPost, Route("Create")]
        public bool CreateProduct(ProductViewModel req)
        {
            return _productService.CreateProduct(req);
        }

        [HttpPost, Route("Find")]
        public GetProductsResponse FindProducts(FindProductsRequest req)
        {
            return _productService.FindProducts(req);
        }

        [HttpPost, Route("Update")]
        public bool UpdateProduct(ProductViewModel req)
        {
            return _productService.UpdateProduct(req);
        }

        [HttpPost, Route("Delete")]
        public bool DeleteProduct(DeleteProductRequest req)
        {
            return _productService.DeleteProduct(req);
        }
    }
}
