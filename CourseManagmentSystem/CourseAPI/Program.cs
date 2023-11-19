using CourseAPI.DatabaseContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostreSql");

builder.Services.AddDbContext<PostreSqlDatabaseContext>(opt=>
    opt.UseNpgsql(connectionString, build=>
    build.MigrationsAssembly("CourseAPI")));

builder.Services.AddScoped<DbContext>(prov => prov.GetService<PostreSqlDatabaseContext>());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
