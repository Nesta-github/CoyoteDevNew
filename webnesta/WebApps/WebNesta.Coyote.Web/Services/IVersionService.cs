using System.Threading.Tasks;

namespace WebNesta.Coyote.Web.Services
{
    public interface IVersionService
    {
        Task<string> GetObjectVersion(string page);
    }
}
