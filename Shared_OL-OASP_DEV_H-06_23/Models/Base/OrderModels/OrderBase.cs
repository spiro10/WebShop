using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels
{
    public class OrderBase
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Total { get; set; }
        public string Message { get; set; }

        //BillingAddress, BillingFirstName ... etc
    }
}
