using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;

namespace WebNesta.Coyote.Web.Services
{
    public interface ILoginService
    {
        Task<ResponseResult> Login(AuthViewModel model);
        Task<ResponseResult> GetObjectVersion(string page);
        Task<ResponseResult> RecoveryPassword(RecoveryPasswordViewModel emailRecoveryPassword);
        
    }
}
