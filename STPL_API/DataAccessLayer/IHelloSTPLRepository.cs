namespace STPL_API.DataAccessLayer
{
    public interface IHelloSTPLRepository : IRepositoryBase<tb_Temp>
    {
        dynamic SendHello();
    }
}
