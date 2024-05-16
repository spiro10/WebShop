using Shared_OL_OASP_DEV_H_06_23.Models.Base.CompanyModels;

using System.Net;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels
{
    public class CompanyUpdateBinding: CompanyBase
    {
        public long Id { get; set; }
        public AddressUpdateBinding? Address { get; set; }
        public long? AddressId { get; set; }

    }
}
