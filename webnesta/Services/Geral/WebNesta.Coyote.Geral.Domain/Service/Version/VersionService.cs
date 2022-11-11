using System;
using System.Collections.Generic;
using System.Text;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Core.Domain;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class VersionService : IDomainService, IDomainVersionService
    {
        public readonly IVersionRepository _repository;
        public VersionService(IVersionRepository repository)
        {
            _repository = repository;
        }

        public string GetObjectVersion(string page)
        {
            var result = _repository.GetVersion(page);
            return result;
        }
    }
}
