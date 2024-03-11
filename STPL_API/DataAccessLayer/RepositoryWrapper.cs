namespace STPL_API.DataAccessLayer
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDb _repoContext;
        public RepositoryWrapper(AppDb repositoryContext, IHttpContextAccessor httpContextAccessor)
        {
            _repoContext = repositoryContext;
        }
        public IHelloSTPLRepository ohelloSTPLRepository;
        public IHelloSTPLRepository helloSTPLRepository
        {
            get
            {
                if (ohelloSTPLRepository == null)
                {
                    ohelloSTPLRepository = new HelloSTPLRepository(_repoContext);
                }

                return ohelloSTPLRepository;
            }
        }
        public IDeviceReporitory odeviceReporitory;
        public IDeviceReporitory deviceReporitory
        {
            get
            {
                if (odeviceReporitory == null)
                {
                    odeviceReporitory = new DeviceReporitory(_repoContext);
                }

                return odeviceReporitory;
            }
        }
        public IRecordDataRepository orecordDataRepository;
        public IRecordDataRepository recordDataRepository
        {
            get
            {
                if (orecordDataRepository == null)
                {
                    orecordDataRepository = new RecordDataRepository(_repoContext);
                }

                return orecordDataRepository;
            }
        }
        public IReqTransRepository oreqTransRepository;
        public IReqTransRepository reqTransRepository
        {
            get
            {
                if (oreqTransRepository == null)
                {
                    oreqTransRepository = new ReqTransRepository(_repoContext);
                }

                return oreqTransRepository;
            }
        }
    }

}
