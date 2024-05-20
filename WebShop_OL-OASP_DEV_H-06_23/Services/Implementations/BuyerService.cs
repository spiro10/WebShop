using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class BuyerService : IBuyerService
    {
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public BuyerService(IMapper mapper, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<OrderViewModel> Order(OrderBinding model, ClaimsPrincipal user)
        {
            var applicatioUser = await userManager.GetUserAsync(user);
            return await Order(model, applicatioUser);
        }

        public async Task<OrderViewModel> Order(OrderBinding model, ApplicationUser buyer)
        {
            var dbo = mapper.Map<Order>(model);
            var productItems = db.ProductItems
                .Where(y => model.OrderItemIds.Select(y => y.ProductItemId).Contains(y.Id)).ToList();


            foreach (var product in dbo.OrderItems)
            {
                var target = productItems.FirstOrDefault(y => product.ProductItemId == y.Id);
                if (target != null)
                {
                    product.Price = target.Price;
                }
            }


            dbo.Buyer = buyer;
            db.Orders.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);
        }

        public async Task<OrderViewModel> UpdateOrder(OrderUpdateBinding model)
        {
            var dbo = await db.Orders.Include(x => x.OrderAddress)
                .FirstOrDefaultAsync(x => x.Id == model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);
        }

        public async Task<List<OrderViewModel>> GetOrders()
        {
            var dbos = await db.Orders.Include(x => x.OrderItems)
                .Include(x => x.OrderAddress)
                .Where(x => x.Valid).ToListAsync();
            return dbos.Select(x => mapper.Map<OrderViewModel>(x)).ToList();
        }

        public async Task<OrderViewModel> GetOrder(long id)
        {
            var dbo = await db.Orders.Include(x => x.OrderItems)
                .Include(x => x.OrderAddress)
                .FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<OrderViewModel>(dbo);
        }

        public async Task<OrderViewModel> DeleteOrder(long id)
        {
            var dbo = await db.Orders.Include(x => x.OrderItems)
                .Include(x => x.OrderAddress)
                .FirstOrDefaultAsync(x => x.Id == id);
            dbo.Valid = false;
            await db.SaveChangesAsync();
            return mapper.Map<OrderViewModel>(dbo);

        }
    }
}
