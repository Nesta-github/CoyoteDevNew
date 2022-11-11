using System;
using System.Collections.Generic;
using System.Text;

namespace WebNesta.Coyote.Core.Data
{
    public interface IVersionRepository
    {
        string GetVersion(string page);
    }
}
