
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
//using Microsoft.Owin.Security.OpenIdConnect;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using WebNesta.Coyote.WebApp.Models;
using WebNesta.Coyote.WebApp.Services;

namespace WebNesta.Coyote.WebApp.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
            //_requestContext = new LoginUrlRequest();
        }


     //   [AllowAnonymous]
       
        //[Route("Login")]
        public IActionResult Index()        
        {
            return View();
        }

       // [AllowAnonymous]
        [HttpGet]
        [Route("GetDataLogin")]
        public async Task<IActionResult> GetDataLogin()
        {
            var model = new LoginViewModel();

            //captcha
            //model.Captcha = new Captcha("qwertyuioplkjhgfdsamnbvcxz12345678", 5);
            //ViewBag.CharacterSet = "qwertyuioplkjhgfdsamnbvcxz12345678";  
            //ViewBag.CodeLength = 5;

            #region 3 - GOOGLE E FORMS AUTH
         
           //model.Key_2FAGoogle = _configuration.GetValue<bool>("AppSettingsConfiguration:2FA_Google");
           //
           //model.Valida = false;
            #endregion
            
            return Json(model); 
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("Autentica")]
        public async Task<IActionResult> Autentica(string username, string password)
        {
            var authViewModel = new AuthViewModel(username, password);
            _loginService.Login(authViewModel);
          // var response = 
          //     PostApiRequest<AuthViewModel>(
          //         _configuration.GetValue<string>("WebNestaAPI:WebNestaAPI_Geral"), 
          //         ApiContext.Login, 
          //         authViewModel);

            return View();
        }
    }
}
