using Microsoft.AspNetCore.Mvc;

namespace WebNesta.Coyote.DocuSign.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
