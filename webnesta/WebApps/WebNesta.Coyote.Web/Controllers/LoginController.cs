using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Extensions;
using WebNesta.Coyote.Web.Models;
using WebNesta.Coyote.Web.Services;
using WebNesta.Coyote.Web.ViewModel;

namespace WebNesta.Coyote.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ObjectLabel _tela; 
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
            _tela = ObjectLabel.Login;
            //_requestContext = new LoginUrlRequest();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("login/GetDataLogin")]
        public async Task<IActionResult> GetDataLogin()
        {
            var model = new LoginViewModel();
            var enumDesc = _tela.DescriptionAttr();
            var responseVersion = await _loginService.GetObjectVersion(enumDesc);
            model.TelaVersion = responseVersion.Title;
            //captcha
            //model.Captcha = new Captcha("qwertyuioplkjhgfdsamnbvcxz12345678", 5);
            //ViewBag.CharacterSet = "qwertyuioplkjhgfdsamnbvcxz12345678";  
            //ViewBag.CodeLength = 5;

            #region 3 - GOOGLE E FORMS AUTH

            //model.Key_2FAGoogle = _configuration.GetValue<bool>("AppSettingsConfiguration:2FA_Google");
            //
            //model.Valida = false;
            #endregion

            //var versao  = _loginService.GetObjectVersion(_tela.ToString())

            return Json(model);
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("login/Autentica")]
        public async Task<IActionResult> Autentica(string username, string password)
        {
            var authViewModel = new AuthViewModel();
            authViewModel.UserName = username;
            authViewModel.Password = password;
            
            var response = await _loginService.Login(authViewModel);

            return Json(response);
        }

        [HttpPost]
        [Route("login/RecoveryPassword")]
        public async Task<IActionResult> RecoveryPassword(string emailRecoveryPassword)
        {
            var emailRecoveryViewModel = new RecoveryPasswordViewModel();
            emailRecoveryViewModel.Email = emailRecoveryPassword;

            var response = await _loginService.RecoveryPassword(emailRecoveryViewModel);
            return Json(response);
        }

    }
}
