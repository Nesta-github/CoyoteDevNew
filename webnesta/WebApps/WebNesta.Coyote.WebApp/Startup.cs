using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebNesta.Coyote.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            
            services.AddLocalization(options => options.ResourcesPath = "App_GlobalResources");

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(opt =>
           {
               opt.LoginPath = new PathString("/Conta/Login");
               opt.LogoutPath = new PathString("/Conta/Logout");
               opt.AccessDeniedPath = new PathString("/Erros/AcessoNegado");
               opt.Cookie = new CookieBuilder()
               {
                   Name = ".NomeCookie",
                   Expiration = new System.TimeSpan(0, 120, 0),
                   //Se tiver um domínio...
                   //Domain = ".site.com.br",
               };
           });

            services.AddAuthentication()
               .AddGoogle(options =>
               {
                   IConfigurationSection googleAuthNSection =
                       Configuration.GetSection("Authentication:Google");
                   options.ClientId = googleAuthNSection["ClientId"];
                   options.ClientSecret = googleAuthNSection["ClientSecret"];
               });

            services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            // services.AddMvc()
            //     .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //     .AddDataAnnotationsLocalization();
            //
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();

         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            var supportedCultures = new[] { "pt" ,"en", "es"};

            var localizationOptions = new RequestLocalizationOptions()
            //{
                //ApplyCurrentCultureToResponseHeaders = true
            //}
            .SetDefaultCulture(supportedCultures[0])
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

      
    }
}
