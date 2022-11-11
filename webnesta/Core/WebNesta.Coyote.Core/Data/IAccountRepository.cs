using System.Threading.Tasks;

namespace WebNesta.Coyote.Core.Data
{
    public interface IAccountRepository<T,Y>
    {
        Y GetAccountByEmail(string email);
        T GetCredential(string username);
        string ValidateAccountAccess(string username, string password);
        void UpdateAccessAccount(string username);
        string ResetCredential(string username, string code);
    }
}
