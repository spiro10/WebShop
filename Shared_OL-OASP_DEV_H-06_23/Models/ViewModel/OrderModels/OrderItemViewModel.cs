using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels
{
    public class OrderItemViewModel : OrderItemBase
    {
        public long Id { get; set; }
        public long? ProductItemId { get; set; }
    }
}
