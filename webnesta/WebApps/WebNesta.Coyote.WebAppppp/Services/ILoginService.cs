using System.Threading.Tasks;
using WebNesta.Coyote.WebApp.Controllers;
using WebNesta.Coyote.WebApp.Models;

namespace WebNesta.Coyote.WebApp.Services
{
    public interface ILoginService
    {
        Task<ResponseResult> Login(AuthViewModel model);
    }
}
