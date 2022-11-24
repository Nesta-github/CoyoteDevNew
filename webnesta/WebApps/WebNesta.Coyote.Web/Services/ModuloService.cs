using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebNesta.Coyote.Web.Configuration;
using Microsoft.AspNetCore.Mvc;
using WebNesta.Coyote.Web.Models;

namespace WebNesta.Coyote.Web.Services
{
    public class ModuloService : Service, IModuloService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ModuloService(HttpClient httpClient, IConfiguration cofiguration)
        {
            _httpClient = httpClient;
            _configuration = cofiguration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("WebNestaAPI:WebNestaAPI_Geral"));
        }

        public async Task<TutorialViewModel> GetTutorial(string lang, string enumControllerNameTutorial)
        {
            var response = await _httpClient.GetAsync(string.Concat($"modulo/GetTutorial?"
                , "lang=",lang, "&controllerName=", enumControllerNameTutorial));

            TratarErrosResponse(response);
        var model =  await  DeserializarObjetoResponse<TutorialViewModel>(response);

           // var result = await response.Content.ReadAsStringAsync();

            return model;
        }
    }
}
