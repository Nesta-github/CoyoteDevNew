using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNesta.Coyote.Web.Configuration;

namespace WebNesta.Coyote.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration();

            services.AddMvcConfiguration(Configuration);

            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "App_GlobalResources";
            });

            services.AddMvc()
             .AddViewLocalization(

              LanguageViewLocationExpanderFormat.SubFolder,
              opts =>
              {
                  opts.ResourcesPath = "App_GlobalResources";
              })
             .AddDataAnnotationsLocalization()
             .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication("CookieAuthentication")
       .AddCookie("CookieAuthentication", config =>
       {
           config.Cookie.Name = "UserLoginCookie";
           config.LoginPath = "/Login";
           config.AccessDeniedPath = "/Login";
       });


            services.RegisterServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Quem é você?
            app.UseAuthentication();

            // Verifica Permissões
            app.UseAuthorization();

            app.UseMvcConfiguration(env);
        }
    }
}
