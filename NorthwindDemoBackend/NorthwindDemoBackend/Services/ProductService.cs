using AutoMapper;
using Microsoft.Extensions.Logging;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Models.Responses;
using NorthwindDemoBackend.Models.Rquests;
using NorthwindDemoBackend.Models.ViewModels;
using NorthwindDemoBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public GetProductsResponse FindProducts(FindProductsRequest request)
        {
            var response = new GetProductsResponse();
            var querable = _productsRepository.All();

            //filter here

            response.TotalCount = querable.Count();
            response.Products = _mapper.Map<List<ProductViewModel>>(querable.Skip(request.PageSize * (request.PageIndex - 1))
                                                                            .Take(request.PageSize)
                                                                            .ToList());
            response.PageIndex = request.PageIndex;
            response.TotalPages = (int)Math.Ceiling(response.TotalCount / (decimal)request.PageSize);

            return response;
        }

        public bool UpdateProduct(ProductViewModel request)
        {
            var found = GetProduct(request.ProductId);
            if (found == null)
            {
                return false;
            }

            try
            {
                _mapper.Map(request, found);
                _productsRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return false;
            }

            return true;
        }

        public bool DeleteProduct(DeleteProductRequest request)
        {
            var found = GetProduct(request.ProductId);
            if (found == null)
            {
                return false;
            }

            try
            {
                _productsRepository.Delete(found);
                _productsRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return false;
            }

            return true;
        }

        private Products GetProduct(int productId)
        {
            return _productsRepository.All()
                                      .FirstOrDefault(c => c.ProductId == productId);
        }
    }
}
