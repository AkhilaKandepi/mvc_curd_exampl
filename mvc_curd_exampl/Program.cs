using Entities.dbcontext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ServiceContract;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var con = builder.Configuration.GetConnectionString("CON_SERVER");
builder.Services.AddDbContext<CHILD_OF_DBCONTEXT>(s => s.UseSqlServer(con,A=>A.MigrationsAssembly("Entities")));

builder.Services.AddScoped<ICountry, CountryServices>();




var app = builder.Build();

app.UseRouting();
app.MapControllerRoute(
   name: "default",
    pattern: "{controller=Country}/{action=GetAllcountrydata}/{id?}");


app.Run();
;