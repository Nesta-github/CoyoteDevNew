using Google.Authenticator;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
        private readonly ControllerTutorialName _controllerNameTutorial;
        private readonly ILoginService _loginService;
        private readonly IModuloService _moduloService;
        private readonly IStringLocalizer<WebNesta.Coyote.Web.App_GlobalResources.Login> _localizer;
        public LoginController(ILoginService loginService, IStringLocalizer<WebNesta.Coyote.Web.App_GlobalResources.Login> localizer, IModuloService moduloService)
        {
            _loginService = loginService;
            _tela = ObjectLabel.Login;
            _controllerNameTutorial = ControllerTutorialName.Login;
            _localizer = localizer;
            _moduloService = moduloService;
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
            var directory = string.Concat("wwwroot/img/captcha/", DateTime.Now.Year, "-", DateTime.Now.Month, "-", DateTime.Now.Day - 1);

            if (System.IO.Directory.Exists(directory))
            {
                DeleteDirectory(directory);
            }

            var model = new LoginViewModel();
            var enumDesc = _tela.DescriptionAttr();
            var responseVersion = await _loginService.GetObjectVersion(enumDesc);
            model.TelaVersion = responseVersion.Title;

            #region 3 - GOOGLE E FORMS AUTH
            //model.Key_2FAGoogle = _configuration.GetValue<bool>("AppSettingsConfiguration:2FA_Google");
            //
            //model.Valida = false;
            #endregion

            //((Microsoft.AspNetCore.Http.DefaultHttpContext)HttpContext).User.Identities
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                model.UserName = HttpContext.User.Identity.Name;
            }

            return Json(model);
        }

        //[AllowAnonymous]
        [HttpPost]
        [Route("login/Autentica")]
        public async Task<IActionResult> Autentica(string username, string password, bool remember, string lang)
        {
            var authViewModel = new AuthViewModel();
            var loginResponseViewModel = new LoginResponseViewModel();
            authViewModel.UserName = username;
            authViewModel.Password = password;
            authViewModel.Lang = lang;

            var response = await _loginService.Login(authViewModel);

            bool parseRemember = remember;

            loginResponseViewModel.IsSuccess = true;//response.IsValid;
            loginResponseViewModel.Message = response.Message;
           
            if (response.IsValid)
            {
                if (parseRemember)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, username),
                    };
                    var minhaIdentity = new ClaimsIdentity(userClaims, "LembraAcesso");
                    var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });

                    //cria o cookie
                    HttpContext.SignInAsync(userPrincipal);
                }

                loginResponseViewModel.CaptchaImagePath = GenerateCaptcha(loginResponseViewModel);
            }
            
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

        #region CAPTCHA
        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                System.IO.File.SetAttributes(file, FileAttributes.Normal);
                System.IO.File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }

            Directory.Delete(target_dir, false);
        }

        [HttpGet]
        [Route("login/RefreshCaptcha")]
        public async Task<IActionResult> RefreshCaptcha(string oldCaptcha)
        {
            var response = new LoginResponseViewModel();
            var directory = string.Concat("wwwroot/img/captcha/", DateTime.Now.Year, "-", DateTime.Now.Month, "-", DateTime.Now.Day);
            var fileName = oldCaptcha;
            var fileNameFull = string.Concat(directory, "/", fileName, ".jpg");
            System.IO.File.Delete(fileNameFull);
            GenerateCaptcha(response);
            return Json(response);
        }

        [HttpGet]
        [Route("login/ValidateCaptcha")]
        public async Task<IActionResult> ValidateCaptcha(string oldCaptcha)
        {
            var response = new LoginResponseViewModel();
            var directory = string.Concat("wwwroot/img/captcha/", DateTime.Now.Year, "-", DateTime.Now.Month, "-", DateTime.Now.Day);
            var fileName = oldCaptcha;
            var fileNameFull = string.Concat(directory, "/", fileName, ".jpg");
            System.IO.File.Delete(fileNameFull);
            GenerateCaptcha(response);
            return Json(response);
        }

        public string GenerateCaptcha(LoginResponseViewModel model)
        {
            try
            {
                var directory = string.Concat("wwwroot/img/captcha/", DateTime.Now.Year, "-", DateTime.Now.Month, "-", DateTime.Now.Day);
                var fileName = Guid.NewGuid();
                var fileNameFull = string.Concat(directory, "/", fileName, ".jpg");
                var fileNameFullFrontEnd =
string.Concat("/img/captcha/", DateTime.Now.Year, "-", DateTime.Now.Month, "-", DateTime.Now.Day, "/", fileName, ".jpg");
                System.IO.Directory.CreateDirectory(directory);
                System.IO.File.Copy(@"wwwroot/img/captcha/captcha-model.jpg", fileNameFull);

                string code = ImageFactory.CreateCode(5);

                var codeClaim = new Claim("captchaCode", code);

                using (FileStream fs = System.IO.File.OpenWrite(fileNameFull))

                //(code, 50, 150, 30, 0/*10*/)
                using (Stream picStream = ImageFactory.BuildImage(code,
                    40, //heigth
                    98, //width
                    19, //font-size
                    3)) //distorção curva
                {
                    picStream.CopyTo(fs);
                }

                if (model != null)
                {
                    model.CaptchaImagePath = fileNameFullFrontEnd;
                    model.CaptchaCode = code;
                    model.FileNameCaptcha = fileName.ToString();
                }

                return fileNameFullFrontEnd;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                throw;
            }
        }


        #endregion

        #region TUTORIAL
        [HttpGet]
        [Route("login/Tutorial")]
        public async Task<IActionResult> Tutorial(string lang)
        {
            var enumControllerNameTutorial = _controllerNameTutorial.DescriptionAttr();
            lang = "pt-BR";
            var responseTutorial = await _moduloService.GetTutorial(lang, enumControllerNameTutorial);
            //     model.TelaVersion = responseVersion.Title;


            return Json(responseTutorial);
        }
        #endregion


        #region GOOGLE AUTHENTICATOR

        [HttpGet]
        public IActionResult GoogleAuthenticator()
        {
            TwoFactorAuthenticator twoFactorAuthenticator = new TwoFactorAuthenticator();
            return null;
        }
        #endregion


        [HttpGet]
        [Route("login/GetTela")]
        public IActionResult GetTela()
        {
            return View();
        }
    }
}
