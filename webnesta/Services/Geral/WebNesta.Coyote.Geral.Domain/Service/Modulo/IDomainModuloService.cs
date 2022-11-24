using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public interface IDomainModuloService<T>
    {
        Task<T> GetTutorial(string lang, string controllerName);
    }
}
