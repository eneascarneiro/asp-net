using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crm_mvc.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<crm_mvc_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmDBLocalContext") ?? throw new InvalidOperationException("Connection string 'crm_mvc_Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
//Usamos cookies de autenticado

//Añadimos en manejador de autenticación 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie("MyCookieAuth", options =>
{
    //Establecemos el nombre se la cookie
    options.Cookie.Name = "MyCookieAuth";
});

// Código para la gestión de sesiones
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //Nombre de la cookie de almacenamiento
    options.Cookie.Name = ".crm.Session";
    //Tiempo para que expire la sesión
    options.IdleTimeout = TimeSpan.FromMinutes(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


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
//Para autenticado con cookies
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
