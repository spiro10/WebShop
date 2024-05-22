using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels
{
    public class OrderBase
    {
        
        public string Message { get; set; }

        //BillingAddress, BillingFirstName ... etc
    }
}
