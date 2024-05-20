using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels
{
    public class OrderBinding : OrderBase
    {
        public AddressBinding? OrderAddress { get; set; }
        public List<OrderItemBinding> OrderItemIds { get; set; }
    }
}
