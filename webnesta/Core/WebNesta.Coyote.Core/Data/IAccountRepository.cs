using System.Threading.Tasks;

namespace WebNesta.Coyote.Core.Data
{
    public interface IAccountRepository<T>
    {
        T GetAccount(string username, string password);
        bool ValidateAccountAccess(string username, string password);  
    }
}
