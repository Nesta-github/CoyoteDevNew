using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Core.Data
{
    public interface IComponentRepository<T, Y, Z>
    {
        ICollection<T> GetComponent();
        ICollection<T> GetAllComponent();
        ICollection<T> GetComponentSearch(string term);
        Y UpdateComponent(Z model);
        Y InsertComponent(Z model);
        Y DeleteComponent(int id);

        Dictionary<decimal, string> GetModelosCombo(string lang);
        Dictionary<decimal, string> GetClasseCombo();
    }
}
