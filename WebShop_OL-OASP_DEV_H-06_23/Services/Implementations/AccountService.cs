using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.AccountModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.UserModel;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private ApplicationDbContext db;
        private IMapper mapper;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<bool> CreateUser(RegistrationBinding model, string role)
        {
            var find = await userManager.FindByEmailAsync(model.Email);
            if (find != null)
            {
                return false;
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                RegistrationDate = DateTime.Now
            };
            user.EmailConfirmed = true;

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
                await userManager.UpdateAsync(user);
                await signInManager.SignInAsync(user, isPersistent: false);
            }

            return false;
        }


        public async Task<List<ApplicationUserViewModel>> GetRegUsers(DateTime? notBefore = null)
        {
            if (!notBefore.HasValue)
            {
                notBefore = DateTime.Now.AddDays(-1);
            }
            var newUsers = await db.Users.Where(x => x.RegistrationDate < notBefore).ToListAsync();
            return newUsers.Select(x => mapper.Map<ApplicationUserViewModel>(x)).ToList();
        }

        //Zadatak: napraviti view sa detaljima buyera aka kupca
        // zaseban view gdje korisnik moze pregledati vlastitu adresu
        //Update usera, omoguciti unos adrese kupca



    }
}
