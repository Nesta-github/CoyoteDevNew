using System.Net.Http;
using System;
using System.Threading.Tasks;
using WebNesta.Coyote.Web.Models;
using Microsoft.Extensions.Configuration;
using WebNesta.Coyote.Web.Configuration;
using System.Reflection;

namespace WebNesta.Coyote.Web.Services
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

        public async Task<ResponseResult> GetObjectVersion(string page)
        {
            var response = await _httpClient.GetAsync($"/account/getlogindata/{page}");

            TratarErrosResponse(response);

            var result = await response.Content.ReadAsStringAsync();

            return new ResponseResult() { Title = result };
        }

        public async Task<ResponseResult> Login(AuthViewModel model)
        {
            try
            {
                var itemModel = ObterConteudo(model);

                var response = await _httpClient.PostAsync("/account/login", itemModel);

                // if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<HttpResponseMessage>(response);

                var result = await response.Content.ReadAsStringAsync();

                //DeserializarObjetoResponse<ResponseResult>(response);
                return new ResponseResult() { Title = result };
            }
            catch (Exception ex)
            {
                var mesage = ex.Message;
                throw;
            }
        }

        public async Task<ResponseResult> RecoveryPassword(RecoveryPasswordViewModel emailRecoveryPassword)
        {
            try
            {
                var itemModel = ObterConteudo(emailRecoveryPassword);

                var response = await _httpClient.PostAsync("/account/recoverypassword", itemModel);

                // if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<HttpResponseMessage>(response);

                var result = await response.Content.ReadAsStringAsync();

                //DeserializarObjetoResponse<ResponseResult>(response);
                return new ResponseResult() { Title = result };
            }
            catch (Exception ex)
            {
                var mesage = ex.Message;
                throw;
            }
        }

        public Task<ResponseResult> RecoveryPassword(string emailRecoveryPassword)
        {
            throw new NotImplementedException();
        }
    }
}
