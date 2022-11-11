using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebNesta.Coyote.WebApp.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ICollection<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
{
{ "Mensagens", Erros.ToArray() }
}));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                AdicionarErroProcessamento(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ResponseResult resposta)
        {
            ResponsePossuiErros(resposta);

            return CustomResponse();
        }

        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta == null || !resposta.Errors.Mensagens.Any()) return false;

            foreach (var mensagem in resposta.Errors.Mensagens)
            {
                AdicionarErroProcessamento(mensagem);
            }

            return true;
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }

        protected void AdicionarErroProcessamento(string erro)
        {
            Erros.Add(erro);
        }

        protected void LimparErrosProcessamento()
        {
            Erros.Clear();
        }

    }

    public class ResponseResult
    {
        public ResponseResult()
        {
            Errors = new ResponseErrorMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            Mensagens = new List<string>();
        }

        public List<string> Mensagens { get; set; }
    }
    //public class BaseController : Controller
    //{
    //    protected IConfiguration _configuration;
    //    protected IRequest _requestContext;
    //    protected ApiRequest _nestaRequestApi;
    //    private ApiRequest NestaRequestApi
    //    {
    //        get
    //        {
    //            return _nestaRequestApi;
    //            
    //        }
    //        set
    //        {
    //            _nestaRequestApi = value;
    //            
    //        }
    //
    //    }
    //
    //    public string GetApiRequest(string baseApiUrl, ApiContext context, object[] parametros)
    //    {
    //        if (NestaRequestApi == null)
    //        {
    //            NestaRequestApi = new ApiRequest(_configuration.GetValue<string>("AppSettingsConfiguration:UserApi"),
    //                _configuration.GetValue<string>("AppSettingsConfiguration:PassApi"),
    //                baseApiUrl,
    //            _requestContext);
    //
    //
    //            var response = NestaRequestApi.GetRequest(context, parametros);
    //            var responseString = JsonConvert.SerializeObject(response);
    //
    //            return responseString;
    //        }
    //
    //        return null;
    //    }
    //    public string PostApiRequest<T>(string baseApiUrl, ApiContext context, T model)
    //    {
    //        if (NestaRequestApi == null)
    //        {
    //            NestaRequestApi = new ApiRequest(
    //                _configuration.GetValue<string>("AppSettingsConfiguration:UserApi"),
    //                _configuration.GetValue<string>("AppSettingsConfiguration:PassApi"),
    //                baseApiUrl,
    //            _requestContext);
    //
    //        }
    //
    //        var response = NestaRequestApi.PostRequest(context, model);
    //        var responseString = JsonConvert.SerializeObject(response);
    //
    //        return responseString;
    //    }
    //
    //}


}
