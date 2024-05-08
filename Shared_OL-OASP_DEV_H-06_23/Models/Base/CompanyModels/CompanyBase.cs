namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.CompanyModels
{
    public abstract class CompanyBase
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        /// <summary>
        /// Oib
        /// </summary>
        public string VAT { get; set; }

    }
}
