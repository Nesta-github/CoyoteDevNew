using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain.Service;
using WebNesta.Coyote.Geral.Domain;

namespace WebNesta.Coyote.Geral.API.Controllers
{
    public class ModuloController : Controller
    {
        public readonly IConfiguration _configuration;
        public readonly IDomainModuloService<Tutorial> _moduloService;
        public ModuloController(IDomainModuloService<Tutorial> moduloService, IConfiguration configuration)
        {
            _moduloService = moduloService;
        }

        [HttpGet]
        [Route("modulo")]
        public async Task<Account> Index()
        {

            return null;
        }

        [HttpGet]
        [Route("modulo/gettutorial")]
        public async Task<IActionResult> Index(string lang, string controllerName)
        {
            var tutorial = await _moduloService.GetTutorial(lang, controllerName);
            return Ok(tutorial);
        }


    }
}
