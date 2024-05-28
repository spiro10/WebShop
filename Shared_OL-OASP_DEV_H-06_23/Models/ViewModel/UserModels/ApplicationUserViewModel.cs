using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels
{
    public  class ApplicationUserViewModel
    {
        public string Id { get; set; }
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime")]
        public string LastName { get; set; }
        public DateTime? RegistrationDate { get; set; }
    }
}
