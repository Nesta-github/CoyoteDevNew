using System.Net.Http;
using System;
using System.Threading.Tasks;
using WebNesta.Coyote.Web.Models;
using Microsoft.Extensions.Configuration;
using WebNesta.Coyote.Web.Configuration;
using System.Reflection;
using WebNesta.Coyote.Geral.Domain.ViewModel;

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

          //  DeserializarObjetoResponse<ResponseResult>(response);

            return new ResponseResult() { Title = result };
        }

        public async Task<ValidateViewModel> Login(AuthViewModel model)
        {
            try
            {
                var itemModel = ObterConteudo(model);

                var response = await _httpClient.PostAsync("/account/login", itemModel);

                // if (!TratarErrosResponse(response)) return await DeserializarObjetoResponse<HttpResponseMessage>(response);
                
                var responseModel = await DeserializarObjetoResponse<ValidateViewModel>(response);
                //DeserializarObjetoResponse<ResponseResult>(response);
                return responseModel;
            }
            catch (Exception ex)
            {
                var mesage = ex.Message;
                throw;
            }
        }

        public async Task<string> RecoveryPassword(RecoveryPasswordViewModel emailRecoveryPassword)
        {
            try
            {
                var itemModel = ObterConteudo(emailRecoveryPassword);

                var response = await _httpClient.PostAsync("/account/recoverypassword", itemModel);

                var result = await response.Content.ReadAsStringAsync();

                return result;

            }
            catch (Exception ex)
            {
                var mesage = ex.Message;
                throw;
            }
        }

        public async Task<string> GetGoogleAuth()
        {
            var googleAuthKey = _configuration.GetValue<string>("GoogleAuthenticator:Key");

            return null;
        }
    }
}
