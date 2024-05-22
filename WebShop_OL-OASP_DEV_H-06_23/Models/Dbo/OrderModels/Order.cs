using Shared_OL_OASP_DEV_H_06_23.Interfaces;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;

namespace WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels
{
    public class Order : OrderBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Valid { get; set; }

        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Total { get; set; }
        public ApplicationUser? Buyer { get; set; }
        public string? BuyerId { get; set; }
        public Address? OrderAddress { get; set; }
        public long? OrderAddressId { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }

    }
}
