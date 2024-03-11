using STPL_API.BusinessLogic;
using System.ComponentModel.DataAnnotations;
using System;

namespace STPL_API.DataAccessLayer
{
    public class ReqTransRepository : RepositoryBase<TbRecordTransaction>, IReqTransRepository
    {
        
        public ReqTransRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }
        /// <summary>
        /// CreateNewRecordTransaction for saving new request transaction
        /// </summary>
        /// <param name="_repositoryWrapper"></param>
        /// <param name="requestor_ip"></param>
        /// <param name="device_id"></param>
        /// <param name="request_timestramp"></param>
        /// <param name="data_type"></param>
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
        public int CreateNewRecordTransaction(IRepositoryWrapper _repositoryWrapper,string requestor_ip, int deviceid, long request_timestramp, string data_type, bool? IsfullPowerMode, bool? IsactivePowerControl, int? firmware_Version, int? temperature, int? humidity, int? version, string message_type, bool? occupancy, int? state_changed)
        {
            try
            {
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(request_timestramp);
                DateTime dateTime = dateTimeOffset.UtcDateTime;
                TbRecordTransaction tbRecordTrans = new TbRecordTransaction()
                {
                    requestor_ip = requestor_ip,
                    deviceid = deviceid,
                    request_timestramp = dateTime,
                    created_datetime = DateTime.Now
                };
                RepositoryContext.TbRecordTransaction.Add(tbRecordTrans);
                RepositoryContext.SaveChanges();
                bool result = _repositoryWrapper.recordDataRepository.CreateNewRecordData( data_type, tbRecordTrans.trans_id, IsfullPowerMode, IsactivePowerControl, firmware_Version, temperature, humidity,version, message_type, occupancy, state_changed);
                if (result)
                {
                    return tbRecordTrans.trans_id;
                }
                else
                {
                    Log.Warn("[CreateNewRecordTransaction] Can't save new record data");

                    return 0;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex,"CreateNewRecordTransaction" + Environment.NewLine + ex.StackTrace);
                return 0;
            }
        }

      
    }
}
