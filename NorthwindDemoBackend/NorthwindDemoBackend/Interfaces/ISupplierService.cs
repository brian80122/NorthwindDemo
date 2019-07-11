using NorthwindDemoBackend.Models.ViewModels;

namespace NorthwindDemoBackend.Interfaces
{
    public interface ISupplierService
    {
        SupplierViewModel GetSupplier(int supplierId);
    }
}
