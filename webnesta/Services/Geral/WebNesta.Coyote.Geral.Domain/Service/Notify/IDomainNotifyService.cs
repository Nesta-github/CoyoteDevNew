using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain;
namespace WebNesta.Coyote.Geral.Domain.Service
{
    public interface IDomainNotifyService
    {
        Task SendMessage(Notify mainProperties);
    }
}
