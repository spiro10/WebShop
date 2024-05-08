namespace Shared_OL_OASP_DEV_H_06_23.Interfaces
{
    public interface IBaseTableAtributes
    {
        DateTime Created { get; set; }
        long Id { get; set; }
        DateTime Updated { get; set; }
        bool Valid { get; set; }
    }
}
