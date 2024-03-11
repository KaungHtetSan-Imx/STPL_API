namespace STPL_API.DataAccessLayer
{
    public interface IRepositoryBase<T>
    {
        T FindByID(int ID);
    }
}
