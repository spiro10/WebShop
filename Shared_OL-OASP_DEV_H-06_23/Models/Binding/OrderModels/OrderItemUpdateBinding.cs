using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels
{
    public class OrderItemUpdateBinding : OrderItemBase
    {
        public long Id { get; set; }
    }
}
