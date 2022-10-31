using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain;

namespace WebNesta.Coyote.Geral.Service
{
    public interface IDomainAccountService
    {
        Account GetAccount(string username, string password);
    }
}