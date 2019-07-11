using AutoMapper;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Models.ViewModels;
using NorthwindDemoBackend.Repositories;
using System.Linq;

namespace NorthwindDemoBackend.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<Suppliers> _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierService(
                               IRepository<Suppliers> supperlierRepository,
                               IMapper mapper
                              )
        {
            _supplierRepository = supperlierRepository;
            _mapper = mapper;
        }

        public SupplierViewModel GetSupplier(int supplierId)
        {
            var found = _supplierRepository.All()
                                           .FirstOrDefault(c => c.SupplierId == supplierId);
            return found == null ? null : _mapper.Map<SupplierViewModel>(found);
        }
    }
}
