using AutoMapper;
using NorthwindDemoBackend.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindDemoBackend.Models.AutoMapperProfile
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Suppliers, SupplierViewModel>();
        }
    }
}
