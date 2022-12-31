using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Threading.Tasks;
using WebNesta.Coyote.Geral.Domain.ViewModel;
using WebNesta.Coyote.Web.Models;
using WebNesta.Coyote.Web.Services;
using WebNesta.Coyote.Web.ViewModel;

namespace WebNesta.Coyote.Web.Controllers
{
    public class ComponentController : BaseController
    {
        private readonly IComponentService _componentService;
        private readonly IConfiguration _configuration;

        public ComponentController(IComponentService componentService, IConfiguration configuration)
        {
            _configuration = configuration;
            _componentService = componentService;
            SetTela(ObjectLabel.Componente);
            //_controllerNameTutorial = ControllerTutorialName.Login;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("component/GetData")]
        public async Task<IActionResult> GetData()
        {
            
            
            var modelGrid = await _componentService.GetAllComponent();
            var model = await _componentService.GetData();
            model.Result.Componentes = modelGrid.Result.ToList();
            return Json(model);
        }
        
        [HttpGet]
        [Route("component/search")]
        public async Task<IActionResult> Search(string term)
        {
            if (term == null) term = string.Empty;

            var model = await _componentService.GetComponentSearch(term);
          
            return Json(model);
        }

        [HttpPost]
        [Route("component")]
        public async Task<IActionResult> PostData(int id, string modelo, string descricao, string classe)
        {
            var componentViewModel = new ComponentViewModel();
            componentViewModel.Id = id;
            componentViewModel.Modelo = modelo;
            componentViewModel.Descricao = descricao;
            componentViewModel.Classe = classe;

            ValidateViewModel response = null;

            var validacao = GetModelErrors(componentViewModel);

            if (validacao != null && validacao.Count() > 0)
            {
                response = new ValidateViewModel(false, GetModelErrorMessage(validacao.ToList()));
            }
            else
            {
                await _componentService.InsertComponent(componentViewModel);
            }

            return Json(response);
        }

        [HttpPut]
        [Route("component")]
        public async Task<IActionResult> PutData(int id, string modelo, string descricao, string classe)
        {
            var componentViewModel = new ComponentViewModel();
            componentViewModel.Id = id;
            componentViewModel.Modelo = modelo;
            componentViewModel.Descricao = descricao;
            componentViewModel.Classe = classe;

            ValidateViewModel response = null;

            var validacao = GetModelErrors(componentViewModel);

            if (validacao != null && validacao.Count() > 0)
            {
                response = new ValidateViewModel(false, GetModelErrorMessage(validacao.ToList()));
            }
            else
            {
                await _componentService.UpdateComponent(componentViewModel);
            }

            return Json(response);
        }

        [HttpDelete]
        [Route("component")]
        public async Task<IActionResult> DeleteData(int id)
        {
            var componentViewModel = new ComponentViewModel();
            componentViewModel.Id = id;
            

            ValidateViewModel response = null;

            var validacao = GetModelErrors(componentViewModel);

            if (validacao != null && validacao.Count() > 0)
            {
                response = new ValidateViewModel(false, GetModelErrorMessage(validacao.ToList()));
            }
            else
            {
                await _componentService.DeleteComponent(id);
            }

            return Json(response);
        }
    }
}
