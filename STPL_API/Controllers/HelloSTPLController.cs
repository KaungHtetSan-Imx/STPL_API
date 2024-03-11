using Microsoft.AspNetCore.Mvc;
using STPL_API.DataAccessLayer;

namespace STPL_API.Controllers
{
    [Route("v1/[controller]")]
    //[Route("v1")]
    public class HelloSTPLController : Controller
    {
        private IRepositoryWrapper _repositoryWrapper;

        public HelloSTPLController(IRepositoryWrapper RW)
        {
            _repositoryWrapper = RW;
        }

        [HttpGet("SendHello", Name = "SendHello")]

        public dynamic SendHello()
        {
            return _repositoryWrapper.helloSTPLRepository.SendHello();
        }
    }
}
