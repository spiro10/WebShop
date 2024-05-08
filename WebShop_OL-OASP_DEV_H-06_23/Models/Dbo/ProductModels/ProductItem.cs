using Shared_OL_OASP_DEV_H_06_23.Interfaces;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels
{
    public class ProductItem : ProductItemBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Valid { get; set; }

        public ProductCategory? ProductCategory { get; set; }
        public long? ProductCategoryId { get; set; }
    }
}
