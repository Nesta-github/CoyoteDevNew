using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebNesta.Coyote.Componente.Domain.Service;
using WebNesta.Coyote.Componente.Domain;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.API;
using System.Collections.Generic;
using WebNesta.Coyote.Componente.API.ViewModel;
using WebNesta.Coyote.Componente.Domain.ViewModel;

namespace WebNesta.Coyote.Componente.API.Controllers
{
    public class ComponentController : Controller
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
            return View();
        }

        [HttpGet]
        [Route("component/GetAllComponent")]
        public async Task<IActionResult> GetAllComponent()
        {
            var model = new ResponseResultGeneric<ICollection<CHCOMPOT>>();
            model.Result = await _componentService.GetAllComponent();

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
