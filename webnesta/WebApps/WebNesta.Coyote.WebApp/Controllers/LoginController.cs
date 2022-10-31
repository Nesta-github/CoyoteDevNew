
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections;
using System.Net;
using WebNesta.Coyote.Core.API;
using WebNesta.Coyote.Core.API.Login;
using WebNesta.Coyote.WebApp.ViewModel;
using WebNesta.Coyote.Core.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace WebNesta.Coyote.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _requestContext = new LoginUrlRequest();
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult GetDataLogin(bool error = false)
        {
            var model = new LoginViewModel();

            #region 1
            //1 - LEGADO 
            /* 
            
            Tutorial tutorial = new Tutorial();
            //tutorial.FSIDFUSI = 0;
            //tutorial.TUTOORDE = 0;
            //tutorial.Carregar();
            API_Request api2 = new API_Request();
            api2.userAPI = WebConfigurationManager.AppSettings["userAPI"];
            api2.passAPI = WebConfigurationManager.AppSettings["passAPI"];
            api2.baseAPI = WebConfigurationManager.AppSettings["baseAPI"];
            api2.urlAPI = string.Format("api/v1/Tutorial/Carregar?currentUser={0}&_FSIDFUSI={1}&_TUTOORDE={2}", "Teste", 0, 0);
            HttpStatusCode GET = api2.GetRequest();
            if (GET == HttpStatusCode.OK)
            {
                Tutorial result = JsonConvert.DeserializeObject<Tutorial>(api2.retornoAPI);
                tutorial = result;
            }
            ViewBag.Tutorial = tutorial;*/

            //1 - REFATORADO
            //var response = GetApiRequest(ApiContext.LoginTutorialCarregar, new object[] {
            //    "Teste", 0, 0
            //});
            //
            //var objectDeserialize = JsonConvert.DeserializeObject<ApiResponse>(response);
            //
            //if (objectDeserialize.StatusCode == HttpStatusCode.OK)
            //{
            //    model.Tutorial = JsonConvert.DeserializeObject<Models.Tutorial>(objectDeserialize.Response);
            //}
            // 1 - FIM
            #endregion

            #region 2
            //2 - LEGADO 
            /*
            Models.Login login = new Models.Login();

            if (error)
            {
                ViewBag.MsgErrorLogin = "Usuário não cadastrado.";
            }
            */
            //2 - REFATORADO
            //if (error)
            //{
            //    ViewBag.MsgErrorLogin = "Usuário não cadastrado.";
            //}
            //2 - FIM
            #endregion

            //captcha
            //model.Captcha = new Captcha("qwertyuioplkjhgfdsamnbvcxz12345678", 5);
            //ViewBag.CharacterSet = "qwertyuioplkjhgfdsamnbvcxz12345678";
            //ViewBag.CodeLength = 5;

            #region 3 - GOOGLE E FORMS AUTH
            //3
            /* bool _2FA_Google = Convert.ToBoolean(WebConfigurationManager.AppSettings["2FA_Google"]);
            ViewBag._2FA_Google = _2FA_Google;
            ViewBag.Valida = false;
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            if (authCookie == null)
                return View(login);
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                string UserName = ticket.Name; //You have the UserName!
                return View(login);
            }*/
            model.Key_2FAGoogle = _configuration.GetValue<bool>("AppSettingsConfiguration:2FA_Google");

            model.Valida = false;
            #endregion

            
            return Json(model); 
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }

        //public void SignIn(string provider)
        //{
        //    if (provider == "azure")
        //    {
        //        HttpContext.GetOwinContext().Authentication.Challenge(
        //            new AuthenticationProperties { RedirectUri = "AzureLoginCallback" },
        //            OpenIdConnectAuthenticationDefaults.AuthenticationType);
        //    }
        //    else if (provider == "google")
        //    {
        //        HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
        //        { RedirectUri = "Login/GoogleLoginCallback" }, "Google");
        //    }
        //}


    }
}
