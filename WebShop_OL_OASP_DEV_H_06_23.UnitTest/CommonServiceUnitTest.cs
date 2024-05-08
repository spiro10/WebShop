using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public class CommonServiceUnitTest : WebShopSetup
    {
        private readonly ICommonService commonService;

        public CommonServiceUnitTest()
        {
            this.commonService = GetCommonService();
        }

        [Fact]
        public async void UpdateAddress_UpdatesAddressByIdAndDto_ReturnsViewModel()
        {

           var response = await commonService.UpdateAddress(new Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common.AddressUpdateBinding
            {
                Id = Address.Id,
                City = "Zadar",
                Country = "Hrvatska",
                Number = "111",
                Street = "Široka ulica"
            });


            Assert.NotNull(response);

            Assert.NotEqual(default, response.Updated);

        }
    }
}