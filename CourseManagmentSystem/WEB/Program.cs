using App.Infrastructure.DatabaseContext;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WEB.Extensions;
using WEB.Utilities.RedisOperations;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddMvc(opt => opt.EnableEndpointRouting = false);

var connectionString = configuration.GetConnectionString("PostreSql");

builder.Services.AddDbContext<PostreSqlDatabaseContext>(opt =>
    opt.UseNpgsql(connectionString, 
    build =>
    build.MigrationsAssembly("App.Infrastructure")));

builder.Services.AddScoped<DbContext>(prov => prov.GetService<PostreSqlDatabaseContext>());


builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureModelFactories();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
{
    opt.Cookie.Name = "courseProject";
    opt.LoginPath = "/Home/Login";
    opt.AccessDeniedPath = "/Home/Login";
});

builder.Services.ConfigureIdentity();

builder.Services.Configure<RouteOptions>(options =>
{
    options.AppendTrailingSlash = true;
});

builder.Services.ConfigureCookie();

var RedisSection = configuration.GetSection("RedisSettings");
var redisHost = RedisSection["Host"];
var redisPort = RedisSection["Port"];

builder.Services.AddSingleton<Connection>( opt =>
{
    var redisSetting = new Connection(redisHost, redisPort);
    redisSetting.Connect();
    return redisSetting;
});

builder.Services.ConfigureRedisService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseMvcWithDefaultRoute();  
app.UseHttpMethodOverride();

app.MigrateDB();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
          name: "areaRoute",
          pattern: "{area:exists}/{controller}/{action}/{id?}");

    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
 
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
 
app.Run();
