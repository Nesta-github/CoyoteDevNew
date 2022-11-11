using Microsoft.Extensions.Options;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using WebNesta.Coyote.WebApp.Controllers;
using WebNesta.Coyote.WebApp.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace WebNesta.Coyote.WebApp.Services
{
    public class LoginService : Service, ILoginService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        public LoginService(HttpClient httpClient, IConfiguration cofiguration)
        {
            _httpClient = httpClient;
            _configuration = cofiguration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("WebNestaAPI:WebNestaAPI_Geral"));
        }

        public async Task<ResponseResult> Login(AuthViewModel model)
        {
            var itemModel = ObterConteudo(model);

            var response = await _httpClient.PostAsync("/Account/Login", itemModel);

            if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<ResponseResult>(response);

            return await DeserializarObjetoResponse<ResponseResult>(response);
        }
    }
}
