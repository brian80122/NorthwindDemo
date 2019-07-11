using Microsoft.AspNetCore.Mvc;
using NLog;
using NorthwindDemoBackend.Interfaces;
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
        public bool CreateProduct([FromBody]ProductViewModel req)
        {
            return _productService.CreateProduct(req);
        }
    }
}
