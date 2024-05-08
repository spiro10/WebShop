using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Moq;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Mapping;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.Common;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Implementations;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public abstract class WebShopSetup
    {
        protected IMapper Mapper { get; private set; }
        protected ApplicationDbContext InMemoryDbContext;
        protected readonly Address Address;
        protected readonly Mock<IOptions<AppSettings>> AppSettings;
        protected readonly List<ProductCategory> ProductCategories;
        protected static string TestString = "mali medo";


        public WebShopSetup()
        {
            SetupInMemoryContext();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            Mapper = mappingConfig.CreateMapper();
            Address = GenerateAddress();
            ProductCategories = GenerateProductCategorys(100);
            var config = new AppSettings
            {
                PaginationOffset = 10
            };


            AppSettings = new Mock<IOptions<AppSettings>>();
            AppSettings.Setup(c => c.Value).Returns(config);
        }

        private Address GenerateAddress()
        {
            Address dbo = new Address
            {
                City = "Zagreb",
                Created = DateTime.Now,
                Country = "Hrvatska",
                Street = "Maksimirska",
                Number = "100",
                Valid = true
            };

            InMemoryDbContext.Addresss.Add(dbo);
            InMemoryDbContext.SaveChanges();

            return dbo;

        }


        protected List<ProductCategory> GenerateProductCategorys(int number)
        {

            List<ProductCategory> response = new List<ProductCategory>();
            Random random = new Random();

            for (int i = 0; i < number; i++)
            {

                if (i != 0)
                {
                    ProductCategory listItem = new ProductCategory
                    {
                        Description = $"{nameof(ProductCategory.Description)} {random.Next(1, 1000)}",
                        Name = $"{nameof(ProductCategory.Name)} {random.Next(1, 1000)}",
                    };
                    response.Add(listItem);
                }
                else
                {
                    ProductCategory listItem = new ProductCategory
                    {
                        Description = $"{nameof(ProductCategory.Description)} {random.Next(1, 1000)}",
                        Name = $"{TestString} {random.Next(1, 1000)}",
                    };

                    response.Add(listItem);
                }


            }

            InMemoryDbContext.ProductCategorys.AddRange(response);
            InMemoryDbContext.SaveChanges();

            return response;

        }

        protected IProductService GetProductService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new ProductService(db, Mapper, AppSettings.Object);
            }
            return new ProductService(InMemoryDbContext, Mapper, AppSettings.Object);

        }

        protected ICommonService GetCommonService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new CommonService(db, Mapper);
            }
            return new CommonService(InMemoryDbContext, Mapper);

        }
        protected IAdminService GetAdminService(ApplicationDbContext? db = null)
        {
            if (db != null)
            {
                return new AdminService(db, Mapper);
            }
            return new AdminService(InMemoryDbContext, Mapper);

        }

        private void SetupInMemoryContext()
        {
            var inMemoryOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                            .Options;
            InMemoryDbContext = new ApplicationDbContext(inMemoryOptions);
        }
    }
}
