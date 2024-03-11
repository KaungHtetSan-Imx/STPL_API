using STPL_API.BusinessLogic;

namespace STPL_API.DataAccessLayer
{
    public class RecordDataRepository : RepositoryBase<TbRecordData>, IRecordDataRepository
    {
        public RecordDataRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        /// <summary>
        /// CreateNewRecordData for saving new request data
        /// </summary>
        /// <param name="data_type"></param>
        /// <param name="recordtrans_id"></param>
        /// <param name="IsfullPowerMode"></param>
        /// <param name="IsactivePowerControl"></param>
        /// <param name="firmware_Version"></param>
        /// <param name="temperature"></param>
        /// <param name="humidity"></param>
        /// <param name="version"></param>
        /// <param name="message_type"></param>
        /// <param name="occupancy"></param>
        /// <param name="state_changed"></param>
        /// <returns></returns>
        public bool CreateNewRecordData(string data_type, int recordtrans_id, bool? IsfullPowerMode, bool? IsactivePowerControl, int? firmware_Version, int? temperature, int? humidity, int? version, string message_type, bool? occupancy, int? state_changed)
        {
            try
            {
                TbRecordData tbRecordData = new TbRecordData()
                {
                    data_type = data_type,
                    recordtrans_id = recordtrans_id,    
                    IsfullPowerMode = IsfullPowerMode,
                    IsactivePowerControl = IsactivePowerControl,
                    firmware_Version = firmware_Version,
                    temperature = temperature,
                    humidity = humidity,
                    version = version,
                    message_type = message_type,
                    occupancy = occupancy,
                    state_changed = state_changed
                };
                RepositoryContext.TbRecordData.Add(tbRecordData);
                RepositoryContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Log.Error(ex, "CreateNewRecordData" + Environment.NewLine+ex.StackTrace);
                return false;
            }
        }
    }
}
