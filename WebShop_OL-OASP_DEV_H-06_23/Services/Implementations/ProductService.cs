using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Data;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private AppSettings appSettings;


        public ProductService(ApplicationDbContext db, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            this.db = db;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }

        /// <summary>
        /// Get product Categorys
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> GetProductCategories(bool? valid = true)
        {



            var dbos = await db.ProductCategorys
                .Include(y=>y.ProductItems)
                .Where(y => y.Valid == valid).ToListAsync();
            return dbos.Select(y => mapper.Map<ProductCategoryViewModel>(y)).ToList();

        }
        /// <summary>
        /// Add product Categories by paggination
        /// </summary>
        /// <param name="page"></param>
        /// <param name="searchTerm"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public async Task<ProductCategoryPaginationViewModel> GetProductCategories(int page, string? searchTerm = null, int? offset = null)
        {

            if (!offset.HasValue)
            {
                offset = appSettings.PaginationOffset;
            }

            var baseQuery = db.ProductCategorys
                .Include(y=>y.ProductItems)
                .Where(y => y.Valid);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                baseQuery = baseQuery.Where(s => EF.Functions.Like(s.Name, $"%{searchTerm}%") || EF.Functions.Like(s.Description, $"%{searchTerm}%"));
            }

            var totalRecords = await baseQuery.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / offset.Value);

            var basePQuery = await baseQuery
                .Skip((page - 1) * offset.Value)
                .Take(offset.Value)
                .ToListAsync();


            var productCategory = basePQuery.OrderByDescending(y => y.Created).ToList();


            var response = new ProductCategoryPaginationViewModel
            {
                ProductCategorys = basePQuery.Select(y => mapper.Map<ProductCategoryViewModel>(y)).ToList(),
                Rows = totalPages,
                TotalRecords = totalRecords,
            };

            return response;
        }

        //Ostatak CRUD operacija nad kategorijama
        /// <summary>
        /// Add new product category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> AddProductCategory(ProductCategoryBinding model)
        {
            var company = await db.Companys.FirstOrDefaultAsync(y => y.Valid);
            var dbo = mapper.Map<ProductCategory>(model);
            dbo.Company = company;
            db.ProductCategorys.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }
        /// <summary>
        /// Update Product Category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> UpdateProductCategory(ProductCategoryUpdateBinding model)
        {
            //var dbo = await db.ProductCategorys
            //    .Include(y=>y.Company)
            //    .FirstOrDefaultAsync(y => y.Id == model.Id);

            var dbo = await db.ProductCategorys.FindAsync(model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }
        /// <summary>
        /// Get Product category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> GetProductCategory(long id)
        {
            var dbo = await db.ProductCategorys
                .Include(y=>y.ProductItems)
                .FirstOrDefaultAsync(y=>y.Id == id);

            dbo.ProductItems = dbo.ProductItems.Where(y => y.Valid).ToList();

            return mapper.Map<ProductCategoryViewModel>(dbo);

        }
        /// <summary>
        /// Delete Product Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> DeleteProductCategory(long id)
        {
            var dbo = await db.ProductCategorys.FindAsync(id);
            dbo.Valid = false;
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);

        }

        /// <summary>
        /// Add product item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductItemViewModel> AddProductItem(ProductItemBinding model)
        {      
            var dbo = mapper.Map<ProductItem>(model);        
            db.ProductItems.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductItemViewModel>(dbo);
        }

        /// <summary>
        /// Get product item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductItemViewModel> GetProductItem(long id)
        {
            var dbo = await db.ProductItems.FindAsync(id);
            return mapper.Map<ProductItemViewModel>(dbo);

        }

        /// <summary>
        /// Delte product item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductItemViewModel> DeleteProductItem(long id)
        {
            var dbo = await db.ProductItems.FindAsync(id);
            dbo.Valid = false;
            await db.SaveChangesAsync();
            return mapper.Map<ProductItemViewModel>(dbo);

        }
        /// <summary>
        /// Update product item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductItemViewModel> UpdateProductItem(ProductItemUpdateBinding model)
        {
            //var dbo = await db.ProductItems
            //    .Include(y=>y.Company)
            //    .FirstOrDefaultAsync(y => y.Id == model.Id);

            var dbo = await db.ProductItems.FindAsync(model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductItemViewModel>(dbo);
        }
        //Unit testovi
    }
}
