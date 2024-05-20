using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels
{
    public class OrderUpdateBinding : OrderBase
    {
        public long Id {  get; set; }
        public AddressUpdateBinding? OrderItem { get; set; }
        public List<OrderItemUpdateBinding>? OrderItems { get; set; }
    }
}
