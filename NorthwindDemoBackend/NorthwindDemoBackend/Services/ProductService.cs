using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLog;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Models.ViewModels;
using NorthwindDemoBackend.Repositories;
using System;

namespace NorthwindDemoBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Products> _productsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;
        public ProductService(
                              IRepository<Products> productsRepository,
                              IMapper mapper,
                              ILogger<ProductService> logger
                             )
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
            _logger = logger;
        }
        bool IProductService.CreateProduct(ProductViewModel request)
        {
            try
            {
                var product = _mapper.Map<Products>(request);
                _productsRepository.Add(product);
                _productsRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return false;
            }

            return true;
        }
    }
}
