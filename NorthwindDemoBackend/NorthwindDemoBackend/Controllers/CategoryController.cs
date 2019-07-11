using Microsoft.AspNetCore.Mvc;
using NorthwindDemoBackend.Interfaces;
using NorthwindDemoBackend.Models.ViewModels;

namespace NorthwindDemoBackend.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost,Route("Get")]
        public CategoryViewModel Get(int categoryId)
        {
            return _categoryService.GetCategory(categoryId);
        }
    }
}
