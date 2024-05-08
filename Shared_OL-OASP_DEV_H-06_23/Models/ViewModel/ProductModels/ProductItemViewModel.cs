using Shared_OL_OASP_DEV_H_06_23.Models.Base.ProductModels;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.ProductModels
{
    public class ProductItemViewModel: ProductItemBase
    {
        public long Id { get; set; }
        public long? ProductCategoryId { get; set; }

    }
}
