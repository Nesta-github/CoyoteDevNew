using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using WebNesta.Coyote.Web.Models;

namespace WebNesta.Coyote.Web.Controllers
{
    public class BaseController : Controller
    {
        private ObjectLabel _tela;
        public IEnumerable<ValidationResult> GetModelErrors(object obj)
        {
            var resultadoValidacao = new List<ValidationResult>();
            var contexto = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, contexto, resultadoValidacao, true);
            return resultadoValidacao;
        }

        public string GetModelErrorMessage(List<ValidationResult> validation)
        {
            var message = new StringBuilder();

            if (validation != null && validation.Count > 0)
            {
                validation.ForEach(validate => { message.Append(validate); message.Append("<br />"); });
            }

            return message.ToString();
        }

        public void SetTela(ObjectLabel tela)
        {
            this._tela = tela;
        }

        public ObjectLabel GetTela()
        {
            return this._tela;
        }
    }
}
