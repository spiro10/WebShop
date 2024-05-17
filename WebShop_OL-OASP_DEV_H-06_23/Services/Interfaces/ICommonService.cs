using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface ICommonService
    {
        Task<AddressViewModel> UpdateAddress(AddressUpdateBinding model);
        Task<List<AddressViewModel>> GetAddresses();
        Task<AddressViewModel> GetAddress(long id);
        Task<long> GenerateNewAddressId();
    }
}