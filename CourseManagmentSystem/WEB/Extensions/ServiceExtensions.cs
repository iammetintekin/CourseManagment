using App.Application.LoadServices;
using App.Application.Services;
using App.Application.Services.Abstract;
using App.Infrastructure.DatabaseContext;
using App.Infrastructure.RepositoryPattern.UnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Configuration;
using WEB.Factories;
using WEB.Factories.Abstract;
using WEB.Utilities.RedisOperations;

namespace WEB.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWorkManager>();
        }
        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IUserService, UserService>();
        }
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
        }
        public static void ConfigureModelFactories(this IServiceCollection services)
        {
            services.AddScoped<IHomeFactory, HomeFactory>();
            services.AddScoped<IBasketFactory, BasketFactory>();
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        { 
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<PostreSqlDatabaseContext>()
            .AddDefaultTokenProviders();
 
        }
        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Home/Login");
                options.LogoutPath = new PathString("/Home/Logout");
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // tarayici kapand�ktan 15 dk sonra logout yapt�r�r.
                options.AccessDeniedPath = new PathString("/Home/Index/");
            }); 
        }
        //IRedisService
        public static void ConfigureRedisService(this IServiceCollection services)
        {
            services.AddScoped<IRedisService, RedisManager>(); 
        }

    }
}
