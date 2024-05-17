using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<AddressViewModel>> GetAddresses()
        {
            var dbos = await db.Addresss.Where(x => x.Valid).ToListAsync();
            return dbos.Select(x => mapper.Map<AddressViewModel>(x)).ToList();

        }

        public async Task<AddressViewModel> GetAddress(long id)
        {
            var dbo = await db.Addresss.Where(x => x.Valid).FirstOrDefaultAsync(x => x.Id == id);
            if (dbo == null)
            {
                return null;
            }
            return mapper.Map<AddressViewModel>(dbo);

        }

        public async Task<long> GenerateNewAddressId()
        {
            long newId = 1;
            if (db.Addresss.Any())
            {
                newId = db.Addresss.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            }
            return newId;
        }

    }
}
