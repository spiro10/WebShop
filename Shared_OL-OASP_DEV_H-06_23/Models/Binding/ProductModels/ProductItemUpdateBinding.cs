using Shared_OL_OASP_DEV_H_06_23.Models.Base.ProductModels;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels
{
    public class ProductItemUpdateBinding: ProductItemBase
    {
        public long Id { get; set; }
        public long? ProductCategoryId { get; set; }
    }
}
