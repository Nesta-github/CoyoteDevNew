namespace WebNesta.Coyote.Core.API
{
    public interface IRequest
    {
        string GetUrl(ApiContext context, object[] parametros);
    }
}
