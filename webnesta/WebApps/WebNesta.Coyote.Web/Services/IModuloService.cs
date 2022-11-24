using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;

namespace WebNesta.Coyote.Web.Services
{
    public interface IModuloService
    {
        Task<TutorialViewModel> GetTutorial(string lang, string enumControllerNameTutorial);
    }
}
