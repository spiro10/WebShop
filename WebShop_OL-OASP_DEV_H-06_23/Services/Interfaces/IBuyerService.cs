using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using System.Security.Claims;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IBuyerService
    {
        Task<List<ProductItemViewModel>> GetProductItems(List<long> productItemsIds);
        Task<OrderViewModel> Order(OrderBinding model, ApplicationUser buyer);
        Task<OrderViewModel> Order(OrderBinding model, ClaimsPrincipal user);
        Task<OrderViewModel> UpdateOrder(OrderUpdateBinding model);
        Task<List<OrderViewModel>> GetOrders();
        Task<List<OrderViewModel>> GetOrders(ApplicationUser buyer);
        Task<List<OrderViewModel>> GetOrders(ClaimsPrincipal user);
        Task<OrderViewModel> GetOrder(long id);
        Task<OrderViewModel> DeleteOrder(long id);
        Task<OrderViewModel> CancelOrder(long id);
    }
}