using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Resources;
using System.Net;
using WebNesta.Coyote.Core.API;
using WebNesta.Coyote.Core.API.Login;
using WebNesta.Coyote.WebApp.Extensions;

namespace WebNesta.Coyote.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected IConfiguration _configuration;
        protected IRequest _requestContext;
        protected ApiRequest _nestaRequestApi;
        private ApiRequest NestaRequestApi
        {
            get
            {
                return _nestaRequestApi;
              //  return WebNesta.Coyote.WebApp.Extensions.SessionExtensions.Get<ApiRequest>(HttpContext.Session, "ApiResquest");
            }
            set
            {
                _nestaRequestApi = value;
              //  WebNesta.Coyote.WebApp.Extensions.SessionExtensions.Set<ApiRequest>(HttpContext.Session, "ApiResquest", value);
            }

        }

        public string GetApiRequest(ApiContext context, object[] parametros)
        {
            if (NestaRequestApi == null)
            {
                NestaRequestApi = new ApiRequest(_configuration.GetValue<string>("AppSettingsConfiguration:UserApi"),
                    _configuration.GetValue<string>("AppSettingsConfiguration:PassApi"),
                    _configuration.GetValue<string>("AppSettingsConfiguration:BaseApi"),
                _requestContext);

               // HttpContext.Session.Set("ApiResquest",
              // System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(_nestaRequestApi));
                //JsonSerializer.SerializeToUtf8Bytes(value)
                 //WebNesta.Coyote.WebApp.Extensions.SessionExtensions.Set<ApiRequest>(HttpContext.Session, "ApiResquest", _nestaRequestApi);
             //   NestaRequestApi = _nestaRequestApi;
            }

            //   return new JsonResult()
            //  {
            //      data = NestaRequestApi.GetRequest(context, parametros),
            //      JsonRequestBehavior = JsonRequestBehavior.DenyGet
            //  };
            var response = NestaRequestApi.GetRequest(context, parametros);
            var responseString = JsonConvert.SerializeObject(response);

            return responseString;

            // HttpStatusCode GET2 = api2.GetRequest();
            // if (GET2 == HttpStatusCode.OK)
            // {
            //     Tutorial result = JsonConvert.DeserializeObject<Tutorial>(api2.retornoAPI);
            //     tutorial = result;
            // }
        }
    }
}
