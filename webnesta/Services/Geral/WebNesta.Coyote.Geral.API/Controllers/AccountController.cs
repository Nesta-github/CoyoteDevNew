using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
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

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(AuthViewModel model)
        {
            var account = string.Empty;

            if (model != null && !string.IsNullOrEmpty(model.UserName) && !string.IsNullOrEmpty(model.Password))
            {
                account = _accountService.GetAccount(model.UserName, model.Password);
            }

            return Ok(account);
        }

        [HttpPost]
        [Route("account/recoverypassword")]
        public /*async */ IActionResult RecoveryPassword(RecoveryPasswordViewModel model)
        {
            //var response = new ValidateViewModel(false,"");
            var response = string.Empty;

            if (model != null && !string.IsNullOrEmpty(model.Email))
            {
                //response = await _accountService.RecoveryPassword(model.Email);
                response = _accountService.RecoveryPassword(model.Email);
            }

            return Ok(response);
        }
    }
}
