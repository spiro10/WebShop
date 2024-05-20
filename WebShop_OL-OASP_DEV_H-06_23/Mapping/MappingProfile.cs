using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AddressBinding, Address>();
            CreateMap<AddressViewModel, AddressUpdateBinding>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Address, AddressUpdateBinding>();

            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyUpdateBinding, Company>();

            
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategoryViewModel, ProductCategoryUpdateBinding>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();

            CreateMap<ProductItem, ProductItemViewModel>();
            CreateMap<ProductItemBinding, ProductItem>();
            CreateMap<ProductItemUpdateBinding, ProductItem>();
            CreateMap<ProductItemViewModel, ProductItemUpdateBinding>();


            CreateMap<CompanyViewModel, CompanyUpdateBinding>();
            CreateMap<ApplicationUser, ApplicationUserViewModel>();


            CreateMap<OrderBinding, Order>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItemBinding, OrderItem>();
            CreateMap<OrderItem, OrderItemViewModel>();
            CreateMap<OrderItemUpdateBinding, OrderItem>();
            CreateMap<OrderUpdateBinding, Order>();

        }
    }
}
