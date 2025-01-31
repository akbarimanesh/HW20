using App.Domain.AppServices.Car.CarModel;
using App.Domain.AppServices.Car.OPrator;
using App.Domain.AppServices.Car.User;
using App.Domain.Core.Car.CarModel.AppServices;
using App.Domain.Core.Car.CarModel.Data.Repositories;
using App.Domain.Core.Car.CarModel.Services;
using App.Domain.Core.Car.Configs;
using App.Domain.Core.Car.OPrator.AppServices;
using App.Domain.Core.Car.OPrator.Data.Repositories;
using App.Domain.Core.Car.OPrator.Entities;
using App.Domain.Core.Car.OPrator.Services;
using App.Domain.Core.Car.User.AppServices;
using App.Domain.Core.Car.User.Data.Repositories;
using App.Domain.Core.Car.User.Services;
using App.Domain.Services.Car.CarModel;
using App.Domain.Services.Car.OPrator;
using App.Domain.Services.Car.User;
using App.Infra.Data.Db.SqlServer.Ef.Common;
using App.Infra.Data.Repos.Ef.Car.CarModel;
using App.Infra.Data.Repos.Ef.Car.OPrator;
using App.Infra.Data.Repos.Ef.Car.User;
using Framework;
using Microsoft.AspNetCore.Identity;
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
builder.Services.AddIdentity<OperatorCar, IdentityRole<int>>(option=>
{
    option.SignIn.RequireConfirmedAccount = false;
    option.Password.RequireDigit= false;
    option.Password.RequiredLength = 6;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequireLowercase = false;
    
})
   
   .AddRoles<IdentityRole<int>>()
   .AddErrorDescriber<PersianIdentityErrorDescriber>()
   .AddEntityFrameworkStores<AppDbContext>();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
