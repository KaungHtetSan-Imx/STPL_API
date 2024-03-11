namespace STPL_API.DataAccessLayer
{
    class HelloSTPLRepository : RepositoryBase<tb_Temp>, IHelloSTPLRepository
    {
        public string _connectionString = "";
        public HelloSTPLRepository(AppDb repositoryContext)
            : base(repositoryContext)
        {
        }

        public dynamic SendHello()
        {
            //test db connection from here
            return "Hello from STPL!!";
        }
    }
}
