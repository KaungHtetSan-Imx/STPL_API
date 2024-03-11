namespace STPL_API.DataAccessLayer
{
    public interface IDeviceReporitory : IRepositoryBase<TbDevice>
    {
        int CheckAndCreateNewDevice(string device_id,string devicetype_id,string device_name,string group_id, string modifiedby);
    }
}
