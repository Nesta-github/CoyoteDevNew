using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebNesta.Coyote.Web.Services;

namespace WebNesta.Coyote.Web.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ILoginService, LoginService>();
            services.AddHttpClient<IModuloService, ModuloService>();
            services.AddHttpClient<IComponentService, ComponentService>();
        }
    }
}
