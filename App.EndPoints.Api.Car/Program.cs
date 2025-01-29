using App.Domain.AppServices.Car.CarModel;
using App.Domain.AppServices.Car.OPrator;
using App.Domain.AppServices.Car.User;
using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Data.Repositories;
using App.Domain.Core.Car.CarModel.Services;
using App.Domain.Core.Car.Configs;
using App.Domain.Core.Car.OPrator.AppServices;
using App.Domain.Core.Car.OPrator.Data.Repositories;
using App.Domain.Core.Car.OPrator.Services;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Data.Repositories;
using App.Domain.Core.Car.User.Services;
using App.Domain.Services.Car.CarModel;
using App.Domain.Services.Car.OPrator;
using App.Domain.Services.Car.User;
using App.EndPoints.Api.Car.Middelware;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.Car.CarModel;
using App.Infra.Data.Repos.Ef.Car.OPrator;
using App.Infra.Data.Repos.Ef.Car.User;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
#region Configuration

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);

#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
#region Register Services
builder.Services.AddScoped<IUserAppServices, UserAppServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICarModelAppServices, CarModelAppServices>();
builder.Services.AddScoped<ICarModelServices, CarModelServices>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IOPratorAppServices, OPratorAppServices>();
builder.Services.AddScoped<IOPratorServices, OPratorServices>();
builder.Services.AddScoped<IOPratorRepository, OPratorRepository>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection));
#endregion
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
