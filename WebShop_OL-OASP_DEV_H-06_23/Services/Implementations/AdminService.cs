using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.CompanyModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.CompanyModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public AdminService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        /// <summary>
        /// Updates an existing company's information in the database using the provided CompanyUpdateBinding model.
        /// This method finds the first valid company entry, applies the updates from the model, saves the changes asynchronously, 
        /// and returns the updated company as a CompanyViewModel.
        /// </summary>
        /// <param name="model">The CompanyUpdateBinding model containing the updated data for the company.</param>
        /// <returns>A Task resulting in a CompanyViewModel representing the updated company.</returns>
        public async Task<CompanyViewModel> UpdateCompany(CompanyUpdateBinding model)
        {
            var dbo = await db.Companys.FirstOrDefaultAsync(y => y.Valid);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<CompanyViewModel>(dbo);
        }


    }
}
