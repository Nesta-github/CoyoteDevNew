using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain;
using WebNesta.Coyote.Geral.Domain.ViewModel;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public interface IDomainAccountService
    {
        string GetAccount(string username, string password);
        
       // Task<ValidateViewModel> RecoveryPassword(string emailRecoveryPassword);
        string RecoveryPassword(string emailRecoveryPassword);
    }
}