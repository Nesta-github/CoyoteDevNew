using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;
using WebNesta.Coyote.Geral.Domain.ViewModel;
using System.Collections.Generic;

namespace WebNesta.Coyote.Web.Services
{
    public interface IComponentService
    {
        Task<ValidateViewModel> DeleteComponent(int id);
        Task<ResponseResultGeneric<ICollection<Component>>> GetAllComponent();
        Task<ResponseResultGeneric<ICollection<Component>>> GetComponentSearch(string term);
        Task<ResponseResultGeneric<DataComponentViewModel>> GetData(string lang);
        Task<ValidateViewModel> InsertComponent(ComponentViewModel componentViewModel);
        Task<ValidateViewModel> UpdateComponent(ComponentViewModel componentViewModel);
    }
}
