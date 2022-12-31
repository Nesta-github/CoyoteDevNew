using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;
using WebNesta.Coyote.Web.Models;
using WebNesta.Coyote.Geral.Domain.ViewModel;
using System.Collections.Generic;

namespace WebNesta.Coyote.Web.Services
{
    public interface IComponentService
    {
        Task DeleteComponent(int id);
        Task<ResponseResultGeneric<ICollection<Component>>> GetAllComponent();
        Task<ResponseResultGeneric<ICollection<Component>>> GetComponentSearch(string term);
        Task<ResponseResultGeneric<DataComponentViewModel>> GetData();
        Task InsertComponent(ComponentViewModel componentViewModel);
        Task UpdateComponent(ComponentViewModel componentViewModel);
    }
}
