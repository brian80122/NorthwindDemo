using Microsoft.AspNetCore.Mvc;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models.ViewModels;

namespace NorthwindDemoBackend.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpPost, Route("Get")]
        public SupplierViewModel Get(int supplierId)
        {
            return _supplierService.GetSupplier(supplierId);
        }
    }
}
