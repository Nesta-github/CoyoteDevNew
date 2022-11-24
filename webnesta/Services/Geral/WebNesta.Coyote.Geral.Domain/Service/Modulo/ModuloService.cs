using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.Data;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class ModuloService : IDomainModuloService<Tutorial>
    {
        public readonly IModuloRepository<Modulo, Tutorial> _repository;

        public ModuloService(IModuloRepository<Modulo, Tutorial> repository)
        {
            _repository = repository;
        }

        public async Task<Tutorial> GetTutorial(string lang, string controllerName)
        {
            Tutorial tutorial = null;

            //baseClass.modulosTuto = modulo.ListarTuto(_lang);
            var modulos = _repository.ListarTuto(lang);
            //var resultTuto = baseClass.modulosTuto.Where(x => x.FSDSFUSI.ToUpper() == _controllerName.ToUpper()).ToList();

            if (modulos != null && modulos.Count > 0)
            {
                modulos = modulos.Where(wh => wh.FSDSFUSI.ToUpper() == controllerName.ToUpper()).ToList();
                if(modulos.Any())
                {
                    tutorial = _repository.GetTutorial(modulos.FirstOrDefault().FSIDFUSI, 0);
                }
            }

            return tutorial;
        }
    }
}
