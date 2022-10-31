using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace WebNesta.Coyote.Core.API
{
    public class ApiRequest
    {
        private string BaseApi { get; set; }
        
        private IRequest RequestType { get; set; }
        private HttpClient HttpClient { get; set; }

        public ApiRequest(string userApi, string passApi, string baseApi, IRequest requestType)
        {
            this.BaseApi = baseApi;
            this.RequestType = requestType;

            if (!string.IsNullOrEmpty(userApi) && !string.IsNullOrEmpty(passApi))
            {
                var authKey = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Concat(userApi, ":", passApi)));

                this.HttpClient = new HttpClient();
                this.HttpClient.BaseAddress = new Uri(this.BaseApi);
                this.HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                this.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authKey);
            }
        }

        public string GetUrlRequest(ApiContext context, object[] parametros)
        {
          //  this.UrlApi = RequestType.GetUrl(context, parametros);

            //var GET2 = api2.GetRequest();
            //if (GET2 == HttpStatusCode.OK)
            //{
            //    Tutorial result = JsonConvert.DeserializeObject<Tutorial>(api2.retornoAPI);
            //    tutorial = result;
            //}

            return null;
        }

        public ApiResponse GetRequest(ApiContext context, object[] parametros)
        {
            var urlRequest = RequestType.GetUrl(context, parametros);
            var apiResponse = new ApiResponse();

            try
            {
                HttpResponseMessage response = this.HttpClient.GetAsync(urlRequest).Result;
                apiResponse.StatusCode = response.StatusCode;
                
                if (response.IsSuccessStatusCode)
                {
                    apiResponse.Response = response.Content.ReadAsStringAsync().Result;
                }

                return apiResponse;

            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Não foi possível acessar a API {0}{1} - ERROR: {2}", this.BaseApi, urlRequest, ex.Message));
            }
        }

    }
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Response { get; set; }
    }
}
