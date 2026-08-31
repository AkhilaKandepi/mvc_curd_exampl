using Entities.dbcontext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ServiceContract;
using ServiceContract.Interface;
using Services;
using Rotativa.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ICountry, CountryServices>();
builder.Services.AddScoped<IPerson, PersonServices>();

//var con = builder.Configuration.GetConnectionString("CON_SERVER");
//builder.Services.AddDbContext<CHILD_OF_DBCONTEXT>(s => s.UseSqlServer(con,A=>A.MigrationsAssembly("Entities")));



builder.Services.AddDbContext<CHILD_OF_DBCONTEXT>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CON_SERVER"));
});


var app = builder.Build();
RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
   name: "default",
    pattern: "{controller=Person}/{action=Add}/{id?}");


app.Run();
