using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IRepository<Products> _productsRepository;


        public ProductController(
                                 ILogger<ProductController> logger,
                                 IRepository<Products> productsRepository
                                )
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        public string Get()
        {
            _logger.LogDebug("get");
            var product = _productsRepository.All()
                                             .FirstOrDefault();
            var response = JsonConvert.SerializeObject(product);
            return response;
        }
    }
}
