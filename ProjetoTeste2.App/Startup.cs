using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ProjetoTeste2.DI;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Infra.Context;

namespace ProjetoTeste2.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env, IApplicationBuilder app)
        {
            Configuration = configuration;
            Env = env;
            App = app;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }
        public IApplicationBuilder App { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });

            //services.AddDbContext<ProjetoTeste2DbContext>(ops =>
            //    ops.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //services.AddIdentity<User, Role>()
            //    .AddEntityFrameworkStores<ProjetoTeste2DbContext>()
            //    .AddDefaultUI()
            //    .AddDefaultTokenProviders();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            ProjetoTeste2DI.Configure(services, Configuration, Env, App);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //app.UsePathBase(new Microsoft.AspNetCore.Http.PathString("/HiveStoreApp"));

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
