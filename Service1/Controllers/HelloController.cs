using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service1.Services;

namespace Service1.Controllers
{
    [ApiController]
    [Route("{*url}")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;
        private readonly IService2Service _service2Service;

        public HelloController(ILogger<HelloController> logger, IService2Service service2Service)
        {
            _logger = logger;
            _service2Service = service2Service;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var service2Response = await _service2Service.Get();
            return $"Hello from {HttpContext.Connection.RemoteIpAddress}:{HttpContext.Connection.RemotePort}\n" +
                $"to {HttpContext.Connection.LocalIpAddress}:{HttpContext.Connection.LocalPort}\n" +
                $"{service2Response}";
        }
    }
}
