using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebNesta.Coyote.Web.Services
{
    public class ComponentService : Service, IComponentService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ComponentService(HttpClient httpClient, IConfiguration cofiguration)
        {
            _httpClient = httpClient;
            _configuration = cofiguration;
            _httpClient.BaseAddress = new Uri(_configuration.GetValue<string>("WebNestaAPI:WebNestaAPI_Component"));
        }

        public async Task<ResponseResultGeneric<ICollection<Component>>> GetAllComponent()
        {
           var response = await _httpClient.GetAsync($"/component/GetAllComponent");
            ResponseResultGeneric<ICollection<Component>> responseModel = null;

            TratarErrosResponse(response);

            responseModel = await DeserializarObjetoResponse<ResponseResultGeneric<ICollection<Component>>>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            //return new ResponseResult() { Title = result };
            return responseModel;
        }

        public Task InsertComponent(ComponentViewModel componentViewModel)
        {
            // await _httpClient.($"/component/Delete");
            //DataComponentViewModel responseModel = null;

            // TratarErrosResponse(response);


            //responseModel = await DeserializarObjetoResponse<DataComponentViewModel>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            return null;
        }

        public Task UpdateComponent(ComponentViewModel componentViewModel)
        {
            // await _httpClient.DeleteAsync($"/component/Delete");
            //DataComponentViewModel responseModel = null;

            // TratarErrosResponse(response);


            //responseModel = await DeserializarObjetoResponse<DataComponentViewModel>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            //return new ResponseResult() { Title = result };
            return null;
        }
        public Task DeleteComponent(int id)
        {
            // await _httpClient.DeleteAsync($"/component/Delete");
            //DataComponentViewModel responseModel = null;

            // TratarErrosResponse(response);


            //responseModel = await DeserializarObjetoResponse<DataComponentViewModel>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            //return new ResponseResult() { Title = result };
            return null;
        }

        public async Task<ResponseResultGeneric<DataComponentViewModel>> GetData()
        {
            var response = await _httpClient.GetAsync($"/component/GetData");
            ResponseResultGeneric<DataComponentViewModel>  responseModel = null;

            TratarErrosResponse(response);


            responseModel = await DeserializarObjetoResponse<ResponseResultGeneric<DataComponentViewModel>>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            //return new ResponseResult() { Title = result };
            return responseModel;
        }

        public async Task<ResponseResultGeneric<ICollection<Component>>> GetComponentSearch(string term)
        {
            var response = string.IsNullOrEmpty(term) ? 
                await _httpClient.GetAsync($"/component/GetAllComponent")
                : await _httpClient.GetAsync($"/component/search/{term}");

            ResponseResultGeneric<ICollection<Component>> responseModel = null;

            TratarErrosResponse(response);

            responseModel = await DeserializarObjetoResponse<ResponseResultGeneric<ICollection<Component>>>(response);

            //  DeserializarObjetoResponse<ResponseResult>(response);

            //return new ResponseResult() { Title = result };
            return responseModel;
        }
    }
}
