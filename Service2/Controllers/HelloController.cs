using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service2.Controllers
{
    [ApiController]
    [Route("{*url}")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return $"Hello from {HttpContext.Connection.RemoteIpAddress}:{HttpContext.Connection.RemotePort}\n" +
            $"to {HttpContext.Connection.LocalIpAddress}:{HttpContext.Connection.LocalPort}";
        }
    }
}
