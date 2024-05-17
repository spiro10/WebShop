using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IProductService productService;
        private readonly ICommonService commonService;
        private readonly IMapper mapper;

        public BuyerController(IProductService productService, ICommonService commonService)
        {
            this.productService = productService;
            this.commonService = commonService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await productService.GetProductCategories();
            return View(response);
        }

        public async Task<IActionResult> AddressEdit(long id)
        {
            //AddressUpdateBinding response = new AddressUpdateBinding { Id = id };
            var vm = await commonService.GetAddress(id);
            //if (mapper.Map<AddressUpdateBinding>(vm) != null)
            //{
            //    return View(mapper.Map<AddressUpdateBinding>(vm));
            //}
            return View(mapper.Map<AddressUpdateBinding>(vm));
        }
        [HttpPost]
        public async Task<IActionResult> AddressEdit(AddressUpdateBinding model)
        {
            await commonService.UpdateAddress(model);
            return RedirectToAction("Index", "Home");
        }

    }
}
