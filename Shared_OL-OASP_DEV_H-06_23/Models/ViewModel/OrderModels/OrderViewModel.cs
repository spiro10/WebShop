using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
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
    public class OrderViewModel : OrderBase
    {
        [Display(Name = "Id narudžbe")]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUserViewModel? Buyer { get; set; }
        public AddressViewModel? OrderAddress { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        [Display(Name = "Ukupno")]
        public decimal Total { get; set; }
    }
}
