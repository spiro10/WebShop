using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IAdminService
    {
        Task<CompanyViewModel> UpdateCompany(CompanyUpdateBinding model);
    }
}