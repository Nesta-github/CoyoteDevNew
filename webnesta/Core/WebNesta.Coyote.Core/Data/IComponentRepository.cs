using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Core.Data
{
    public interface IComponentRepository<T, Y, Z>
    {
        Task<ICollection<T>> GetComponent();
        Task<ICollection<T>> GetAllComponent();
        Task<Y> UpdateComponent(Z model);
        Task<Y> InsertComponent(Z model);
        Task<Y> DeleteComponent(int id);
    }
}
