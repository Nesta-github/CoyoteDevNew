using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNesta.Coyote.Componente.Domain.Service;
using WebNesta.Coyote.Componente.Domain;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.API;
using System.Collections.Generic;
using WebNesta.Coyote.Componente.API.ViewModel;
using WebNesta.Coyote.Componente.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace WebNesta.Coyote.Componente.API.Controllers
{
    [Route("component")]
    [ApiController]

    public class ComponentController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public readonly IComponentService<CHCOMPOT> _componentService;

        public ComponentController(IConfiguration configuration, IComponentService<CHCOMPOT> componentService)
        {
            _configuration = configuration;
            _componentService = componentService;
        }

        public IActionResult Index()
        {
            return null;
        }

        [HttpGet]
        //[Route("GetData")]
        [Route("GetData")]
        public async Task<IActionResult> GetData()
        {
            // var modelGrid = new ResponseResultGeneric<ICollection<CHCOMPOT>>();
            // modelGrid.Result = _componentService.GetAllComponent();
            var model = new ResponseResultGeneric<DataComponentViewModel>();
            model.Result = _componentService.GetData();
            // model.Result.Componentes = modelGrid.Result.ToList();
            return Ok(model);
        }
        
        [HttpGet]
        [Route("GetAllComponent")]
      //  [Route("component/GetAllComponent")]
        public async Task<IActionResult> GetAllComponent()
        {
            var model = new ResponseResultGeneric<ICollection<CHCOMPOT>>();
            model.Result = _componentService.GetAllComponent();

            return Ok(model);
        } 

        [HttpGet]
        [Route("search/{term}")]
        //[Route("component/search")]
        public async Task<IActionResult> search(string term)
        {
            var model = new ResponseResultGeneric<ICollection<CHCOMPOT>>();
            model.Result = _componentService.GetComponentSearch(term);

            return Ok(model);
        }

        [HttpPost]
        [Route("component")]
        public async Task<IActionResult> InsertComponent(ComponentViewModel model)
        {
            ValidateViewModel validate = null;
            validate = await _componentService.InsertComponent(model);

            return Ok(validate);
        }

        [HttpPut]
        [Route("component")]
        public async Task<IActionResult> UpdateComponent(ComponentViewModel model)
        {
            ValidateViewModel validate = null;
            validate = await _componentService.UpdateComponent(model);

            return Ok(validate);
        }

        [HttpDelete]
        [Route("component")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            ValidateViewModel validate = null;
            validate = await _componentService.DeleteComponent(id);

            return Ok(validate);
        }
    }
}
