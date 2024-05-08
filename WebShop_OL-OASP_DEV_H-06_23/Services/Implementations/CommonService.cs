using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class CommonService : ICommonService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public CommonService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }



        /// <summary>
        /// Updates Address
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<AddressViewModel> UpdateAddress(AddressUpdateBinding model)
        {
            var dbo = await db.Addresss.FindAsync(model.Id);
            if (dbo == null)
            {
                //throw new Exception("Entity not found!");
                return null;
            }
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<AddressViewModel>(dbo);

        }

    }
}
