using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Service1.Models;

namespace Service1.Services
{
    public class Service2Service : IService2Service
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;

        public Service2Service(HttpClient httpClient, IOptions<Service2Options> options)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = options.Value.BaseUrl;
        }

        public async Task<string> Get()
        {
            return await _httpClient.GetStringAsync(_remoteServiceBaseUrl);
        }
    }
}
