using Azure;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public class ProductServiceUnitTest : WebShopSetup
    {
        private readonly IProductService productService;

        public ProductServiceUnitTest()
        {
            this.productService = GetProductService();
        }



        [Fact]
        public async void GetProductCategories_FetchesAllCategorysBasedOnSearch_ReturnsList()
        {

            var response = await productService.GetProductCategories(1, TestString);

            Assert.NotEmpty(response.ProductCategorys);
            Assert.Single(response.ProductCategorys);

            response = await productService.GetProductCategories(1, offset: 30);

            Assert.NotEmpty(response.ProductCategorys);
            Assert.Equal(30, response.ProductCategorys.Count);


        }

        [Fact]
        public async void UpdateProductCategory_UpdatesElementInDb_ReturnsUpdatedItem()
        {

            var response = await productService.UpdateProductCategory(new ProductCategoryUpdateBinding
            {
                Id = ProductCategories[20].Id,
                Description = TestString,
                Name = TestString,
            });

            Assert.NotNull(response);
            Assert.Equal(TestString, response.Description);
            Assert.Equal(TestString, response.Name);


        }

        [Fact]
        public async void AddProductCategory_AddsNewEntityToDb_ReturnsViewModel()
        {

            var response = await productService.AddProductCategory(new ProductCategoryBinding
            {
                Name = TestString,
                Description = TestString,
            });

            Assert.NotNull(response);
            Assert.Equal(TestString, response.Description);
            Assert.Equal(TestString, response.Name);

            response = await productService.GetProductCategory(response.Id);
            Assert.NotNull(response);

        }


        [Fact]
        public async void DeleteProductCategory_DeletesEntityFromDb_ValidatesIfItemIsNull()
        {
            var deletedId = ProductCategories[12].Id;
           await productService.DeleteProductCategory(deletedId);

            var allItems = await productService.GetProductCategories();            
            Assert.Null(allItems.FirstOrDefault(y=>y.Id == deletedId));
        }

        [Fact]
        public async void AddProductItem_AddsNewEntityToDb_ReturnsViewModel()
        {

            var response = await productService.AddProductItem(new ProductItemBinding
            {
                Description = TestString,
                Name = TestString,
                Price = 1233,
                ProductCategoryId = ProductCategories[1].Id,
                Quantity = 10
            });

            Assert.NotNull(response);

        }

        [Fact]
        public async void DeleteProductItem_DeletesEntityFromDb_ValidatesIfItemIsNull()
        {
            var addedItem = await productService.AddProductItem(new ProductItemBinding
            {
                Description = TestString + "x",
                Name = TestString,
                Price = 1233,
                ProductCategoryId = ProductCategories[12].Id,
                Quantity = 10
            });
            Assert.NotNull(addedItem);


            await productService.DeleteProductItem(addedItem.Id);
            var productCategory = await productService.GetProductCategory(ProductCategories[12].Id);
            var productItem = productCategory.ProductItems.FirstOrDefault(y => y.Id == addedItem.Id);
            Assert.Null(productItem);


        }

    }
}
