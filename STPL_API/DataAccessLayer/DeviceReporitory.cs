using STPL_API.BusinessLogic;

namespace STPL_API.DataAccessLayer
{
    public class DeviceReporitory : RepositoryBase<TbDevice>, IDeviceReporitory
    {
        public DeviceReporitory(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        /// <summary>
        /// CheckAndCreateNewDevice for checking device information and creating new device if not exist
        /// </summary>
        /// <param name="device_id"></param>
        /// <param name="devicetype_id"></param>
        /// <param name="device_name"></param>
        /// <param name="group_id"></param>
        /// <param name="modifiedby"></param>
        /// <returns></returns>
        public int CheckAndCreateNewDevice(string device_id, string devicetype_id, string device_name, string group_id, string modifiedby)
        {
            try
            {
                // Log.Info("CheckAndCreateNewDevice is calling");
                int deviceid = (from d in RepositoryContext.TbDevice
                                   where
                                       d.device_id == device_id
                                       && d.device_type == devicetype_id
                                       && d.device_name == device_name
                                       && d.group_id == group_id
                                   select d.id
                                     ).FirstOrDefault();
                if (deviceid>0)
                {
                    return deviceid;
                }
                TbDevice tbDevice = new TbDevice()
                {
                    device_id = device_id,
                    device_type = devicetype_id,
                    device_name = device_name,
                    group_id = group_id,
                    modifiedby = modifiedby,
                    modifiedon = DateTime.Now
                };
                RepositoryContext.TbDevice.Add(tbDevice);
                RepositoryContext.SaveChanges();
                
                return tbDevice.id;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "CheckAndCreateNewDevice" +Environment.NewLine+ex.StackTrace);
                return 0;
            }
            
        }
    }
}
