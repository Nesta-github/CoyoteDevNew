using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebNesta.Coyote.WebApp.Services;

namespace WebNesta.Coyote.WebApp.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ILoginService, LoginService>();
        }
    }
}
