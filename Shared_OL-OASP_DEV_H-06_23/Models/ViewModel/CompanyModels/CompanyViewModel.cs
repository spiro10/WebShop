using Shared_OL_OASP_DEV_H_06_23.Models.Base.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels
{
    public class CompanyViewModel : CompanyBase
    {
        public long Id { get; set; }
        public AddressViewModel? Address { get; set; }
        public long? AddressId { get; set; }
    }
}

