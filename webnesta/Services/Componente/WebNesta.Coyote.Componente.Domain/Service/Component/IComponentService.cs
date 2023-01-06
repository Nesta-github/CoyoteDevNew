using System.Collections.Generic;
using System.Threading.Tasks;
using WebNesta.Coyote.Componente.Domain.ViewModel;

namespace WebNesta.Coyote.Componente.Domain.Service
{
    public interface IComponentService<T>
    {
        Task<ValidateViewModel> DeleteComponent(int id);
        ICollection<T> GetAllComponent();
        Task<ValidateViewModel> InsertComponent(ComponentViewModel model);
        Task<ValidateViewModel> UpdateComponent(ComponentViewModel model);
        DataComponentViewModel GetData(string lang);
        ICollection<T> GetComponentSearch(string term);
    }
}
