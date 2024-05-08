namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels
{
    public class ProductCategoryPaginationViewModel
    {
        public int TotalRecords { get; set; }
        public int Rows { get; set; }
        public List<ProductCategoryViewModel> ProductCategorys { get; set; }
    }
}
