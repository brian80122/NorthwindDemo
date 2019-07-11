using AutoMapper;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Models.ViewModels;
using NorthwindDemoBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Categories> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
                               IRepository<Categories> catrgoryRepository,
                               IMapper mapper
                              )
        {
            _categoryRepository = catrgoryRepository;
            _mapper = mapper;
        }

        public CategoryViewModel GetCategory(int categoryId)
        {
            var found = _categoryRepository.All()
                                           .FirstOrDefault(c => c.CategoryId == categoryId);

            return found == null ? null : _mapper.Map<CategoryViewModel>(found);
        }
    }
}
