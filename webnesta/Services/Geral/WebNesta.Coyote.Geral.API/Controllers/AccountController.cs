using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain;
using WebNesta.Coyote.Geral.Service;

namespace WebNesta.Coyote.Geral.API.Controllers
{
    [ApiController]
    [Route("Account")]
    public class AccountController : ControllerBase
    {
        public readonly IDomainAccountService _accountService;
        public AccountController(IDomainAccountService accountService)
        {
            _accountService = accountService;   
        }

        [HttpGet]
        public Account Index(string username, string password)
        {
            return _accountService.GetAccount(username, password);
        }
    }
}
