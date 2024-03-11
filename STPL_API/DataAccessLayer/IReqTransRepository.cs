namespace STPL_API.DataAccessLayer
{
    public interface IReqTransRepository : IRepositoryBase<TbRecordTransaction>
    {
        bool CreateNewRecordTransaction(IRepositoryWrapper _repositoryWrapper, string requestor_ip, int deviceid, long request_timestramp, string data_type, bool? IsfullPowerMode, bool? IsactivePowerControl, int? firmware_Version, int? temperature, int? humidity, int? version, string message_type, bool? occupancy, int? state_changed);
    }
}
