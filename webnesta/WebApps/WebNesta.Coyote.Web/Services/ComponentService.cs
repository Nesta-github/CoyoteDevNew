using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc;
using WebNesta.Coyote.Geral.Domain.ViewModel;

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

        public async Task<ValidateViewModel> InsertComponent(ComponentViewModel componentViewModel)
        {
            try
            {
                var itemModel = ObterConteudo(componentViewModel);

                var response = await _httpClient.PostAsync("/component", itemModel);

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

        public async Task<ValidateViewModel> UpdateComponent(ComponentViewModel componentViewModel)
        {
            try
            {
                var itemModel = ObterConteudo(componentViewModel);

                var response = await _httpClient.PutAsync("/component", itemModel);

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
        public async Task<ValidateViewModel> DeleteComponent(int id)
        {
            try
            {
                var response = await _httpClient. GetAsync($"/component/delete/{id}");

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

        public async Task<ResponseResultGeneric<DataComponentViewModel>> GetData(string lang)
        {
            var response = await _httpClient.GetAsync($"/component/GetData/{lang}");
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
