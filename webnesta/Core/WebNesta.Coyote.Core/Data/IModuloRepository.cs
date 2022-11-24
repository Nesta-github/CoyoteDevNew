using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebNesta.Coyote.Core.Data
{
    public interface IModuloRepository<T,Y>
    {
        List<T> ListarTuto(string lang);

        Y GetTutorial(long moduloId, int TUTOORDE);
    }
}
