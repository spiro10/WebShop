using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Controllers
{
    [Authorize(Roles = Roles.Buyer)]
    public class BuyerController : Controller
    {

        private readonly IProductService _productService;
        private readonly IBuyerService _buyerService;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public BuyerController(IProductService productService, IBuyerService buyerService,
            IAccountService accountService, IMapper mapper)
        {

            _productService = productService;
            _buyerService = buyerService;
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Order()
        {
            var sessionOrderItems = HttpContext.Session.GetString("OrderItems");
            List<OrderItemBinding> existingOrderItems = sessionOrderItems != null
     ? JsonConvert.DeserializeObject<List<OrderItemBinding>>(sessionOrderItems)
     : new List<OrderItemBinding>();


            var buyerAddress = await _accountService.GetUserAddress(User);
            OrderBinding orderBinding = new OrderBinding
            {
                OrderAddress = buyerAddress != null ? _mapper.Map<AddressBinding>(buyerAddress) : new AddressBinding(),
                OrderItems = existingOrderItems
            };



            return View(orderBinding);
        }





        [HttpPost]
        public async Task<IActionResult> Order(OrderBinding model)
        {
            var order = await _buyerService.Order(model, User);

            return RedirectToAction("Index"/*, new { orderId = order.Id }*/);
        }

        public async Task<IActionResult> MyOrder(long orderId)
        {
            var order = await _buyerService.GetOrder(orderId);
            return View(order);
        }


        public async Task<IActionResult> MyOrders()
        {
            var orders = await _buyerService.GetOrders(User);
            return View(orders);
        }

        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetProductCategories();
            return View(model);
        }


        //public async Task<IActionResult> CancelOrder(long orderId)
        //{
        //    var model = await _buyerService.CancelOrder(orderId);
        //    return RedirectToAction("MyOrders");
        //}

        public async Task<IActionResult> Details(long id)
        {
            var productCategory = await _productService.GetProductCategory(id);
            return View(productCategory);
        }





        [HttpPost]
        public async Task<IActionResult> AddToOrderItem([FromBody] List<OrderItemBinding> orderItems)
        {
            // Retrieve the existing session list of OrderItemBiding
            var sessionOrderItems = HttpContext.Session.GetString("OrderItems");
            List<OrderItemBinding> existingOrderItems = sessionOrderItems != null
                ? JsonConvert.DeserializeObject<List<OrderItemBinding>>(sessionOrderItems)
                : new List<OrderItemBinding>();

            // Update the session list with the new order items
            foreach (var orderItem in orderItems)
            {
                var existingItem = existingOrderItems.Find(item => item.ProductItemId == orderItem.ProductItemId);
                if (existingItem != null)
                {
                    // Update the quantity of the existing item
                    existingItem.Quantity += orderItem.Quantity;
                }
                else
                {
                    // Add the new item to the list
                    existingOrderItems.Add(orderItem);
                }
            }

            // Save the updated list back to the session
            HttpContext.Session.SetString("OrderItems", JsonConvert.SerializeObject(existingOrderItems));

            return Json(new { msg = "Ok" });
        }


    }
}
