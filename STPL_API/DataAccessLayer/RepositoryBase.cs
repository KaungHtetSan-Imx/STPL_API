namespace STPL_API.DataAccessLayer
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppDb RepositoryContext { get; set; }

        public RepositoryBase(AppDb repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public T FindByID(int ID)
        {

            T obj;

            obj = this.RepositoryContext.Set<T>().Find(ID);

            return obj;
        }
    }
}
