using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Reflection;
//using Swashbuckle.AspNetCore.SwaggerGen;
using TestApp.Application;
using TestApp.Application.Common.Mappings;
using TestApp.Application.Interfaces;
using TestApp.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

//using TestApp.Mvc.Middleware;
//using TestApp.Mvc.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IDrinksDbContext).Assembly));
});


builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Users\\Anton\\source\\repos\\TestApp\\TestApp.Persistence\\App_Data");
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetService<DrinksDbContext>();
    DbInitializer.Initialize(context);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(

    name: "default",
    pattern: "{controller=Machine}/{action=GetMachine}/{id?}");



app.Run();
