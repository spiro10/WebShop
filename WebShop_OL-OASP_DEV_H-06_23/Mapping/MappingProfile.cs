﻿using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AddressBinding, Address>();
            CreateMap<AddressUpdateBinding, Address>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyUpdateBinding, Company>();

            
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<ProductCategoryBinding, ProductCategory>();
            CreateMap<ProductCategoryUpdateBinding, ProductCategory>();
            CreateMap<ProductItem, ProductItemViewModel>();
            CreateMap<ProductItemBinding, ProductItem>();
            CreateMap<ProductItemUpdateBinding, ProductItem>();
            CreateMap<ProductItemViewModel, ProductItemUpdateBinding>();
        }
    }
}