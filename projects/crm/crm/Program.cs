using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crm.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//Añadimos en manejador de autenticación 
builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
 {
     //Establecemos el nombre se la cookie
     options.Cookie.Name = "MyCookieAuth";
 });
//Fin en manejador de autenticación

//Código para gestionar páginas con enrutamiento
builder.Services.AddMvc().AddRazorPagesOptions(options =>
{
    options.Conventions.AddPageRoute( "/Account/login","");
});
//Fin código para gestionar páginas con enrutamiento

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

// Fin Código para la gestión de sesiones
//Añadimos el contexto de comunicacion a la base de datos
builder.Services.AddDbContext<CrmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CrmContext") ?? throw new InvalidOperationException("Connection string 'CrmContext' not found.")));
//Fin del manejador de autenticación 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
// Código para la gestión de sesiones
app.UseSession();
// Fin Código para la gestión de sesiones


app.MapRazorPages();

app.Run();
