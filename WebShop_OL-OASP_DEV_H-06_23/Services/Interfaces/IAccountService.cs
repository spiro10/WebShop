using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IAccountService
    {
        Task<bool> CreateUser(RegistrationBinding model, string role);
        Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null);
    }
}