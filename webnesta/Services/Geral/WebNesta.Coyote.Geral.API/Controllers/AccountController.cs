using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using WebNesta.Coyote.Geral.API.ViewModel;
using WebNesta.Coyote.Geral.Domain;
using WebNesta.Coyote.Geral.Domain.Service;
using WebNesta.Coyote.Geral.Domain.ViewModel;

namespace WebNesta.Coyote.Geral.API.Controllers
{
    [ApiController]
    //[Route("account")]
    public class AccountController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IDomainAccountService _accountService;
        public readonly IDomainVersionService _versionService;
        public AccountController(IDomainAccountService accountService, IDomainVersionService versionService, IConfiguration configuration)
        {
            _configuration = configuration;
            _accountService = accountService;
            _versionService = versionService;
        }

        [HttpGet]
        [Route("account")]
        public async Task<Account> Index()
        {

            return null;
        }

        [HttpGet]
        [Route("account/getlogindata/{page}")]
        public async Task<IActionResult> GetLoginData(string page)
        {
            var model = _versionService.GetObjectVersion(page);
            return Ok(model);
        }

        [HttpGet]
        [Route("account/getuserbyusername/{username}")]
        public async Task<IActionResult> GetAccount(string username, string password, string lang)
        {
            var account = string.Empty;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
            //    account = _accountService.GetAccount(username, password, lang);
            }
            return Ok(account);
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(AuthViewModel model)
        {
            ValidateViewModel account = null;

            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                account = _accountService.GetAccount(model.UserName, model.Password, model.Lang);
            }

            return Ok(account);
        }

        [HttpPost]
        [Route("account/recoverypassword")]
      //  public async Task<ValidateViewModel> RecoveryPassword(RecoveryPasswordViewModel model)
        public ValidateViewModel RecoveryPassword(RecoveryPasswordViewModel model)
        {
            ValidateViewModel validateViewModel = null;
            
            if (model != null && !string.IsNullOrEmpty(model.Email))
            {
                //response = await _accountService.RecoveryPassword(model.Email);
                validateViewModel =  _accountService.RecoveryPassword(model.Email);
            }

            return validateViewModel;
        }
    }
}
