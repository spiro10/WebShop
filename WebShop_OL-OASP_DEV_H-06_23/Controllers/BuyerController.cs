using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
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
        private readonly IBuyerService buyerService;

        public BuyerController(IProductService productService, ICommonService commonService, IBuyerService buyerService)
        {
            this.productService = productService;
            this.commonService = commonService;
            this.buyerService = buyerService;
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
            return View(vm); // Ispraviti ovo nesto ne valja
        }
        [HttpPost]
        public async Task<IActionResult> AddressEdit(AddressUpdateBinding model)
        {
            await commonService.UpdateAddress(model);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Details(long id)
        {
            var response = await productService.GetProductCategory(id);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Order(OrderBinding model)
        {
            await buyerService.Order(model, User);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrderItem([FromBody] List<OrderItemBinding> orderItems)
        {
            var sessionOrderItems = HttpContext.Session.GetString("OrderItems");
            List<OrderItemBinding> existingOrderItems = sessionOrderItems != null
                ? JsonConvert.DeserializeObject<List<OrderItemBinding>>(sessionOrderItems)
                : new List<OrderItemBinding>();

            foreach(var orderItem in orderItems)
            {
                var existingItem = existingOrderItems.Find(item => item.ProductItemId == orderItem.ProductItemId);
                if (existingItem != null)
                {
                    existingItem.Quantity += orderItem.Quantity;
                }
                else
                {
                    existingOrderItems.Add(orderItem);
                }
            }

            HttpContext.Session.SetString("OrderItems", JsonConvert.SerializeObject(existingOrderItems));

            return Json(new { msg = "OK" });
        }
    }
}
