using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels
{
    public class OrderViewModel : OrderBase
    {
        public long Id {  get; set; }
        public DateTime Created {  get; set; }
        public ApplicationUserViewModel? Buyer { get; set; }
        public AddressViewModel OrderAddress { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
    }
}
