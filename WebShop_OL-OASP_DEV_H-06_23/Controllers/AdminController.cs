using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using System.Diagnostics;
using WebShop_OL_OASP_DEV_H_06_23.Models;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper mapper;

        public AdminController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            this.mapper = mapper;
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
