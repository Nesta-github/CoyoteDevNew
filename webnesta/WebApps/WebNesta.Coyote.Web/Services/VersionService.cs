using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Web.Services
{
    public class VersionService : Service, IVersionService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public VersionService(HttpClient httpClient, IConfiguration cofiguration)
        {
            _httpClient = httpClient;
            _configuration = cofiguration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("WebNestaAPI:WebNestaAPI_Geral"));
        }
        public async Task<string> GetObjectVersion(string page)
        {
            var response = await _httpClient.GetAsync($"/moeda/{page}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<string>(response);
        }
    }
}
