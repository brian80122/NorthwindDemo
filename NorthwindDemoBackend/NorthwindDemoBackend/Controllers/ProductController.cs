using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NorthwindDemoBackend.Models;
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
        private readonly NorthwindContext _context;


        public ProductController(ILogger<ProductController> logger,
                                 NorthwindContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Get()
        {
            _logger.LogDebug("get");
            var product = _context.Products.FirstOrDefault();
            var response = JsonConvert.SerializeObject(product);
            return response;
        }
    }
}
