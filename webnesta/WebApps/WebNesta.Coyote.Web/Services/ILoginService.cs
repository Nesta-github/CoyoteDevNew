using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;
using WebNesta.Coyote.Geral.Domain.ViewModel;
namespace WebNesta.Coyote.Web.Services
{
    public interface ILoginService
    {
        Task<ValidateViewModel> Login(AuthViewModel model);
        Task<ResponseResult> GetObjectVersion(string page);
        // Task<ValidateViewModel> RecoveryPassword(RecoveryPasswordViewModel emailRecoveryPassword);
        Task<string> RecoveryPassword(RecoveryPasswordViewModel emailRecoveryPassword);     
    }
}
