using AutoMapper;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Add product item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductItemViewModel> AddProductItem(ProductItemBinding model);
        /// <summary>
        /// Add new product category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel> AddProductCategory(ProductCategoryBinding model);
        /// <summary>
        /// Delete Product Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel> DeleteProductCategory(long id);
        /// <summary>
        /// Get product Categorys
        /// </summary>
        /// <returns></returns>
        Task<List<ProductCategoryViewModel>> GetProductCategories(bool? valid = true);
        /// <summary>
        /// Add product Categories by paggination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchTerm"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        Task<ProductCategoryPaginationViewModel> GetProductCategories(int page, string? searchTerm = null, int? offset = null);
        /// <summary>
        /// Get Product category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel> GetProductCategory(long id);
        /// <summary>
        /// Update Product Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductCategoryViewModel> UpdateProductCategory(ProductCategoryUpdateBinding model);
        /// <summary>
        /// Get product item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductItemViewModel> GetProductItem(long id);

        /// <summary>
        /// Delte product item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductItemViewModel> DeleteProductItem(long id);
        /// <summary>
        /// Update product item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ProductItemViewModel> UpdateProductItem(ProductItemUpdateBinding model);
    }
}