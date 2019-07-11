using NorthwindDemoBackend.Models;
using NorthwindDemoBackend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Interfaces
{
    public interface IProductsRepository : IRepository<Products>
    {
    }
}
