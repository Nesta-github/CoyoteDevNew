using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Core.Data
{
    public interface IComponentRepository<T, Y, Z>
    {
        ICollection<T> GetComponent();
        ICollection<T> GetAllComponent();
        ICollection<T> GetComponentSearch(string term);
        Task<Y> UpdateComponent(Z model);
        Task<Y> InsertComponent(Z model);
        Task<Y> DeleteComponent(int id);

        Dictionary<int, string> GetModelosCombo();
        Dictionary<int, string> GetClasseCombo();
    }
}
