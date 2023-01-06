using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public async Task<ValidateViewModel> DeleteComponent(int id)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = _repository.DeleteComponent(id);
            }
            catch (Exception ex)
            {
                validateModel = new ValidateViewModel(false, ex.Message);
                return validateModel;
            }

            return validateModel;
        }

        public ICollection<CHCOMPOT> GetAllComponent()
        {
            return _repository.GetAllComponent();
        }

        public ICollection<CHCOMPOT> GetComponentSearch(string term)
        {
            return !string.IsNullOrEmpty(term) ? _repository.GetComponentSearch(term) : _repository.GetAllComponent();
        }

        public DataComponentViewModel GetData(string lang)
        {
            var model = new DataComponentViewModel();

            var classesDictionary = _repository.GetClasseCombo();
            var modelosDictionary = _repository.GetModelosCombo(lang);

            var classes = new List<Classe>();
            var modelos = new List<Modelo>();

            foreach (var classe in classesDictionary.ToList())
            {
                classes.Add(new Classe() { Id = classe.Key, Descricao = classe.Value });
            }

            foreach (var modelo in modelosDictionary.ToList())
            {
                modelos.Add(new Modelo() { Id = modelo.Key, Descricao = modelo.Value });
            }

            model.Classes = classes;
            model.Modelos = modelos;

            return model;
        }

        public async Task<ValidateViewModel> InsertComponent(ComponentViewModel model)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = _repository.InsertComponent(model);

            }
            catch (Exception ex)
            {
                validateModel = new ValidateViewModel(false, ex.Message);
                return validateModel;
            }

            return validateModel;
        }

        public async Task<ValidateViewModel> UpdateComponent(ComponentViewModel model)
        {
            ValidateViewModel validateModel = null;

            try
            {
                validateModel = _repository.UpdateComponent(model);

            }
            catch (Exception ex)
            {
                validateModel = new ValidateViewModel(false, ex.Message);
                return validateModel;
            }

            return validateModel;
        }
    }
}
