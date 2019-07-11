using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Models.ViewModels;

namespace NorthwindDemoBackend.Interfaces
{
    public interface ICategoryService
    {
        CategoryViewModel GetCategory(int categoryId);
    }
}
