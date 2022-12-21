using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebNesta.Coyote.Componente.Domain.ViewModel;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Core.Domain;

namespace WebNesta.Coyote.Componente.Domain.Service
{
    public class ComponentService : IDomainService, IComponentService<CHCOMPOT>
    {
        public readonly IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel> _repository;
        public IConfiguration _config;
        public ComponentService(IComponentRepository<CHCOMPOT, ValidateViewModel, ComponentViewModel> repository, IConfiguration config)
        {
            _config = config;
            _repository = repository;
        }

        public Task<ValidateViewModel> DeleteComponent(int id)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = await _repository.DeleteComponent(id);
            }
            catch (Exception ex)
            {

                throw;
            }

            return validateModel;
        }

        public Task<ICollection<CHCOMPOT>> GetAllComponent()
        {
            return await _repository.GetAllComponent();
        }

        public Task<ValidateViewModel> InsertComponent(ComponentViewModel model)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = await _repository.InsertComponent(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return validateModel;
        }

        public Task<ValidateViewModel> UpdateComponent(ComponentViewModel model)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = await _repository.UpdateComponent(model);
            }
            catch (Exception ex)
            {

                throw;
            }

            return validateModel;
        }
    }
}
