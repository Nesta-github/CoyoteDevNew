using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain.ViewModel;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public interface IDomainAccountService
    {
        ValidateViewModel GetAccount(string username, string password, string lang);

        ValidateViewModel RecoveryPassword(string emailRecoveryPassword, string lang);
        //Task<ValidateViewModel> RecoveryPassword(string emailRecoveryPassword);
    }
}