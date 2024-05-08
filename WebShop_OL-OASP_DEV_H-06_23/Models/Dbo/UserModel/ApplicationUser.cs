using Microsoft.AspNetCore.Identity;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;

namespace WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address? Address { get; set; }
    }
}
