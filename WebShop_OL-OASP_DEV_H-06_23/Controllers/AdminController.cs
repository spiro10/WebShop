using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using System.Diagnostics;
using WebShop_OL_OASP_DEV_H_06_23.Models;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAdminService adminService;
        private readonly IMapper mapper;

        public AdminController(IProductService productService, IMapper mapper, IAdminService adminService)
        {
            _productService = productService;
            this.mapper = mapper;
            this.adminService = adminService;
        }

        public async Task<IActionResult> Company()
        {
            var response = await adminService.GetCompany();
            return View(response);
        }

        public async Task<IActionResult> CompanyEdit()
        {
            var vm = await adminService.GetCompany();
            var binding = mapper.Map<CompanyUpdateBinding>(vm);
            
            return View(binding);
        }

        [HttpPost]
        public async Task<IActionResult> CompanyEdit(CompanyUpdateBinding model)
        {
            await adminService.UpdateCompany(model);
            return RedirectToAction("Company", "Admin");
        }

        public async Task<IActionResult> Index()
        {
            var productCategories = await _productService.GetProductCategories();
            return View(productCategories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryBinding model)
        {
            await _productService.AddProductCategory(model);
            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(long id)
        {
            var productCategory = await _productService.GetProductCategory(id);
            return View(productCategory);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var vm = await _productService.GetProductCategory(id);
            var binding = mapper.Map<ProductCategoryUpdateBinding>(vm);
            return View(binding);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductCategoryUpdateBinding model)
        {
            await _productService.UpdateProductCategory(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _productService.DeleteProductCategory(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddProductItem(long categoryId)
        {
            var productItem = new ProductItemBinding
            {
                ProductCategoryId = categoryId
            };
            return View(productItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductItem(ProductItemBinding model)
        {
            await _productService.AddProductItem(model);
            return RedirectToAction("Details", new {id = model.ProductCategoryId});
        }

        public async Task<IActionResult> EditProductItem(long id)
        {
            var vm = await _productService.GetProductItem(id);
            var model = mapper.Map<ProductItemUpdateBinding>(vm);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProductItem(ProductItemUpdateBinding model)
        {
            await _productService.UpdateProductItem(model);
            return RedirectToAction("Details", new { id = model.ProductCategoryId});
        }
        [AllowAnonymous]
        public async Task<IActionResult> DetailsProductItem(long id)
        {
            var productItem = await _productService.GetProductItem(id);
            return View(productItem);
        }

        public async Task<IActionResult> DeleteProductItem(long id)
        {
            await _productService.DeleteProductItem(id);
            var productItem = await _productService.GetProductItem(id);
            return RedirectToAction("Details", new { id = productItem.ProductCategoryId });
        }

    }
}
