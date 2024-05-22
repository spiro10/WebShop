using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;
using System.Security.Claims;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateUser(RegistrationBinding model, string role);
        Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null);
        Task<AddressViewModel> GetUserAddress(ClaimsPrincipal user);
    }
}