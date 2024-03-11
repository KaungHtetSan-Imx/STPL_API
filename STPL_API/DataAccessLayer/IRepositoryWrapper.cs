namespace STPL_API.DataAccessLayer
{
    public interface IRepositoryWrapper
    {
        IHelloSTPLRepository helloSTPLRepository { get; }
        IDeviceReporitory deviceReporitory { get; }
        IRecordDataRepository recordDataRepository { get; }
        IReqTransRepository reqTransRepository { get; }
    }
}
