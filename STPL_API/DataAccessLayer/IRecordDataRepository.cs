namespace STPL_API.DataAccessLayer
{
    public interface IRecordDataRepository : IRepositoryBase<TbRecordData>
    {
        bool CreateNewRecordData(string data_type, int recordtrans_id, bool? IsfullPowerMode, bool? IsactivePowerControl, int? firmware_Version, int? temperature, int? humidity, int? version, string? message_type, bool? occupancy, int? state_changed);

    }
}
