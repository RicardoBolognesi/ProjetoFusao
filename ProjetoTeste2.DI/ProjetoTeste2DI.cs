
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoTeste2.Domains;
using ProjetoTeste2.Domains.Entities;
using ProjetoTeste2.Domains.Interfaces.Repository;
using ProjetoTeste2.Domains.Interfaces.Service;
using ProjetoTeste2.Domains.Services;
using ProjetoTeste2.Infra;
using ProjetoTeste2.Infra.Context;
using ProjetoTeste2.Infra.Repositories;

namespace ProjetoTeste2.DI
{

    public static class ProjetoTeste2DI
    {
        public static void Configure(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment env, IApplicationBuilder app)
        {
            ConfigureDbContexts(services, configuration);
            ConfigureSession(services, configuration, env);
            ConfigureIdentity(services, configuration, app);
            ConfigureRepositories(services);
            ConfigureServices(services);
            ConfigureHelpers(services);
        }

        private static void ConfigureDbContexts(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjetoTeste2DbContext>(ops =>
                ops.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void ConfigureSession(IServiceCollection services, IConfiguration configuration, IHostingEnvironment env)
        {
            //If Environment is Development then used Memorycache else use redis 
            if (env.IsDevelopment())
            {
                services.AddMemoryCache();
            }
            else
            {
                //var redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));
                //services.AddDataProtection()
                //    .SetApplicationName("HiveStoreApp")
                //    .PersistKeysToRedis(redis, "DataProtection-Keys");
            }

            int loginExpireTimeSpan = Int32.Parse(configuration?.GetSection("AppSettings")?["LoginExpireTimeSpan"]);

            services.AddSession(options =>
            {
                options.Cookie.Name = "auth_cookie";
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "PROJETOTESTE2";
                options.TableName = "USER_SESSION";
            });

            

        }

        private static void ConfigureIdentity(IServiceCollection services, IConfiguration configuration, IApplicationBuilder app)
        {
            int loginExpireTimeSpan = Int32.Parse(configuration?.GetSection("AppSettings")?["LoginExpireTimeSpan"]);

            services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<ProjetoTeste2DbContext>()
                .AddDefaultTokenProviders();

            services.Configure<SecurityStampValidatorOptions>(options => options.ValidationInterval = TimeSpan.FromSeconds(10));

            services.AddAuthentication()
                .Services.ConfigureApplicationCookie(options =>
                {
                    options.SlidingExpiration = true;
                    //options.ExpireTimeSpan = TimeSpan.FromMinutes(loginExpireTimeSpan);

                    options.Cookie.Name = "auth_cookie";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.LoginPath = new PathString("/Login");
                    options.AccessDeniedPath = "/login";
                    options.ReturnUrlParameter = "/login";
                    options.AccessDeniedPath = "/login";
                    options.LogoutPath = "/login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(1); //set it less for testing purpose
                });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AuthenticatedUser>();
            IdentitySeedData.SeedDatabase(app);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEnderecoTipoService, EnderecoTipoService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void ConfigureHelpers(IServiceCollection services)
        {
            services.AddScoped<IRequestInfoHelper, RequestInfoHelper>();
        }
    }
}
